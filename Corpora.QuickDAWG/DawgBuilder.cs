﻿#define ARRAY_BINARY_IMAGE                      // используем двоичный образ-массив

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Corpora.QuickDAWG
{
    /// <summary>
    /// построитель графа
    /// </summary>
    public partial class DawgBuilder
    {
        private Node _root;                                         // корневой элемент

        private Node[] prefix;                                      // вспомогательный массив для построения префикса
#if ARRAY_BINARY_IMAGE
        private Dictionary<byte[], Node> _nodeHash;                 // хеш-таблица вершин
#else
        private Dictionary<string, Node> _nodeHash;                 // хеш-таблица вершин
#endif

        private object _locker = new object();                      // блокировщик потока
        private int _nextNodeID = 1;                                // идентификатор следующей вершины

        /// <summary>
        /// корневой элемент
        /// </summary>
        public Node Root { get => _root; private set => _root = value; }

        /// <summary>
        /// конструктор
        /// </summary>
        public DawgBuilder()
        {
            _root = new Node(0);

            // инициализируем словари
            _prefixes = new Dictionary<string, WeightedString>();
            _suffixes = new Dictionary<string, WeightedString>();
            _tags = new Dictionary<string, Tag>();
            _paradigms = new Dictionary<string, Paradigm>();

            // вспомогательные структуры
            prefix = new Node[128];
#if ARRAY_BINARY_IMAGE
            _nodeHash = new Dictionary<byte[], Node>(ByteArrayComparer.Default);
#else
            _nodeHash = new Dictionary<string, Node>();
#endif
        }

        /// <summary>
        /// добавить слово в граф
        /// </summary>
        /// <param name="key"> ключ </param>
        /// <param name="paradigm"> парадигма </param>
        /// <param name="index"> форма слова </param>
        public void Add(string key, Paradigm paradigm, int index)
        {
            lock (_locker)
            {
                AddSuffix(key, GetPrefix(_root, key));
            }
        }

        /// <summary>
        /// добавить суффикс
        /// </summary>
        /// <param name="key"> ключ </param>
        /// <param name="prefixLength"> длина префикса </param>
        private void AddSuffix(string key, int prefixLength)
        {
            //if (key == "азазелловичем_1") System.Diagnostics.Debugger.Break();

            int last = prefixLength, len = key.Length, i, j,
                cloneIndex = -1,
                lastActual;

            // последняя вершина
            Node node = last == 0 ? _root : prefix[last - 1],
                newNode = null, parent;

            // выходим, если имел место дубль
            if (last == len && node.IsFinal != default) return;

            // ищем вершины с более чем одним переходом
            for (i = 0; i < last; i++)
            {
                prefix[i].Weight++;
                if (prefix[i].Confluence > 1 && cloneIndex < 0) cloneIndex = i;
            }

            if (cloneIndex >= 0)
            {
                // клонируем последующие состояния
                for (i = cloneIndex; i < last; i++)
                {
                    node = prefix[i];
                    parent = i == 0 ? _root : prefix[i - 1];

                    newNode = node.Clone(_nextNodeID++);
                    node.Weight--;
                    parent.Add(key[i], newNode);

                    prefix[i] = newNode;
                }
            }

            // добавляем новые вершины
#if ARRAY_BINARY_IMAGE
            byte[] image;
#else
            string image;
#endif
            lastActual = len - 1;
            bool updateLastActual = true;
            for (i = lastActual; i >= last; i--)
            {
                if (i < lastActual - 1)
                {
                    // схлопнуть пока нечего
                    prefix[i] = new Node(_nextNodeID++);
                }
                else
                {
                    // строим предварительный образ вершины
                    image = i == len - 1 ? Node.FINAL_DATA : Node.GetObjectImage(false, key[i + 1], node.ID);

                    // ищем готовую вершину
                    if (_nodeHash.TryGetValue(image, out node))
                    {
                        for (j = 0; j < last; j++)
                        {
                            if (prefix[j] == node)
                            {
                                node = new Node(_nextNodeID++);
                                updateLastActual = false;
                                break;
                            }
                        }
                        if (updateLastActual) lastActual = i;
                    }
                    else
                    {
                        node = new Node(_nextNodeID++);
                    }
                    prefix[i] = node;
                }
            }
            for (i = last; i < len; i++)
            {
                (i == 0 ? _root : prefix[i - 1]).Add(key[i], prefix[i]);
            }

            // помечаем финальное состояние
            prefix[len - 1].SetFinal();

            // обновляем хеш образов
            for (i = lastActual; i >= 0; i--)
            {
                node = prefix[i];

                if (node.LastImage == null)
                {
                    // генерируем образ
                    node.GetObjectImage();
                }
                else
                {
                    // следует проверить актуальность образа
                    UpdateNodeImage(node);
                }
            }

            // схлопываем вершины
            bool isEnd = false;
            for (i = lastActual; i >= 0; i--)
            {
                node = prefix[i];

                if (_nodeHash.TryGetValue(node.LastImage, out newNode))
                {
                    if (!isEnd && node != newNode)
                    {
                        // схлопываем вершины
                        parent = i == 0 ? _root : prefix[i - 1];
                        node.Free();
                        parent.Add(key[i], newNode);
                        newNode.Weight += node.Weight;

                        // обновляем образ родительской вершины
                        UpdateNodeImage(parent);
                    }
                }
                else
                {
                    // добавляем в хеш
                    isEnd = true;
                    _nodeHash.Add(node.LastImage, node);
                }
            }
        }

        /// <summary>
        /// обновить образ вершины
        /// </summary>
        /// <param name="node"> вершина </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateNodeImage(Node node)
        {
            var lastImage = node.LastImage;
            var newImage = node.GetObjectImage(true);
            if (lastImage != default && lastImage != newImage)
            {
                // требуется обновление в хеше
                _nodeHash.Remove(lastImage);
                //_nodeHash.Add(node.LastImage, node);
            }
        }

        /// <summary>
        /// получить префиксные вершины для ключа
        /// </summary>
        /// <param name="node"> начальная вершина </param>
        /// <param name="key"> ключ </param>
        /// <returns></returns>
        private int GetPrefix(Node node, string key)
        {
            int j = 0, len = key.Length;
            if (len > prefix.Length)
            {
                // необходимо расширить префиксный массив
                Array.Resize(ref prefix, prefix.Length * 2);
            }
            for (int i = 0; i < len; i++)
            {
                if (!node.Children.TryGetValue(key[i], out node)) break;
                else prefix[j++] = node;
            }
            return j;
        }

        /// <summary>
        /// посчитать общее число вершин
        /// </summary>
        /// <returns></returns>
        public int CountNodes()
        {
            var stack = new Stack<Node>();
            stack.Push(_root);

            var hash = new HashSet<Node>();

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (!hash.Contains(node))
                {
                    hash.Add(node);
                    foreach (var child in node.Children.Values)
                    {
                        stack.Push(child);
                    }
                }
            }

            return hash.Count;
        }
    }
}

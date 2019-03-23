using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Corpora.QuickDAWG
{
    /// <summary>
    /// построитель графа
    /// </summary>
    public partial class DawgBuilder
    {
        private Node _root;                                         // корневой элемент

        private List<Node> _prefixNodes = new List<Node>();         // вспомогательный список для построения префикса
        private Dictionary<string, Node> _nodeHash;                 // хеш-таблица вершин

        /// <summary>
        /// корневой элемент
        /// </summary>
        public Node Root { get => _root; private set => _root = value; }

        /// <summary>
        /// конструктор
        /// </summary>
        public DawgBuilder()
        {
            _root = new Node();

            // инициализируем словари
            _prefixes = new Dictionary<string, WeightedString>();
            _suffixes = new Dictionary<string, WeightedString>();
            _tags = new Dictionary<string, Tag>();
            _paradigms = new Dictionary<string, Paradigm>();

            // вспомогательные структуры
            _nodeHash = new Dictionary<string, Node>();
        }

        /// <summary>
        /// добавить слово в граф
        /// </summary>
        /// <param name="key"> ключ </param>
        /// <param name="paradigm"> парадигма </param>
        /// <param name="index"> форма слова </param>
        public void Add(string key, Paradigm paradigm, int index)
        {
            var prefix = GetPrefix(_root, key);
            AddSuffix(key, prefix);
        }

        /// <summary>
        /// добавить суффикс
        /// </summary>
        /// <param name="key"> ключ </param>
        /// <param name="prefix"> префикс </param>
        private void AddSuffix(string key, List<Node> prefix)
        {
            //if (key == "велиуллой") System.Diagnostics.Debugger.Break();

            int last = prefix.Count, len = key.Length, i, cloneIndex = -1;

            // последняя вершина
            Node node = last == 0 ? _root : prefix[last - 1],
                newNode, parent;

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

                    newNode = node.Clone();
                    node.Weight--;
                    parent.Add(key[i], newNode);

                    prefix[i] = newNode;
                }

                // обновляем стартовую вершину
                node = prefix[last - 1];
            }

            // добавляем новые вершины
            for (i = last; i < len; i++)
            {
                newNode = new Node();
                node.Add(key[i], newNode);
                prefix.Add(newNode);
                node = newNode;
            }

            // помечаем состояние как финальное
            node.SetFinal();

            // обновляем хеш образов
            for (i = len - 1; i >= 0; i--)
            {
                node = prefix[i];

                if (node.LastImage == default)
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
            for (i = len - 1; i >= 0; i--)
            {
                node = prefix[i];
                if (_nodeHash.ContainsKey(node.LastImage))
                {
                    if (!isEnd)
                    {
                        // схлопываем вершины
                        parent = i == 0 ? _root : prefix[i - 1];
                        node.Free();
                        newNode = _nodeHash[node.LastImage] as Node;
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
        private List<Node> GetPrefix(Node node, string key)
        {
            _prefixNodes.Clear();

            foreach (char c in key)
            {
                if (!node.Children.TryGetValue(c, out node)) break;
                else _prefixNodes.Add(node);
            }

            return _prefixNodes;
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

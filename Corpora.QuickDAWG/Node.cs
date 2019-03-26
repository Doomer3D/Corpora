#define BINARY_IMAGE                            // используем двоичный образ
#if BINARY_IMAGE
#define ARRAY_BINARY_IMAGE                      // используем двоичный образ-массив
#endif

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Corpora.QuickDAWG
{
    /// <summary>
    /// вершина
    /// </summary>
    public sealed class Node
    {
        /// <summary>
        /// символ-разделитель
        /// </summary>
        public const char SEPARATOR = '@';

#if ARRAY_BINARY_IMAGE
        /// <summary>
        /// символ-признак финала
        /// </summary>
        public const byte FINAL_CHAR = 1;

        /// <summary>
        /// символ-признак финала
        /// </summary>
        public static readonly byte[] FINAL_DATA = new byte[] { FINAL_CHAR };

        /// <summary>
        /// символ-признак не-финала
        /// </summary>
        public const byte NON_FINAL_CHAR = 0;

        /// <summary>
        /// символ-признак не-финала
        /// </summary>
        public static readonly byte[] NON_FINAL_DATA = new byte[] { NON_FINAL_CHAR };
#else
        /// <summary>
        /// символ-признак финала
        /// </summary>
        public const char FINAL_CHAR = '*';

        /// <summary>
        /// символ-признак финала
        /// </summary>
        public const string FINAL_DATA = "*";

        /// <summary>
        /// символ-признак не-финала
        /// </summary>
        public const char NON_FINAL_CHAR = '^';

        /// <summary>
        /// символ-признак не-финала
        /// </summary>
        public const string NON_FINAL_DATA = "^";
#endif

        /// <summary>
        /// идентификатор
        /// </summary>
        public int ID;

        /// <summary>
        /// вес вершины
        /// </summary>
        public int Weight = 1;

        /// <summary>
        /// дочерние элементы
        /// </summary>
        public SortedDictionary<char, Node> Children;

        /// <summary>
        /// число переходов свыше одного
        /// </summary>
        public int Confluence;

        /// <summary>
        /// признак финального состояния
        /// </summary>
        public byte IsFinal;

        /// <summary>
        /// предыдущее значение образа
        /// </summary>
#if ARRAY_BINARY_IMAGE
        public byte[] LastImage;
#else
        public string LastImage;
#endif

        private byte _imageIsActual = 0;        // признак актуальности образа
#if !BINARY_IMAGE
        private StringBuilder _imageBuilder;    // сохраненный построитель образа
#endif

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор вершины </param>
        public Node(int id)
        {
            this.ID = id;
            this.Children = new SortedDictionary<char, Node>();
        }

        /// <summary>
        /// добавить ключ
        /// </summary>
        /// <param name="key"> ключ </param>
        /// <param name="node"> вершина </param>
        public void Add(char key, Node node)
        {
            // REMOVE
            if (node == this) System.Diagnostics.Debugger.Break();

            if (Children.TryGetValue(key, out var prev))
            {
                // ключ уже был
                if (!ReferenceEquals(prev, node))
                {
                    prev.Confluence--;
                    node.Confluence++;
                    Children[key] = node;
                    _imageIsActual = default;
                }
            }
            else
            {
                // новый ключ
                node.Confluence++;
                Children[key] = node;
                _imageIsActual = default;
            }
        }

        /// <summary>
        /// удалить ключ
        /// </summary>
        /// <param name="key"> ключ </param>
        public void Remove(char key)
        {
            if (Children.TryGetValue(key, out var prev))
            {
                prev.Confluence--;
                Children.Remove(key);
                _imageIsActual = default;
            }
        }

        /// <summary>
        /// освободить связи вершины
        /// </summary>
        public void Free()
        {
            foreach (var node in Children.Values)
            {
                node.Confluence--;
            }
        }

        /// <summary>
        /// сделать вершину финальной
        /// </summary>
        public void SetFinal()
        {
            if (IsFinal == default)
            {
                IsFinal = 1;
                _imageIsActual = default;
            }
        }

#if BINARY_IMAGE

        /// <summary>
        /// получить образ объекта
        /// </summary>
        /// <param name="force"> признак принудительного обновления </param>
        /// <returns></returns>
#if ARRAY_BINARY_IMAGE
        public byte[] GetObjectImage(bool force = false)
#else
        public string GetObjectImage(bool force = false)
#endif
        {
            if (_imageIsActual == default || LastImage == default || force)
            {
                int count = count = this.Children.Count;
                if (count == 0)
                {
                    LastImage = IsFinal == default ? NON_FINAL_DATA : FINAL_DATA;
                }
                else
                {
                    int i = 1, len = count * 6 + 1;
#if ARRAY_BINARY_IMAGE
                    byte[] buffer = LastImage == default || LastImage.Length != len ? new byte[len] : LastImage;
#else
                    byte[] buffer = new byte[len];
#endif

                    short keyID;
                    int id;

                    buffer[0] = (byte)(IsFinal == 0 ? NON_FINAL_CHAR : FINAL_CHAR);
                    foreach (var (key, value) in Children)
                    {
                        // ключ
                        buffer[i++] = (byte)((keyID = (short)key) >> 8);
                        buffer[i++] = (byte)(keyID);

                        // идентификатор вершины
                        buffer[i++] = (byte)((id = value.ID) >> 24);
                        buffer[i++] = (byte)(id >> 16);
                        buffer[i++] = (byte)(id >> 8);
                        buffer[i++] = (byte)id;
                    }
#if ARRAY_BINARY_IMAGE
                    LastImage = buffer;
#else
                    LastImage = Convert.ToBase64String(buffer);
#endif
                    _imageIsActual = 1;
                }
            }
            return LastImage;
        }

        /// <summary>
        /// получить предварительный образ объекта для вершины
        /// </summary>
        /// <param name="isFinal"> признак финальной вершины </param>
        /// <param name="key"> ключ </param>
        /// <param name="id"> идентификатор вершины </param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if ARRAY_BINARY_IMAGE
        public static byte[] GetObjectImage(bool isFinal, char key, int id)
#else
        public static string GetObjectImage(bool isFinal, char key, int id)
#endif
        {
            if (isFinal)
            {
                return FINAL_DATA;
            }
            else
            {
                byte[] buffer = new byte[7];
                buffer[0] = (byte)NON_FINAL_CHAR;
                short keyID = (short)key;

                // ключ
                buffer[1] = (byte)(keyID >> 8);
                buffer[2] = (byte)(keyID);

                // идентификатор вершины
                buffer[3] = (byte)(id >> 24);
                buffer[4] = (byte)(id >> 16);
                buffer[5] = (byte)(id >> 8);
                buffer[6] = (byte)id;

#if ARRAY_BINARY_IMAGE
                return buffer;
#else
                return Convert.ToBase64String(buffer);
#endif
            }
        }

#else

        /// <summary>
        /// получить образ объекта
        /// </summary>
        /// <param name="force"> признак принудительного обновления </param>
        /// <returns></returns>
        public string GetObjectImage(bool force = false)
        {
            if (_imageIsActual == default || LastImage == default || force)
            {
                int i = 0, count = this.Children.Count;
                StringBuilder sb;
                if (_imageBuilder == default) sb = _imageBuilder = new StringBuilder();
                else
                {
                    sb = _imageBuilder;
                    sb.Clear();
                }
                sb.Append(IsFinal == 0 ? NON_FINAL_CHAR : FINAL_CHAR);
                foreach (var (key, value) in Children)
                {
                    sb.Append(key);
                    sb.Append(value.ID);
                    if (++i < count) sb.Append(';');
                }
                //sb.Append('.');
                LastImage = sb.ToString();
                _imageIsActual = 1;
            }
            return LastImage;
        }

        /// <summary>
        /// полуить предварительный образ объекта для вершины
        /// </summary>
        /// <param name="isFinal"></param>
        /// <param name="key"></param>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetObjectImage(bool isFinal, char key, int nodeID)
        {
            if (isFinal)
            {
                return FINAL_STRING;
            }
            else
            {
                var sb = new StringBuilder(8);
                sb.Append(NON_FINAL_CHAR);
                sb.Append(key);
                sb.Append(nodeID);
                return sb.ToString();
            }
        }

#endif

        /// <summary>
        /// клонировать вершину
        /// </summary>
        /// <param name="id"> идентификатор вершины </param>
        /// <returns></returns>
        public Node Clone(int id)
        {
            var node = new Node(id)
            {
                IsFinal = this.IsFinal,
            };

            // клонируем детей (это важно, т.к. нужно обновить Confluence)
            foreach (var (key, value) in this.Children)
            {
                node.Add(key, value);
            }

            return node;
        }

        public override string ToString()
        {
            if (ID == 0) return "ROOT";
            else return $"{ID}{(IsFinal == default ? "^" : "*")}";
        }
    }
}

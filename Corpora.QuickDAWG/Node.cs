using System;
using System.Collections.Generic;
using System.Text;

namespace Corpora.QuickDAWG
{
    /// <summary>
    /// вершина
    /// </summary>
    public class Node
    {
        /// <summary>
        /// символ-разделитель
        /// </summary>
        public const char SEPARATOR = '@';

#if DEBUG

        private static int _id = 0;             // глобальный идентификатор вершины

        /// <summary>
        /// идентификатор
        /// </summary>
        public int ID { get; set; } = _id++;

#endif

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
        public string LastImage;

        private byte _imageIsActual = 0;        // признак актуальности образа
        private StringBuilder _imageBuilder;    // сохраненный построитель образа

        /// <summary>
        /// конструктор
        /// </summary>
        public Node()
        {
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
                if (_imageBuilder == default) sb = _imageBuilder = new StringBuilder(count * 4 + 1);
                else
                {
                    sb = _imageBuilder;
                    sb.Clear();
                }
                sb.Append(IsFinal == 0 ? '^' : '*');
                foreach (var (key, value) in Children)
                {
                    sb.Append(key);
                    sb.Append(value.ID);
                    if (++i <= count) sb.Append(';');
                }
                LastImage = sb.ToString();
                _imageIsActual = 1;
            }
            return LastImage;
        }

        ///// <summary>
        ///// получить образ объекта
        ///// </summary>
        ///// <param name="force"> признак принудительного обновления </param>
        ///// <returns></returns>
        //public string GetObjectImage(bool force = false)
        //{
        //    if (_imageIsActual == default || LastImage == default || force)
        //    {
        //        int i = 0, count = this.Children.Count;
        //        var sb = new StringBuilder(count * 4 + 1);
        //        sb.Append(IsFinal == 0 ? '^' : '*');
        //        foreach (var (key, value) in Children)
        //        {
        //            sb.Append(key);
        //            //sb.Append(value.GetObjectImage());
        //            sb.Append(value.ID);
        //            if (++i <= count) sb.Append(';');
        //        }
        //        LastImage = sb.ToString();
        //        _imageIsActual = 1;
        //    }
        //    return LastImage;
        //}

        ///// <summary>
        ///// получить бинарный образ объекта
        ///// </summary>
        ///// <param name="force"> признак принудительного обновления </param>
        ///// <returns></returns>
        //public string GetObjectImage(bool force = false)
        //{
        //    if (_imageIsActual == default || LastImage == default || force)
        //    {
        //        int i = 0, count = this.Children.Count;
        //        byte[] buffer = new byte[count * 6 + 1];
        //        buffer[0] = IsFinal;
        //        foreach (var (key, value) in Children)
        //        {
        //            Array.Copy(BitConverter.GetBytes((short)key), 0, buffer, i * 6 + 1, 2);
        //            Array.Copy(BitConverter.GetBytes(value.ID), 0, buffer, i * 6 + 3, 4);
        //            i++;
        //        }
        //        LastImage = _encoding.GetString(buffer);
        //        _imageIsActual = 1;
        //    }
        //    return LastImage;
        //}

        /// <summary>
        /// клонировать вершину
        /// </summary>
        /// <returns></returns>
        public Node Clone()
        {
            var node = new Node()
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

#if DEBUG
        public override string ToString()
        {
            if (ID == 0) return "ROOT";
            else return $"{ID}{(IsFinal == default ? "^" : "*")}";
        }
#else
        public override string ToString() => $"{(IsFinal == default ? "0" : "*")}";
#endif

        private static Encoding _encoding = Encoding.ASCII;
        //private static byte _buffer = new byte[1000];
    }
}

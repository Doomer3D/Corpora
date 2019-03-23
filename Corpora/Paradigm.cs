using System;
using System.Collections.Generic;
using System.Linq;

namespace Corpora
{
    /// <summary>
    /// парадигма
    /// </summary>
    public class Paradigm : IWeightedEntity
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        /// префиксы
        /// </summary>
        public WeightedString[] Prefixes { get; set; }

        /// <summary>
        /// суффиксы
        /// </summary>
        public WeightedString[] Suffixes { get; set; }

        /// <summary>
        /// теги
        /// </summary>
        public Tag[] Tags { get; set; }

        /// <summary>
        /// вес элемента
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Paradigm() { }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="prefixes"> префиксы </param>
        /// <param name="suffixes"> суффиксы </param>
        /// <param name="tags"> теги </param>
        public Paradigm(short id, WeightedString[] prefixes, WeightedString[] suffixes, Tag[] tags)
        {
            this.ID = id;
            this.Prefixes = prefixes;
            this.Suffixes = suffixes;
            this.Tags = tags;
        }

        public override string ToString()
        {
            int len = Prefixes.Length;
            var sb = new System.Text.StringBuilder(len * 4 + 8);

            sb.Append('[');
            sb.Append(ID);
            sb.Append("] ");

            for (int i = 0; i < len; i++)
            {
                sb.Append(Prefixes[i]?.ID ?? default);
                if (i != len - 1) sb.Append(';');
            }
            sb.Append(" | ");
            for (int i = 0; i < len; i++)
            {
                sb.Append(Suffixes[i]?.ID ?? default);
                if (i != len - 1) sb.Append(';');
            }
            sb.Append(" | ");
            for (int i = 0; i < len; i++)
            {
                sb.Append(Tags[i]?.ID ?? default);
                if (i != len - 1) sb.Append(';');
            }

            return sb.ToString();
        }

        /// <summary>
        /// получить образ объекта
        /// </summary>
        /// <param name="prefixes"> префиксы </param>
        /// <param name="suffixes"> суффиксы </param>
        /// <param name="tags"> теги </param>
        /// <returns></returns>
        public static string GetObjectImage(WeightedString[] prefixes, WeightedString[] suffixes, Tag[] tags)
        {
            if (prefixes == null) return null;

            int len = prefixes.Length;
            var sb = new System.Text.StringBuilder(len * 4 + 8);

            for (int i = 0; i < len; i++)
            {
                sb.Append(prefixes[i]?.ID ?? default);
                if (i != len - 1) sb.Append(';');
            }
            sb.Append('|');
            for (int i = 0; i < len; i++)
            {
                sb.Append(suffixes[i]?.ID ?? default);
                if (i != len - 1) sb.Append(';');
            }
            sb.Append('|');
            for (int i = 0; i < len; i++)
            {
                sb.Append(tags[i]?.ID ?? default);
                if (i != len - 1) sb.Append(';');
            }

            return sb.ToString();
        }
    }
}

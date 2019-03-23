using System;
using System.Collections.Generic;
using System.Linq;

namespace Corpora
{
    /// <summary>
    /// тег
    /// </summary>
    public class Tag : IWeightedEntity
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        /// список граммем
        /// </summary>
        public Grammeme[] Items { get; set; }

        /// <summary>
        /// вес элемента
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Tag() { }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="items"> список граммем </param>
        public Tag(short id, IEnumerable<Grammeme> items)
        {
            this.ID = id;
            this.Items = items.OrderBy(e => e.ID).ToArray();
        }

        public override string ToString() => $"[{ID}] {string.Join(";", Items.Select(e => e.Alias).ToArray())}";

        /// <summary>
        /// получить образ объекта
        /// </summary>
        /// <param name="items"> список граммем </param>
        /// <returns></returns>
        public static string GetObjectImage(IEnumerable<Grammeme> items)
        {
            if (items == null) return null;
            return new string(items.Select(e => (char)e.ID).OrderBy(e => e).ToArray());
        }
    }
}

using System;
using System.Collections.Generic;

namespace Corpora
{
    /// <summary>
    /// тип связи между лексемами
    /// </summary>
    public partial class LinkType
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        /// описание связи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public LinkType() { }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="name"> описание связи </param>
        public LinkType(byte id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override int GetHashCode() => ID;

        public override string ToString() => Name ?? base.ToString();

        #region Static

        /// <summary>
        /// список типов связей
        /// </summary>
        private static readonly List<LinkType> _links;

        /// <summary>
        /// словарь типов связей (по идентификатору)
        /// </summary>
        public static readonly Dictionary<byte, LinkType> _linksByID;

        /// <summary>
        /// зарегистрировать тип связи
        /// </summary>
        /// <param name="item"> тип связи </param>
        private static void Register(LinkType item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!_links.Contains(item)) _links.Add(item);
            if (!_linksByID.ContainsKey(item.ID)) _linksByID.Add(item.ID, item);
        }

        /// <summary>
        /// получить тип связи по идентификатору
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <returns></returns>
        public static LinkType GetByID(byte id)
        {
            return _linksByID[id];
        }

        /// <summary>
        /// попытаться получить тип связи по идентификатору
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="value"> граммема </param>
        /// <returns></returns>
        public static bool TryGetByID(byte id, out LinkType value)
        {
            return _linksByID.TryGetValue(id, out value);
        }

        #endregion
    }
}

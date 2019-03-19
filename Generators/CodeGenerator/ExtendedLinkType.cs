namespace Corpora
{
    /// <summary>
    /// расширенное описание типа связи
    /// </summary>
    public class ExtendedLinkType : LinkType
    {
        /// <summary>
        /// исходное наименование
        /// </summary>
        public string OriginName { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="name"> описание связи </param>
        public ExtendedLinkType(byte id, string name) : base(id, name)
        {
        }
    }
}

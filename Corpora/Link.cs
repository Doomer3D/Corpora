namespace Corpora
{
    /// <summary>
    /// связь между лексемами
    /// </summary>
    public class Link
    {
        /// <summary>
        /// исходная лексема
        /// </summary>
        public Lexeme Source { get; set; }

        /// <summary>
        /// целевая лексема
        /// </summary>
        public Lexeme Target { get; set; }

        /// <summary>
        /// тип связи
        /// </summary>
        public LinkType LinkType { get; set; }
    }
}

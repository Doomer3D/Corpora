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

        /// <summary>
        /// конструктор
        /// </summary>
        public Link() { }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="source"> исходная лексема </param>
        /// <param name="target"> целевая лексема </param>
        /// <param name="linkType"> тип связи</param>
        public Link(Lexeme source, Lexeme target, LinkType linkType)
        {
            this.Source = source;
            this.Target = target;
            this.LinkType = linkType;
        }

        public override string ToString() => $"{Source} => {Target} ({LinkType})";
    }
}

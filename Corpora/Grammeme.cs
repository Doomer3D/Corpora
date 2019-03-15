namespace Corpora
{
    /// <summary>
    /// Граммема
    /// </summary>
    public partial class Grammeme
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// псевдоним
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// описание граммемы
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// родитель
        /// </summary>
        public Grammeme Parent { get; private set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Grammeme() { }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="name"> имя </param>
        /// <param name="alias"> псевдоним </param>
        /// <param name="description"> описание граммемы </param>
        /// <param name="parent"> родитель </param>
        public Grammeme(byte id, string name, string alias, string description, Grammeme parent = null)
        {
            this.ID = id;
            this.Name = name;
            this.Alias = alias;
            this.Description = description;
            this.Parent = parent;
        }

        public override int GetHashCode() => ID != 0 ? ID : (Name ?? "").GetHashCode();

        public override string ToString() => $"{Name} - {Description}";
    }
}

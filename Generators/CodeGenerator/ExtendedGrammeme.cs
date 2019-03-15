namespace Corpora
{
    /// <summary>
    /// расширенное описание граммемы
    /// </summary>
    public class ExtendedGrammeme : Grammeme
    {
        /// <summary>
        /// исходное наименование
        /// </summary>
        public string OriginName { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="name"> имя </param>
        /// <param name="alias"> псевдоним </param>
        /// <param name="description"> описание граммемы </param>
        /// <param name="parent"> родитель </param>
        public ExtendedGrammeme(byte id, string name, string alias, string description, Grammeme parent = null) : base(id, name, alias, description, parent)
        {
        }
    }
}

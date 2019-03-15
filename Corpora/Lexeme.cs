using System.Collections.Generic;

namespace Corpora
{
    /// <summary>
    /// Лексема
    /// </summary>
    public partial class Lexeme
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ревизия
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// лемма (нормальная форма слова)
        /// </summary>
        public Form Lemma { get; set; }

        /// <summary>
        /// набор форм слова
        /// </summary>
        public List<Form> Forms { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Lexeme() { }

        /// <summary>
        /// добавить форму слова
        /// </summary>
        /// <param name="item"> форма слова </param>
        public void AddForm(Form item)
        {
            if (this.Forms == null) this.Forms = new List<Form>();
            this.Forms.Add(item);
        }

        public override int GetHashCode() => ID;

        public override string ToString() => $"Lexeme {ID}: {(Lemma == null ? "none" : Lemma.ToString())}";
    }
}

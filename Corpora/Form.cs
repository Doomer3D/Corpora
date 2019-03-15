using System.Collections.Generic;

namespace Corpora
{
    /// <summary>
    /// Форма слова
    /// </summary>
    public partial class Form
    {
        /// <summary>
        /// форма слова
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// набор граммем (тег)
        /// </summary>
        public List<Grammeme> Grammemes { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Form() { }

        /// <summary>
        /// добавить граммему
        /// </summary>
        /// <param name="item"> граммема </param>
        public void AddGrammeme(Grammeme item)
        {
            if (this.Grammemes == null) this.Grammemes = new List<Grammeme>();
            this.Grammemes.Add(item);
        }

        public override int GetHashCode() => (Text ?? "").GetHashCode();

        public override string ToString() => Text ?? base.ToString();
    }
}

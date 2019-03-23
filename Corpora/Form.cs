using System.Collections.Generic;

namespace Corpora
{
    /// <summary>
    /// форма слова
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

        /// <summary>
        /// деконструировать класс
        /// </summary>
        /// <param name="text"> форма слова </param>
        /// <param name="grammemes"> набор граммем (тег) </param>
        public void Deconstruct(out string text, out List<Grammeme> grammemes)
        {
            text = this.Text;
            grammemes = this.Grammemes;
        }

        public override int GetHashCode() => (Text ?? "").GetHashCode();

        public override string ToString() => Text ?? base.ToString();
    }
}

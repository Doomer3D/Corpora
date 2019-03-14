using System;
using System.Collections.Generic;
using System.Text;

namespace Corpora
{
    /// <summary>
    /// движок анализатора
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// список тегов
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Engine()
        {
        }

        /// <summary>
        /// инициализировать движок
        /// </summary>
        public void Initialize()
        {
            this.Tags = new List<Tag>();
        }
    }
}

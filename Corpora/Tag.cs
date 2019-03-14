using System;
using System.Collections.Generic;

namespace Corpora
{
    /// <summary>
    /// тег
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        /// список граммем
        /// </summary>
        public Grammeme[] Items { get; set; }
    }
}

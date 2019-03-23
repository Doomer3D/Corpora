using System;
using System.Collections.Generic;
using System.Text;

namespace Corpora
{
    /// <summary>
    /// интерфейс взвешенной сущности
    /// </summary>
    public interface IWeightedEntity
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        short ID { get; set; }

        /// <summary>
        /// вес элемента
        /// </summary>
        int Weight { get; set; }
    }
}

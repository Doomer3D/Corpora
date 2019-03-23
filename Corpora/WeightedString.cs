using System;

namespace Corpora
{
    /// <summary>
    /// взвешенная строка
    /// </summary>
    public class WeightedString : IWeightedEntity
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        /// значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// вес элемента
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public WeightedString() { }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="value"> значение </param>
        public WeightedString(short id, string value)
        {
            this.ID = id;
            this.Value = value;
        }

        public override string ToString() => $"{Value} (W = {Weight})";

        public static implicit operator string(WeightedString value) => ReferenceEquals(value, null) ? null : value.Value;
    }
}

using System;

namespace Corpora
{
    /// <summary>
    /// интерфейс ввода-вывода для движка
    /// </summary>
    public interface IEngineDataIO
    {
        /// <summary>
        /// загрузить данные
        /// </summary>
        /// <param name="engine"> движок </param>
        void Load(Engine engine);

        /// <summary>
        /// сохранить данные
        /// </summary>
        /// <param name="engine"> движок </param>
        void Save(Engine engine);
    }
}

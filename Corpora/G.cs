using System;
using System.Collections.Generic;
using System.Linq;

namespace Corpora
{
    /// <summary>
    /// список граммем
    /// </summary>
    public static partial class G
    {
        /// <summary>
        /// список граммем
        /// </summary>
        private static readonly List<Grammeme> _grammemes;

        /// <summary>
        /// словарь граммем (по идентификатору)
        /// </summary>
        public static readonly Dictionary<byte, Grammeme> _grammemesByID;

        /// <summary>
        /// словарь граммем (по имени)
        /// </summary>
        public static readonly Dictionary<string, Grammeme> _grammemesByName;

        /// <summary>
        /// зарегистрировать граммему
        /// </summary>
        /// <param name="item"> граммема </param>
        private static void Register(Grammeme item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!_grammemes.Contains(item)) _grammemes.Add(item);
            if (!_grammemesByID.ContainsKey(item.ID)) _grammemesByID.Add(item.ID, item);
            if (!_grammemesByName.ContainsKey(item.Name)) _grammemesByName.Add(item.Name, item);
        }

        /// <summary>
        /// получить граммему по идентификатору
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <returns></returns>
        public static Grammeme GetByID(byte id)
        {
            return _grammemesByID[id];
        }

        /// <summary>
        /// попытаться получить граммему по идентификатору
        /// </summary>
        /// <param name="id"> идентификатор </param>
        /// <param name="value"> граммема </param>
        /// <returns></returns>
        public static bool TryGetByID(byte id, out Grammeme value)
        {
            return _grammemesByID.TryGetValue(id, out value);
        }

        /// <summary>
        /// получить граммему по имени
        /// </summary>
        /// <param name="name"> имя </param>
        /// <returns></returns>
        public static Grammeme GetByName(string name)
        {
            return _grammemesByName[name];
        }

        /// <summary>
        /// попытаться получить граммему по имени
        /// </summary>
        /// <param name="name"> имя </param>
        /// <param name="value"> граммема </param>
        /// <returns></returns>
        public static bool TryGetByName(string name, out Grammeme value)
        {
            return _grammemesByName.TryGetValue(name, out value);
        }
    }
}

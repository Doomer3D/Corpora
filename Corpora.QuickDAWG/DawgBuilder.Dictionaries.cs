using System;
using System.Collections.Generic;
using System.Linq;

namespace Corpora.QuickDAWG
{
    public partial class DawgBuilder
    {
        private Dictionary<string, WeightedString> _prefixes;       // словарь префиксов
        private Dictionary<string, WeightedString> _suffixes;       // словарь суффиксов
        private Dictionary<string, Tag> _tags;                      // словарь тегов
        private Dictionary<string, Paradigm> _paradigms;            // словарь парадигм

        /// <summary>
        /// получить дескриптор префикса
        /// </summary>
        /// <param name="suffix"> префикс </param>
        /// <returns></returns>
        public WeightedString GetPrefix(string value)
        {
            if (string.IsNullOrEmpty(value)) return default;
            if (!_prefixes.TryGetValue(value, out var res))
            {
                _prefixes.Add(value, res = new WeightedString((short)(_prefixes.Count + 1), value));
            }
            else
            {
                res.Weight++;
            }
            return res;
        }

        /// <summary>
        /// получить дескриптор суффикса
        /// </summary>
        /// <param name="value"> суффикс </param>
        /// <returns></returns>
        public WeightedString GetSuffix(string value)
        {
            if (string.IsNullOrEmpty(value)) return default;
            if (!_suffixes.TryGetValue(value, out var res))
            {
                _suffixes.Add(value, res = new WeightedString((short)(_suffixes.Count + 1), value));
            }
            else
            {
                res.Weight++;
            }
            return res;
        }

        /// <summary>
        /// получить дескриптор тега
        /// </summary>
        /// <param name="data"> список граммем </param>
        /// <returns></returns>
        public Tag GetTag(IEnumerable<Grammeme> items)
        {
            var image = Tag.GetObjectImage(items);
            if (image == null) return default;
            if (!_tags.TryGetValue(image, out var res))
            {
                _tags.Add(image, res = new Tag((short)(_tags.Count + 1), items));
            }
            else
            {
                res.Weight++;
            }
            return res;
        }

        /// <summary>
        /// получить дескриптор парадигмы
        /// </summary>
        /// <param name="prefixes"> префиксы </param>
        /// <param name="suffixes"> суффиксы </param>
        /// <param name="tags"> теги </param>
        /// <returns></returns>
        public Paradigm GetParadigm(WeightedString[] prefixes, WeightedString[] suffixes, Tag[] tags)
        {
            var image = Paradigm.GetObjectImage(prefixes, suffixes, tags);
            if (prefixes == null) return default;
            if (!_paradigms.TryGetValue(image, out var res))
            {
                _paradigms.Add(image, res = new Paradigm((short)(_paradigms.Count + 1), prefixes, suffixes, tags));
            }
            else
            {
                res.Weight++;
            }
            return res;
        }

        /// <summary>
        /// произвести реиндексацию
        /// </summary>
        public void Reindex()
        {
            Reindex(_prefixes);
            Reindex(_suffixes);
            Reindex(_tags);
            Reindex(_paradigms);
        }

        /// <summary>
        /// произвести реиндексацию словаря
        /// </summary>
        /// <typeparam name="T"> тип значения словаря </typeparam>
        /// <param name="items"> словарь </param>
        private void Reindex<T>(Dictionary<string, T> items) where T : IWeightedEntity
        {
            int totalWeight = 0, topWeight = 0;

            short id = 1;
            foreach (var item in items.Values.OrderByDescending(e => e.Weight))
            {
                item.ID = id;
                totalWeight += item.Weight;
                if (id <= 127) topWeight += item.Weight;
                id++;
            }
        }
    }
}

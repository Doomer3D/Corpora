using System;
using System.Collections.Generic;

namespace Corpora
{
    /// <summary>
    /// утилита для поиска максимальной подстроки
    /// </summary>
    public sealed class MaximumSubstring
    {
        private readonly int[,] data;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="max"> максимальный размер слов для поиска </param>
        public MaximumSubstring(int max = 100)
        {
            data = new int[max, max];
        }

        /// <summary>
        /// найти максимальную подстроку у двух строк
        /// </summary>
        /// <param name="a"> первая строка </param>
        /// <param name="b"> вторая строка </param>
        /// <returns></returns>
        public string FindMaximumSubstring(string a, string b)
        {
            int start = 0, greatestLength = 0, val;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        data[i, j] = val = i == 0 || j == 0 ? 1 : data[i - 1, j - 1] + 1;
                        if (val > greatestLength)
                        {
                            greatestLength = val;
                            start = i - greatestLength + 1;
                        }
                    }
                    else
                    {
                        data[i, j] = 0;
                    }
                }
            }
            return greatestLength == 0 ? "" : a.Substring(start, greatestLength);
        }

        /// <summary>
        /// найти максимальную подстроку у множества
        /// </summary>
        /// <param name="strings"> массив строк </param>
        /// <returns></returns>
        public string FindMaximumSubstring(params string[] strings)
        {
            if (strings == null) return "";
            else if (strings.Length == 1) return strings[0];
            else
            {
                string a = strings[0];
                for (int i = 1; i < strings.Length; i++)
                {
                    a = FindMaximumSubstring(a, strings[i]);
                }
                return a;
            }
        }

        /// <summary>
        /// найти максимальную подстроку у множества
        /// </summary>
        /// <param name="strings"> перечисление строк </param>
        /// <returns></returns>
        public string FindMaximumSubstring(IEnumerable<string> strings)
        {
            if (strings == null) return "";

            var enumerator = strings.GetEnumerator();
            if (!enumerator.MoveNext()) return "";

            string a = enumerator.Current;
            while (enumerator.MoveNext())
            {
                a = FindMaximumSubstring(a, enumerator.Current);
            }
            return a;
        }
    }
}

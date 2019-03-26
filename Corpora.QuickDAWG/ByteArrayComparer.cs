using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Corpora.QuickDAWG
{
    /// <summary>
    /// компаратор образов вершин
    /// </summary>
    public class ByteArrayComparer : IEqualityComparer<byte[]> //, IEqualityComparer
    {
        public bool Equals(byte[] left, byte[] right)
        {
            if (left == null || right == null) return left == right;
            else if (left.Length != right.Length) return false;
            else
            {
                for (int i = 0; i < left.Length; i++)
                {
                    if (left[i] != right[i]) return false;
                }
                return true;
            }
        }

        public int GetHashCode(byte[] key)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;

                for (int i = 0; i < key.Length; i++)
                    hash = (hash ^ key[i]) * p;

                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return hash;
            }
        }

        //public new bool Equals(object x, object y)
        //{
        //    if (ReferenceEquals(x, y)) return true;
        //    else if (x is byte[] ax && y is byte[] ay) return Equals(ax, ay);
        //    else return false;
        //}

        //public int GetHashCode(object obj)
        //{
        //    if (obj == default) return 0;
        //    else if (obj is byte[] arr) return GetHashCode(arr);
        //    else return obj.GetHashCode();
        //}

        #region Default

        private static ByteArrayComparer _default;

        /// <summary>
        /// экземпляр класса
        /// </summary>
        public static ByteArrayComparer Default
        {
            get
            {
                return _default ?? (_default = new ByteArrayComparer());
            }
        }

        #endregion
    }
}

using System;

namespace Corpora.QuickDAWG
{
    public static class Extensions
    {
        public static ComparableByteArray ToComparable(this byte[] arr)
        {
            return arr;
        }
    }

    [Serializable]
    public class ComparableByteArray : IEquatable<ComparableByteArray>
    {
        private int _hash;
        private int _initialized;
        private byte[] _internalArray;
        private int _seed;
        private int _uninitialized;

        public ComparableByteArray()
        {
            Reset();
        }

        public ComparableByteArray(ref byte[] arr)
        {
            ResetHash();
            _internalArray = arr;

            int len = _internalArray.Length;
            for (int i = 0; i < len; i++) UpdateHash(_internalArray[i]);

            _initialized = _internalArray.Length;
            _uninitialized = 0;
        }

        public byte this[int index]
        {
            get { return _internalArray[index]; }
        }

        public int Length
        {
            get { return _internalArray.Length; }
        }

        public byte[] Array
        {
            get { return _internalArray; }
        }

        #region IEquatable<ComparableByteArray> Members

        public bool Equals(ComparableByteArray arr)
        {
            return arr == this;
        }

        #endregion

        private void Reset()
        {
            ResetHash();
            _internalArray = new byte[4];
            _initialized = 0;
            _uninitialized = 4;
        }

        public void Add(byte item)
        {
            UpdateHash(item);

            if (_uninitialized == 0) ExpandArray(_internalArray.Length);

            _internalArray[_initialized] = item;
            _initialized++;
            _uninitialized--;
        }

        private void ExpandArray(int i)
        {
            var arr = new byte[_initialized + i];
            _internalArray.CopyTo(arr, 0);
            _internalArray = null;
            _internalArray = arr;
            _uninitialized += i;
        }

        /// <summary> 
        /// Simple hash using pseudo-random coefficients for each byte in 
        /// the array to achieve order dependency.
        /// </summary> 
        private void UpdateHash(byte @byte)
        {
            _hash = (_hash * _seed) + @byte;
            _seed *= 159;
        }

        private void ResetHash()
        {
            _seed = 314;
            _hash = 0;
        }

        public void Clear()
        {
            Reset();
        }

        public override int GetHashCode()
        {
            return _hash;
        }

        public override string ToString()
        {
            return Convert.ToBase64String(Array);
        }

        public override bool Equals(object obj)
        {
            return (typeof(ComparableByteArray).IsAssignableFrom(obj.GetType())
                    && Equals(obj as ComparableByteArray));
        }

        //min O(1), max O(N) comparision, classic version
        public static bool Compare(byte[] first, byte[] second)
        {
            bool? c = PreCheck(first, second);
            if (c.HasValue) return c.Value;

            int len = first.Length;

            for (int i = 0; i < len; i++)
                if ((first[i] ^ second[i]) > 0) return false;
            return true;
        }

        private static bool? PreCheck(byte[] first, byte[] second)
        {
            bool? c = Check(first, second);
            if (c.HasValue) return c.Value;

            if (first.Length != second.Length) return false;

            return null;
        }


        private static bool? PreCheck(ComparableByteArray first, ComparableByteArray second)
        {
            bool? c = Check(first, second);
            if (c.HasValue) return c.Value;

            if (first.Length != second.Length) return false;

            return null;
        }

        private static bool? Check(object first, object second)
        {
            if (ReferenceEquals(first, second)) return true;
            if ((first == null) && (second == null)) return true;
            if ((first == null) || (second == null)) return false;

            return null;
        }


        /*Compare at most COUNT bytes starting at PTR1,PTR2.
         Returns 0 IFF all COUNT bytes are equal.*/

        /*this is the exact implementation of
        [DllImport("msvcrt.dll")]
        private static extern int memcmp(byte[] first, byte[] second, long count);
        
         i just wrote it without Pinvoke*/

        private static unsafe int Memcmp(byte[] ptr1, byte[] ptr2, uint count)
        {
            int v = 0;
            fixed (byte* p1 = ptr1, p2 = ptr2)
            {
                byte* a = p1, b = p2;
                while (count-- > 0 && v == 0) v = *(a++) - *(b++);
            }
            return v;
        }

        public static bool NativeCompare(byte[] first, byte[] second)
        {
            bool? c = PreCheck(first, second);
            if (c.HasValue) return c.Value;

            return Memcmp(first, second, (uint)first.LongLength) == 0;
        }

        //byte[] length should be 4 or 8
        public bool ShortCompare(byte[] array)
        {
            if (Length == 4)
                return BitConverter.ToInt32(Array, 0) == BitConverter.ToInt32(array, 0);

            if (Length == 8)
                return BitConverter.ToInt64(Array, 0) == BitConverter.ToInt64(array, 0);

            return false;
        }

        //Takes X3 memory of the array
        public bool IsBase64Equals(byte[] array)
        {
            return Convert.ToBase64String(Array) == Convert.ToBase64String(array);
        }

        // min O(1), max O(N/10) , it compares 10 at a time
        public static unsafe bool UnSafeCompare(byte[] strA, byte[] strB)
        {
            int length = strA.Length;
            if (length != strB.Length) return false;

            fixed (byte* str = strA, str2 = strB)
            {
                byte* chPtr = str;
                byte* chPtr2 = str2;
                byte* chPtr3 = chPtr;
                byte* chPtr4 = chPtr2;

                while (length >= 10)
                {
                    if ((((*(((int*)chPtr3)) != *(((int*)chPtr4)))
                        || (*(((int*)(chPtr3 + 2))) != *(((int*)(chPtr4 + 2)))))
                        || ((*(((int*)(chPtr3 + 4))) != *(((int*)(chPtr4 + 4))))
                        || (*(((int*)(chPtr3 + 6))) != *(((int*)(chPtr4 + 6))))))
                        || (*(((int*)(chPtr3 + 8))) != *(((int*)(chPtr4 + 8)))))
                        break;

                    chPtr3 += 10;
                    chPtr4 += 10;
                    length -= 10;
                }

                while (length > 0)
                {
                    if (*(((int*)chPtr3)) != *(((int*)chPtr4))) break;

                    chPtr3 += 2;
                    chPtr4 += 2;
                    length -= 2;
                }

                return (length <= 0);
            }
        }

        #region Static

        //public static implicit operator byte[] (ComparableByteArray arr) => arr.Array;

        public static implicit operator ComparableByteArray(byte[] arr) => new ComparableByteArray(ref arr);

        //min O(1), max O(1) comparision
        public static bool operator ==(ComparableByteArray a1, ComparableByteArray a2)
        {
            bool? c = PreCheck(a1, a2);
            if (c.HasValue) return c.Value;
            return (a1.GetHashCode() == a2._hash.GetHashCode());
        }

        public static bool operator !=(ComparableByteArray a1, ComparableByteArray a2)
        {
            return !(a1 == a2);
        }

        #endregion
    }
}


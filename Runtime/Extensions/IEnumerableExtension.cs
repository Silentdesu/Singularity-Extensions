using System;
using System.Collections.Generic;
using System.Linq;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class IEnumerableExtension
    {
        /// <summary>
        /// Swaps two items in a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap<T>(this IList<T> list, in int i, in int j)
        {
            (list[i], list[j]) = (list[j], list[i]);
        }

        private static Random _rng = new Random();

        /// <summary>
        /// Shuffles list elements.
        /// </summary>
        public static IList<T> Shuffle<T>(this IList<T> self)
        {
            int n = self.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                (self[k], self[n]) = (self[n], self[k]);
            }

            return self;
        }

        /// <summary>
        /// Shuffles array elements.
        /// </summary>
        public static T[] Shuffle<T>(this T[] self)
        {
            int n = self.Length;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                (self[k], self[n]) = (self[n], self[k]);
            }

            return self;
        }

        /// <summary>
        /// Get random element from list.
        /// </summary>
        public static T GetRandomElement<T>(this IList<T> list)
        {
            return list[_rng.Next(list.Count - 1)];
        }

        /// <summary>
        /// Clear an array.
        /// </summary> 
        public static void Clear<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default(T);
            }
        }

        /// <summary>
        /// Clone a list.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="listToClone">Original list.</param>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T) item.Clone()).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ApplicationLayer.Utilities
{
    public static class MathHelper
    {
        public static T[] Shuffe<T>(this T[] array, int seed = 1)
        {
            if (array == null)
                return null;

            System.Random random = new System.Random(seed);

            for (int i = 0; i < array.Length - 1; i++)
            {
                int randomIndex = random.Next(i, array.Length);
                T tempItem = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = tempItem;
            }

            return array;
        }

        public static List<T> Shuffe<T>(this List<T> list, int seed = 1)
        {
            if (list == null)
                return null;

            System.Random random = new System.Random(seed);

            for (int i = 0; i < list.Count - 1; i++)
            {
                int randomIndex = random.Next(i, list.Count);
                T tempItem = list[randomIndex];
                list[randomIndex] = list[i];
                list[i] = tempItem;
            }

            return list;
        }

        public static Vector2 RadianToVector2 (this float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        public static Vector2 RadianToVector2 (this float radian, float length)
        {
            return RadianToVector2(radian) * length;
        }

        public static Vector2 DegreeToVector2 (this float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        public static Vector2 DegreeToVector2 (this float degree, float length)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad) * length;
        }

        public static IEnumerable<IEnumerable<T>> AllPossiblePermutations<T>(this List<T> layouts)
        {
            for (int i = 1; i <= layouts.Count; i++)
            {
                foreach (var permutation in layouts.Permutations(i))
                {
                    yield return permutation;
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int length)
        {
            return length == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(length - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t }).ToArray();

            return Permutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static IEnumerable<IEnumerable<T>> IterateDynamicLoop<T>(this IList<List<T>> data)
        {
            int count = data.Count;

            int loopIndex = count - 1;
            int[] counters = new int[count];
            int[] bounds = data.Select(x => x.Count).ToArray();

            do
            {
                yield return Enumerable.Range(0, count).Select(x => data[x][counters[x]]);
            }
            while (IncrementLoopState(counters, bounds, ref loopIndex));
        }

        private static bool IncrementLoopState(IList<int> counters, IList<int> bounds, ref int loopIndex)
        {
            if (loopIndex < 0)
                return false;

            counters[loopIndex] = counters[loopIndex] + 1;

            bool result = true;

            if (counters[loopIndex] >= bounds[loopIndex])
            {
                counters[loopIndex] = 0;
                loopIndex--;
                result = IncrementLoopState(counters, bounds, ref loopIndex);
                loopIndex++;
            }

            return result;
        }
    }
}

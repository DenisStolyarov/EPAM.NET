// <copyright file="Exercise.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace JaggedArray
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Get maximum element of arrays
    /// </summary>
    public class Max : IComparer <int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] first, int[] second)
        {
            if (first == null && second == null)
            {
                return 0;
            }

            if (first == null)
            {
                return 1;
            }

            if (second == null)
            {
                return -1;
            }

            return first.Max() - second.Max();
        }
    }

    /// <summary>
    /// Get minimal element of arrays
    /// </summary>
    public class Min : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] first, int[] second)
        {
            if (first == null && second == null)
            {
                return 0;
            }

            if (first == null)
            {
                return 1;
            }

            if (second == null)
            {
                return -1;
            }

            return first.Min() - second.Min();
        }
    }

    /// <summary>
    /// Get sum of all elements
    /// </summary>
    public class Sum : IComparer<int[]>
    {
        /// <inheritdoc/>
        public int Compare(int[] first, int[] second)
        {
            if (first == null && second == null)
            {
                return 0;
            }

            if (first == null)
            {
                return 1;
            }

            if (second == null)
            {
                return -1;
            }

            return first.Sum() - second.Sum();
        }
    }

    /// <summary>
    /// Class with completed exercises
    /// </summary>
    public static class JaggedArrayOne
    {
        /// <summary>
        /// Swap two arrays
        /// </summary>
        /// <param name="arr1">First array</param>
        /// <param name="arr2">Second array</param>
        public static void Swap(ref int[] arr1, ref int[] arr2)
        {
            // Temporary variable
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        /// <summary>
        /// Sort jagged array by line by ascend
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="comparer">The comparer</param>
        public static void BubbleSortAscending(this int[][] array, IComparer<int[]> comparer)
        {
            BubbleSortAscending(array, comparer.Compare);
        }

        /// <summary>
        /// Sort jagged array by line by ascend
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        /// <param name="compare">Function which used as criterion</param>
        public static void BubbleSortAscending(this int[][] jaggedArray, Func<int[], int[], int> compare)
        {
            if (jaggedArray == null || compare == null || jaggedArray.Length == 0)
            {
                throw new NullReferenceException("Null input");
            }

            if (jaggedArray.Length == 1)
            {
                return;
            }

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i; j++)
                {
                    if (compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sort jagged array by line by descend
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="comparer">The comparer</param>
        public static void BubbleSortDescending(this int[][] array, IComparer<int[]> comparer)
        {
            BubbleSortAscending(array, comparer.Compare);
        }

        /// <summary>
        /// Sort jagged array by line by descend
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        /// <param name="compare">Function which used as criterion</param>
        public static void BubbleSortDescending(this int[][] jaggedArray, Func<int[], int[], int> compare)
        {
            if (jaggedArray == null || compare == null || jaggedArray.Length == 0)
            {
                throw new NullReferenceException("Null input");
            }

            if (jaggedArray.Length == 1)
            {
                return;
            }

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i; j++)
                {
                    if (compare(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Class with completed exercises
    /// </summary>
    public static class JaggedArrayTwo
    {

        /// <summary>
        /// Swap two arrays
        /// </summary>
        /// <param name="arr1">First array</param>
        /// <param name="arr2">Second array</param>
        public static void Swap(ref int[] arr1, ref int[] arr2)
        {
            // Temporary variable
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        /// <summary>
        /// Sort jagged array by line by ascend
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="comparison">The comparison</param>
        public static void BubbleSortAscending(this int[][] array, Func<int[], int[], int> comparison)
        {
            Contactor contactor = new Contactor(comparison);
            BubbleSortAscending(array, contactor);
        }

        /// <summary>
        /// Sort jagged array by line by ascend
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        /// <param name="compare">Function which used as criterion</param>
        public static void BubbleSortAscending(this int[][] jaggedArray, IComparer<int[]> compare)
        {
            if (jaggedArray == null || compare == null || jaggedArray.Length == 0)
            {
                throw new NullReferenceException("Null input");
            }

            if (jaggedArray.Length == 1)
            {
                return;
            }

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i; j++)
                {
                    if (compare.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sort jagged array by line by descend
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="comparison">The comparison</param>
        public static void BubbleSortDescending(this int[][] array, Func<int[], int[], int> comparison)
        {
            Contactor contactor = new Contactor(comparison);
            BubbleSortDescending(array, contactor);
        }

        /// <summary>
        /// Sort jagged array by line by descend
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        /// <param name="compare">Function which used as criterion</param>
        public static void BubbleSortDescending(this int[][] jaggedArray, IComparer<int[]> compare)
        {
            if (jaggedArray == null || compare == null || jaggedArray.Length == 0)
            {
                throw new NullReferenceException("Null input");
            }

            if (jaggedArray.Length == 1)
            {
                return;
            }

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i; j++)
                {
                    if (compare.Compare(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Сloses a variable
        /// </summary>
        public class Contactor : IComparer<int[]>
        {
            private readonly Func<int[], int[], int> comparison;

            /// <summary>
            /// Intializes a new instance of the <seealso cref="Contactor"/> class.
            /// </summary>
            /// <param name="comparison">The comparison</param>
            public Contactor(Func<int[], int[], int> comparison)
            {
                this.comparison = comparison;
            }

            /// <inheritdoc/>
            public int Compare(int[] first, int[] second)
            {
                return this.comparison(first, second);
            }
        }
    }
}

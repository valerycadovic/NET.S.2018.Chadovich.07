namespace Day9.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Set of methods which are extending jagged arrays if <see cref="int"/>
    /// </summary>
    public static class JaggedArrayDelegateHelper
    {
        /// <summary>
        /// Sorts jagged array of <see cref="int"/> in accordance with preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array to be sorted.</param>
        /// <param name="comparer">The comarison delegate.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when jagged array or comparer is null
        /// </exception>
        public static void Sort(this int[][] jaggedArray, IComparer<int[]> comparer)
        {
            jaggedArray.Sort(comparer, 0);
        }

        /// <summary>
        /// Sorts jagged array of <see cref="int"/> in accordance with preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array to be sorted.</param>
        /// <param name="comparer">The comarison delegate.</param>
        /// <param name="index">The start sorting index.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when index is out of bounds of jagged array
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when jagged array or comparer is null
        /// </exception>
        public static void Sort(this int[][] jaggedArray, IComparer<int[]> comparer, int index)
        {
            ValidateIsNull(jaggedArray);
            jaggedArray.Sort(comparer, index, jaggedArray.Length - index);
        }

        /// <summary>
        /// Sorts jagged array of <see cref="int"/> in accordance with preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array to be sorted.</param>
        /// <param name="comparer">The comarison delegate.</param>
        /// <param name="index">The start sorting index.</param>
        /// <param name="length">The sorting length beginning with the index.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when index or length is out of bounds of jagged array
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when jagged array or comparer is null
        /// </exception>
        public static void Sort(this int[][] jaggedArray, IComparer<int[]> comparer, int index, int length)
        {
            ValidateIsNull(comparer);

            jaggedArray.Sort(comparer.Compare, index, length);
        }

        /// <summary>
        /// Sorts the specified compare.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// Throws when index or length is out of bounds of jagged array
        /// <exception cref="ArgumentNullException">
        /// Throws when jagged array or compare is null
        /// </exception>
        public static void Sort(this int[][] jaggedArray, Comparison<int[]> compare)
        {
            jaggedArray.Sort(compare, 0);
        }

        /// <summary>
        /// Sorts the specified compare.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="index">The index.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when index is out of bounds of jagged array
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when jagged array or compare is null
        /// </exception>
        public static void Sort(this int[][] jaggedArray, Comparison<int[]> compare, int index)
        {
            ValidateIsNull(jaggedArray);
            jaggedArray.Sort(compare, index, jaggedArray.Length - index);
        }

        /// <summary>
        /// Sorts jagged array of <see cref="int"/> in accordance with preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array to be sorted.</param>
        /// <param name="compare">The comarison delegate.</param>
        /// <param name="index">The start sorting index.</param>
        /// <param name="length">The sorting length beginning with the index.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when index or length is out of bounds of jagged array
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when jagged array or compare is null
        /// </exception>
        public static void Sort(this int[][] jaggedArray, Comparison<int[]> compare, int index, int length)
        {
            ValidateIsNull(jaggedArray);
            ValidateIsNull(compare);
            ValidateBorders(jaggedArray, index, length);

            for (int i = index; i < index + length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Swaps two integer array references
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Validates the borders.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// index or length is out of bounds
        /// </exception>
        private static void ValidateBorders(int[][] jaggedArray, int index, int length)
        {
            if (index < 0 || index >= jaggedArray.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} is out of range");
            }

            if (length <= 0 || index + length > jaggedArray.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(length)} is out of range");
            }
        }

        /// <summary>
        /// Validates the is null.
        /// </summary>
        /// <typeparam name="T">Type of validating object</typeparam>
        /// <param name="obj">The object.</param>
        /// <exception cref="ArgumentNullException">throws when the object is null</exception>
        private static void ValidateIsNull<T>(T obj) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{nameof(obj)}");
            }
        }
    }
}

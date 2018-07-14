namespace Day9
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Jagged Array Extension Methods
    /// </summary>
    public static class JaggedArrayHelper
    {
        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="index">The start index.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or comparer is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// index is out of bounds
        /// </exception>
        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer, int index)
        {
            ValidateIsNull(jaggedArray);
            jaggedArray.BubbleSort(comparer, index, jaggedArray.Length);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or comparer is null</exception>
        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer)
        {
            ValidateIsNull(jaggedArray);
            jaggedArray.BubbleSort(comparer, 0, jaggedArray.Length);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="index">The start index.</param>
        /// <param name="length">The offset.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or comparer is null</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// index or length is out of bounds
        /// </exception>
        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer, int index, int length)
        {
            ValidateIsNull(jaggedArray);
            ValidateIsNull(comparer);
            ValidateBorders(jaggedArray, index, length);

            for (int i = index; i < index + length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1; j++)
                {
                    if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
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

namespace Day9.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Jagged Array Extension Methods
    /// </summary>
    public static class JaggedArrayInterfaceHelper
    {
        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or compare is null</exception>
        public static void BubbleSortFunc(this int[][] jaggedArray, Func<int[], int[], int> compare)
        {
            ValidateIsNull(jaggedArray);

            IComparer<int[]> comparer = new FuncMethodAdapter(compare);

            jaggedArray.BubbleSort(comparer, 0);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="index">The index.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or compare is null</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// index is out of bounds
        /// </exception>
        public static void BubbleSortFunc(this int[][] jaggedArray, Func<int[], int[], int> compare, int index)
        {
            ValidateIsNull(jaggedArray);

            IComparer<int[]> comparer = new FuncMethodAdapter(compare);

            jaggedArray.BubbleSort(comparer, index, jaggedArray.Length - index);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or compare is null</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// index or length is out of bounds
        /// </exception>
        public static void BubbleSortFunc(this int[][] jaggedArray, Func<int[], int[], int> compare, int index, int length)
        {
            IComparer<int[]> comparer = new FuncMethodAdapter(compare);

            jaggedArray.BubbleSort(comparer, index, length);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <exception cref="ArgumentNullException">
        /// throws when jagged array or compare is null
        /// </exception>
        public static void BubbleSort(this int[][] jaggedArray, Comparison<int[]> compare)
        {
            jaggedArray.BubbleSort(compare, 0);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="index">The index.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or compare is null</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// index is out of bounds
        /// </exception>
        public static void BubbleSort(this int[][] jaggedArray, Comparison<int[]> compare, int index)
        {
            ValidateIsNull(jaggedArray);
            jaggedArray.BubbleSort(compare, index, jaggedArray.Length - index);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or compare is null</exception>
        /// /// <exception cref="ArgumentOutOfRangeException">
        /// index or length is out of bounds
        /// </exception>
        public static void BubbleSort(this int[][] jaggedArray, Comparison<int[]> compare, int index, int length)
        {
            ValidateIsNull(compare);
            jaggedArray.BubbleSort(Comparer<int[]>.Create(compare), index, length);
        }

        /// <summary>
        /// Sorts arrays inside of integer jagged array by preset comparer
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">throws when jagged array or comparer is null</exception>
        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer)
        {
            jaggedArray.BubbleSort(comparer, 0);
        }

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
            jaggedArray.BubbleSort(comparer, index, jaggedArray.Length - index);
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
                bool swapped = false;
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
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

        /// <inheritdoc />
        /// <summary>
        /// Adapter classs for <see cref="Func{int[], int[], int}"/> compatibility with <see cref="IComparer{int[]}"/>
        /// </summary>
        /// <seealso cref="T:System.Collections.Generic.IComparer`1" />
        private class FuncMethodAdapter : IComparer<int[]>
        {
            /// <summary>
            /// The adaptee.
            /// </summary>
            private readonly Func<int[], int[], int> compare;

            /// <summary>
            /// Initializes a new instance of the <see cref="FuncMethodAdapter"/> class.
            /// </summary>
            /// <param name="func">The adaptee function.</param>
            /// <exception cref="ArgumentNullException">Throws when func is null</exception>
            public FuncMethodAdapter(Func<int[], int[], int> func)
            {
                this.compare = func ?? throw new ArgumentNullException($"{nameof(func)} is null");
            }

            /// <inheritdoc />
            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>
            /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero
            /// <paramref name="x" /> is less than <paramref name="y" />.Zero
            /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero
            /// <paramref name="x" /> is greater than <paramref name="y" />.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                return compare(x, y);
            }
        }
    }
}

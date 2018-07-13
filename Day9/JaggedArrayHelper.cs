using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public static class JaggedArrayHelper
    {
        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer, int index) =>
            jaggedArray.BubbleSort(comparer, index, jaggedArray.Length);

        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer) =>
            jaggedArray.BubbleSort(comparer, 0, jaggedArray.Length);

        public static void BubbleSort(this int[][] jaggedArray, IComparer<int[]> comparer, int index, int length)
        {
            ValidateIsNull(jaggedArray);
            ValidateBorders(jaggedArray, index, length);

            for (int i = index; i < index + length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length - 1; j++)
                {
                    if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1]) > 1)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

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

        private static void ValidateIsNull(int[][] jaggedArray)
        {
            if (jaggedArray is null)
            {
                throw new ArgumentNullException($"{nameof(jaggedArray)}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class MaxValueComparer : JaggedArrayComparer
    {
        public MaxValueComparer() : this(new NullBiggerThanEmptyComparer()) { }

        public MaxValueComparer(IComparer<int[]> nullOrEmptyComparer) : base (nullOrEmptyComparer) { }

        protected override long Dimension(int[] array)
        {
            int result = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > result)
                {
                    result = array[i];
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class MinValueComparer : JaggedArrayComparer
    {
        public MinValueComparer() : this(new NullBiggerThanEmptyComparer()) { }

        public MinValueComparer(IComparer<int[]> nullOrEmptyComparer) : base (nullOrEmptyComparer) { }

        protected override long Dimension(int[] array)
        {
            int result = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < result)
                {
                    result = array[i];
                }
            }

            return result;
        }
    }
}

namespace Day9
{
    using System.Collections.Generic;

    public class SumComparer : JaggedArrayComparer
    {
        public SumComparer() : this(new NullBiggerThanEmptyComparer()) { }

        public SumComparer(IComparer<int[]> nullOrEmptyComparer) : base(nullOrEmptyComparer) { }

        protected override long Dimension(int[] array)
        {
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public abstract class JaggedArrayComparer : IComparer<int[]>
    {
        protected IComparer<int[]> NullOrEmptyComparer { get; }

        protected JaggedArrayComparer(IComparer<int[]> nullOrEmptyComparer)
        {
            this.NullOrEmptyComparer = nullOrEmptyComparer;
        }

        public int Compare(int[] x, int[] y)
        {
            int nullOrEmptyComparison = this.NullOrEmptyComparer.Compare(x, y);

            if (nullOrEmptyComparison != (int)NullOrEmptyComparisonResult.NoNullsAndEmpties)
            {
                return nullOrEmptyComparison;
            }

            long dimensionX = this.Dimension(x);
            long dimensionY = this.Dimension(y);

            if (dimensionX > dimensionY)
            {
                return 1;
            }

            if (dimensionX < dimensionY)
            {
                return -1;
            }

            return 0;
        }

        protected abstract long Dimension(int[] array);
    }
}

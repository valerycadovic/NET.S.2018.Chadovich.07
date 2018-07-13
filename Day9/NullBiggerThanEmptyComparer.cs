using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class NullBiggerThanEmptyComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x is null && y is null)
            {
                return (int) NullOrEmptyComparisonResult.Equals;
            }

            if (x is null)
            {
                return (int) NullOrEmptyComparisonResult.FirstIsBigger;
            }

            if (y is null)
            {
                return (int) NullOrEmptyComparisonResult.SecondIsBigger;
            }

            if (x.Length == 0 && y.Length == 0)
            {
                return (int) NullOrEmptyComparisonResult.Equals;
            }

            if (x.Length == 0)
            {
                return (int) NullOrEmptyComparisonResult.FirstIsBigger;
            }

            if (y.Length == 0)
            {
                return (int) NullOrEmptyComparisonResult.SecondIsBigger;
            }

            return (int) NullOrEmptyComparisonResult.NoNullsAndEmpties;
        }
    }
}

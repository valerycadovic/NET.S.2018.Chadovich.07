using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal enum NullOrEmptyComparisonResult
    {
        FirstIsBigger = 1,
        Equals = 0,
        SecondIsBigger = -1,
        NoNullsAndEmpties = -2
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day9;

namespace Day9.Tests
{
    [TestFixture]
    public class NullBiggerThanEmptyComparer_Tests
    {
        private readonly IComparer<int[]> comparer = new NullBiggerThanEmptyComparer();

        [TestCase(null, null, 0)]
        [TestCase(new int[] { }, null, -1)]
        [TestCase(null, new int[] { }, 1)]
        [TestCase(new int[] { }, new int[] { }, 0)]
        [TestCase(null, new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, null, -1)]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, -1)]
        [TestCase(new int[]{1, 2, 3}, new int[]{2, 3, 4}, -2)]
        public void Can_Compare(int[] lhs, int[] rhs, int value)
        {
            Assert.IsTrue(comparer.Compare(lhs, rhs) == value);
        }
    }
}

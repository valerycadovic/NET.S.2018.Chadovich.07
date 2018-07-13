using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Day9.Tests
{
    [TestFixture]
    public class SumComparer_Tests
    {
        private readonly IComparer<int[]> comparer = new SumComparer();

        [TestCase(null, null, 0)]
        [TestCase(null, new int[] { }, 1)]
        [TestCase(new int[] { }, null, -1)]
        [TestCase(new int[] { }, new int[] { }, 0)]
        [TestCase(null, new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, null, -1)]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 5, 2, 4 }, -1)]
        [TestCase(new int[] { 5, 2, 5, 6, 6 }, new int[] { 3, 2, -1 }, 1)]
        [TestCase(new int[] { 5, 10 }, new int[] { 5, 5, 5, -5, 5, -5, 2, 3 }, 0)]
        public void Can_Compare(int[] lhs, int[] rhs, int value)
        {
            Assert.IsTrue(comparer.Compare(lhs, rhs) == value);
        }
    }
}

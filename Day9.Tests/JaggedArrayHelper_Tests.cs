using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day9;

namespace Day9.Tests
{
    [TestFixture]
    public class JaggedArrayHelper_Tests
    {
        [Test]
        public void Can_BubbleSort_By_Sums_Ascending()
        {
            int[][] actual = new int[8][];

            actual[0] = new int[] { 1, 3, 4, 5, 6 };            // 19
            actual[1] = new int[] { -7, 7, 3, 7, 7, 12, 4 };    // 33
            actual[2] = new int[] { 3 };                        // 3
            actual[3] = new int[] { };
            actual[4] = new int[] { int.MaxValue, int.MinValue, int.MaxValue }; // int.MaxValue
            actual[5] = new int[] { int.MinValue, int.MaxValue, int.MinValue }; // int.MinValue
            actual[6] = null;
            actual[7] = new int[] { 4, 3, 5, 234 };             // 246

            int[][] expected = new int[8][];

            expected[0] = actual[5];
            expected[1] = actual[2];
            expected[2] = actual[0];
            expected[3] = actual[1];
            expected[4] = actual[7];
            expected[5] = actual[4];
            expected[6] = actual[3];
            expected[7] = actual[6];

            IComparer<int[]> comparer = new SumComparer();
            actual.BubbleSort(comparer);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_BubbleSort_By_MaxValues_Ascending()
        {
            int[][] actual = new int[8][];

            actual[0] = new int[] { 1, 3, 4, 5, 6 };            // 6
            actual[1] = new int[] { -7, 7, 3, 7, 7, 12, 4 };    // 12
            actual[2] = new int[] { 3 };                        // 3
            actual[3] = new int[] { };
            actual[4] = new int[] { int.MaxValue, int.MinValue, int.MaxValue }; // int.MaxValue
            actual[5] = new int[] { int.MinValue, int.MinValue, int.MinValue }; // int.MinValue
            actual[6] = null;
            actual[7] = new int[] { 4, 3, 5, 234 };             // 234

            int[][] expected = new int[8][];

            expected[0] = actual[5];
            expected[1] = actual[2];
            expected[2] = actual[0];
            expected[3] = actual[1];
            expected[4] = actual[7];
            expected[5] = actual[4];
            expected[6] = actual[3];
            expected[7] = actual[6];

            IComparer<int[]> comparer = new MaxValueComparer();
            actual.BubbleSort(comparer);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Can_BubbleSort_By_MinValue_Ascending()
        {
            int[][] actual = new int[8][];

            actual[0] = new int[] { 1, 3, 4, 5, 6 };            // 1
            actual[1] = new int[] { -7, 7, 3, 7, 7, 12, 4 };    // -7
            actual[2] = new int[] { 3 };                        // 3
            actual[3] = new int[] { };
            actual[4] = new int[] { int.MaxValue, int.MaxValue, int.MaxValue }; // int.MaxValue
            actual[5] = new int[] { int.MinValue, int.MaxValue, int.MinValue }; // int.MinValue
            actual[6] = null;
            actual[7] = new int[] { 4, 3, 5, 234 };             // 3

            int[][] expected = new int[8][];

            expected[0] = actual[5];
            expected[1] = actual[1];
            expected[2] = actual[0];
            expected[3] = actual[2];
            expected[4] = actual[7];
            expected[5] = actual[4];
            expected[6] = actual[3];
            expected[7] = actual[6];

            IComparer<int[]> comparer = new MinValueComparer();
            actual.BubbleSort(comparer);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BubbleSort_Throws_ArgumentNullException_If_JaggedArray_Is_Null() =>
            Assert.Throws<ArgumentNullException>(() => JaggedArrayHelper.BubbleSort(null, new MaxValueComparer()));

        [Test]
        public void BubbleSort_Throws_ArgumentNullException_If_Comparer_Is_Null() =>
            Assert.Throws<ArgumentNullException>(() => new int[1][].BubbleSort(null));

        [TestCase(-1, 10)]
        [TestCase(1, 15)]
        [TestCase(2, -4)]
        [TestCase(23, 2)]
        public void BubbleSort_Throws_ArgumentOutOfRangeException_If_Index_Or_Length_Are_Invalid(int index, int length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int[][] actual = new int[3][];

                actual[0] = new int[] { 1, 3, 4, 5, 6 };            
                actual[1] = new int[] { -7, 7, 3, 7, 7, 12, 4 };    
                actual[2] = new int[] { 3 };

                actual.BubbleSort(new MaxValueComparer(), index, length);
            });
        }
    }
}

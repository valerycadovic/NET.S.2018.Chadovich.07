namespace Day9
{
    /// <inheritdoc />
    /// <summary>
    /// Compares two arrays by their elements sums
    /// </summary>
    /// <seealso cref="T:Day9.JaggedArrayComparer" />
    public class SumComparer : JaggedArrayComparer
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Day9.SumComparer" /> class.
        /// </summary>
        public SumComparer() : this(new NullBiggerThanEmptyComparer())
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Day9.SumComparer" /> class.
        /// </summary>
        /// <param name="nullOrEmptyComparer">The null or empty comparer.</param>
        public SumComparer(NullAndEmptyComparer nullOrEmptyComparer) : base(nullOrEmptyComparer)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Dimension which implements comparison condition
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// Result of dimension
        /// </returns>
        protected override long Dimension(int[] array)
        {
            long result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}

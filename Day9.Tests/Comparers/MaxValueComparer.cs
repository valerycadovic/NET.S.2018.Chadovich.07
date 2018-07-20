namespace Day9.Tests.Comparers
{
    /// <inheritdoc />
    /// <summary>
    /// Compares two arrays by their max values
    /// </summary>
    /// <seealso cref="T:Day9.JaggedArrayComparer" />
    public class MaxValueComparer : JaggedArrayComparer
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Day9.MaxValueComparer" /> class.
        /// </summary>
        public MaxValueComparer() : this(new NullBiggerThanEmptyComparer())
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Day9.MaxValueComparer" /> class.
        /// </summary>
        /// <param name="nullOrEmptyComparer">The null or empty comparer.</param>
        public MaxValueComparer(NullAndEmptyComparer nullOrEmptyComparer) : base(nullOrEmptyComparer)
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

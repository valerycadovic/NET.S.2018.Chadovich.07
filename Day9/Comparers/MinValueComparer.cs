namespace Day9
{
    /// <inheritdoc />
    /// <summary>
    /// Compares two arrays by their min values
    /// </summary>
    /// <seealso cref="T:Day9.JaggedArrayComparer" />
    public class MinValueComparer : JaggedArrayComparer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinValueComparer"/> class.
        /// </summary>
        public MinValueComparer() : this(new NullBiggerThanEmptyComparer())
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Day9.MinValueComparer" /> class.
        /// </summary>
        /// <param name="nullOrEmptyComparer">The null or empty comparer.</param>
        public MinValueComparer(NullAndEmptyComparer nullOrEmptyComparer) : base(nullOrEmptyComparer)
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
                if (array[i] < result)
                {
                    result = array[i];
                }
            }

            return result;
        }
    }
}

namespace Day9
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines base arrays comparison template
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{int[]}" />
    public abstract class JaggedArrayComparer : IComparer<int[]>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JaggedArrayComparer"/> class.
        /// </summary>
        /// <param name="nullOrEmptyComparer">The null or empty comparer.</param>
        protected JaggedArrayComparer(NullAndEmptyComparer nullOrEmptyComparer)
        {
            this.nullOrEmptyComparer = nullOrEmptyComparer;
        }

        /// <summary>
        /// Gets how to do with nulls and empty arrays
        /// </summary>
        /// <value>
        /// The null or empty comparer.
        /// </value>
        private readonly NullAndEmptyComparer nullOrEmptyComparer;

        /// <inheritdoc />
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.Zero
        /// <paramref name="x" /> equals <paramref name="y" />.Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            int nullOrEmptyComparison = this.nullOrEmptyComparer.Compare(x, y);

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

        /// <summary>
        /// Dimension which implements comparison condition
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Result of dimension</returns>
        protected abstract long Dimension(int[] array);
    }
}

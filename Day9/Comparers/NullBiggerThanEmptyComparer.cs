namespace Day9
{
    /// <inheritdoc />
    /// <summary>
    /// Defines an order of nulls and empty arrays comparison
    /// where null has the highest priority and empty arrays go after them 
    /// </summary>
    /// <seealso cref="T:Day9.NullAndEmptyComparer" />
    public class NullBiggerThanEmptyComparer : NullAndEmptyComparer
    {
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
        public override int Compare(int[] x, int[] y)
        {
            if (x is null && y is null)
            {
                return (int)NullOrEmptyComparisonResult.Equals;
            }

            if (x is null)
            {
                return (int)NullOrEmptyComparisonResult.FirstIsBigger;
            }

            if (y is null)
            {
                return (int)NullOrEmptyComparisonResult.SecondIsBigger;
            }

            if (x.Length == 0 && y.Length == 0)
            {
                return (int)NullOrEmptyComparisonResult.Equals;
            }

            if (x.Length == 0)
            {
                return (int)NullOrEmptyComparisonResult.FirstIsBigger;
            }

            if (y.Length == 0)
            {
                return (int)NullOrEmptyComparisonResult.SecondIsBigger;
            }

            return (int)NullOrEmptyComparisonResult.NoNullsAndEmpties;
        }
    }
}

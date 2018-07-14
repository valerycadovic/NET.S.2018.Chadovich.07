namespace Day9
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// Abstract class which defines a comparison protocol fo empty arrays and nulls
    /// </summary>
    /// <seealso cref="T:System.Collections.Generic.IComparer`1" />
    public abstract class NullAndEmptyComparer : IComparer<int[]>
    {
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
        public abstract int Compare(int[] x, int[] y);
    }
}

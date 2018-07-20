namespace Day9.Tests.Internals
{
    /// <summary>
    /// Result of arrays comparison of empty arrays and nulls
    /// </summary>
    internal enum NullOrEmptyComparisonResult
    {
        /// <summary>
        /// The first is bigger
        /// </summary>
        FirstIsBigger = 1,

        /// <summary>
        /// Arrays are equal
        /// </summary>
        Equals = 0,

        /// <summary>
        /// The second is bigger
        /// </summary>
        SecondIsBigger = -1,

        /// <summary>
        /// There are no nulls and empty arrays
        /// </summary>
        NoNullsAndEmpties = -2
    }
}

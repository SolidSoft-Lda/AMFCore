namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Reversible container.
    /// </summary>
    /// <remarks>
    /// Reversible container can be traversed from end to beginning.
    /// </remarks>
    public interface IReversible : System.Collections.IEnumerable
    {
        /// <summary>
        /// Gets enumerable that traverses the container in reversed order.
        /// </summary>
        /// <example>
        /// IReversible container = ...;
        /// foreach (object obj in container.Reversed) ...;
        /// </example>
        System.Collections.IEnumerable Reversed { get; }
    }
}
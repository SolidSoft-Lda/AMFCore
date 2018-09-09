namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Write-only forward-only iterator.
    /// </summary>
    /// <remarks>
    /// <p>.NET has built-in abstraction for read-only forward-only iterator, which is
    /// <c>IEnumerator</c>. Parallel concept in STL is "input iterator".
    /// Unfortunately, there is no built-in abstraction for	write-only, forward-only behavior,
    /// a.k.a output iterator.</p>
    /// <p>Objects are written to the output iterator one by one using <c>Add</c> method.
    /// There is no way to retrieve added object or undo the addition.</p>
    /// </remarks>
    public interface IOutputIterator
    {
        /// <summary>
        /// Adds an object to the output.
        /// </summary>
        /// <remarks>
        /// <c>Add()</c> can put an object in the end of a collection, or in the beginning
        /// of a collection, or output a string representatino of the object to
        /// a named pipe, etc.
        /// </remarks>
        void Add(object obj);
    }
}
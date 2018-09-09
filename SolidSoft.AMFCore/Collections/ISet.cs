namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Sorted set or multiset of objects.
    /// </summary>
    /// <remarks>
    /// ISet represents a modifiable collection of objects that are sorted in 
    /// ascending order to given Comparer. Derived classes may or may not
    /// permit duplicate (equivalent) objects.
    /// </remarks>
    public interface ISet : IModifiableCollection, IReversible
    {
        /// <summary>
        /// Returns comparer object used by the set.
        /// </summary>
        System.Collections.IComparer Comparer { get; }
    }
}
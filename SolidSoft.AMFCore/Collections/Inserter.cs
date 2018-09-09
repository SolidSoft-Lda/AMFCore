namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// <see cref="IOutputIterator">Output iterator</see> based on <see cref="IModifiableCollection.Add">IModifiableCollection.Add.</see>
    /// </summary>
    class Inserter : IOutputIterator
    {
        IModifiableCollection _collection;

        /// <summary>
        /// Creates instance of inserter for given modifiable collection.
        /// </summary>
        public Inserter(IModifiableCollection collection)
        {
            _collection = collection;
        }

        #region IOutputIterator Members

        /// <summary>
        /// Adds passed object to the collection.
        /// </summary>
        public void Add(object obj)
        {
            _collection.Add(obj);
        }

        #endregion
    }
}
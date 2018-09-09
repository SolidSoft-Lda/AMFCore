using System;
using System.Collections;
using System.Threading;

namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Implements a read-only collection.
    /// </summary>
    public class ReadOnlyCollection : ICollection, IEnumerable
    {
        ICollection _collection;
        object _syncRoot;

        /// <summary>
        /// Creates a ReadOnlyCollection wrapper for a specific collection.
        /// </summary>
        /// <param name="collection">The collection to wrap.</param>
        public ReadOnlyCollection(ICollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("list");
            _collection = collection;
        }


        #region ICollection Members

        /// <summary>
        /// Copies the elements of the ReadOnlyCollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ReadOnlyCollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            _collection.CopyTo(array, index);
        }
        /// <summary>
        /// Gets the number of elements contained in the ReadOnlyCollection.
        /// </summary>
        public int Count
        {
            get { return _collection.Count; }
        }
        /// <summary>
        /// Gets a value indicating whether access to the ReadOnlyCollection is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }
        /// <summary>
        /// Gets an object that can be used to synchronize access to the ReadOnlyCollection.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    if (_collection != null)
                        _syncRoot = _collection.SyncRoot;
                    else
                        Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through an ReadOnlyCollection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.Collections.Generic
{
    /// <summary>
    /// A Set that uses CopyOnWriteArray for all of its operations. Thus, it shares the same basic properties:
    /// It is best suited for applications in which set sizes generally stay small, read-only operations vastly outnumber mutative operations, and you need to prevent interference among threads during traversal.
    /// It is thread-safe.
    /// Mutative operations(add, set, remove, etc) are expensive since they usually entail copying the entire underlying array.
    /// Traversal via enumerators is fast and cannot encounter interference from other threads. Enumerators rely on unchanging snapshots of the array at the time the enumerators were constructed.
    /// </summary>
    public class CopyOnWriteArraySet<T> : ICollection<T>, ICollection
    {
        private CopyOnWriteArray<T> _array;

        /// <summary>
        /// Creates an empty set.
        /// </summary>
        public CopyOnWriteArraySet()
        {
            _array = new CopyOnWriteArray<T>();
        }
        /// <summary>
        /// Creates a set containing all of the elements of the specified collection.
        /// </summary>
        /// <param name="collection"></param>
        public CopyOnWriteArraySet(ICollection collection)
        {
            _array = new CopyOnWriteArray<T>();
            foreach (object obj in collection)
                _array.Add((T)obj);
        }

        #region ICollection<T> Members

        /// <summary>
        /// Adds the specified element to this set if it is not already present.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Add(T item)
        {
            if (!_array.Contains(item))
            {
                _array.Add(item);
            }
        }
        /// <summary>
        /// Removes all of the elements from this set.
        /// </summary>
        public void Clear()
        {
            _array.Clear();
        }
        /// <summary>
        /// Determines whether the CopyOnWriteArraySet contains a specific value.
        /// </summary>
        /// <param name="item">The Object to locate in the CopyOnWriteArraySet.</param>
        /// <returns>true if the Object is found in the CopyOnWriteArraySet; otherwise, false.</returns>        
        public bool Contains(T item)
        {
            return _array.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _array.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// Removes the specified element from this set if it is present.
        /// </summary>
        /// <param name="item"></param>
        public bool Remove(T item)
        {
            return _array.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            _array.CopyTo(array, index);
        }

        public int Count
        {
            get { return _array.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return _array.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        #endregion
    }
}
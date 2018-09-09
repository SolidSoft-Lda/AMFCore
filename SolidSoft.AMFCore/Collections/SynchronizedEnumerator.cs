using System.Collections;

namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Synchronized <see cref="IEnumerator"/> that should be returned by synchronized
    /// collections in order to ensure that the enumeration is thread safe.
    /// </summary>
    internal class SynchronizedEnumerator : IEnumerator
    {
        protected object _syncRoot;
        protected IEnumerator _enumerator;

        public SynchronizedEnumerator(object syncRoot, IEnumerator enumerator)
        {
            _syncRoot = syncRoot;
            _enumerator = enumerator;
        }

        public bool MoveNext()
        {
            lock (_syncRoot)
            {
                return _enumerator.MoveNext();
            }
        }

        public void Reset()
        {
            lock (_syncRoot)
            {
                _enumerator.Reset();
            }
        }

        public object Current
        {
            get
            {
                lock (_syncRoot)
                {
                    return _enumerator.Current;
                }
            }
        }
    }
}
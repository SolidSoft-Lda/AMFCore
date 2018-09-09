using System.Collections;

namespace SolidSoft.AMFCore.Collections
{
    /// <summary>
    /// Synchronized <see cref="IDictionaryEnumerator"/> that should be returned by synchronized
    /// dictionary implementations in order to ensure that the enumeration is thread safe.
    /// </summary>
    internal class SynchronizedDictionaryEnumerator : SynchronizedEnumerator, IDictionaryEnumerator
    {
        public SynchronizedDictionaryEnumerator(object syncRoot, IDictionaryEnumerator enumerator)
            : base(syncRoot, enumerator)
        {
        }

        protected IDictionaryEnumerator Enumerator
        {
            get { return (IDictionaryEnumerator)_enumerator; }
        }

        public object Key
        {
            get
            {
                lock (_syncRoot)
                {
                    return Enumerator.Key;
                }
            }
        }

        public object Value
        {
            get
            {
                lock (_syncRoot)
                {
                    return Enumerator.Value;
                }
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                lock (_syncRoot)
                {
                    return Enumerator.Entry;
                }
            }
        }
    }
}
namespace SolidSoft.AMFCore.IO
{
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class CacheableObject
    {
        object _obj;
        string _source;
        string _cacheKey;

        /// <summary>
        /// Initializes a new instance of the CacheableObject class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        public CacheableObject(string source, string cacheKey, object obj)
        {
            _source = source;
            _cacheKey = cacheKey;
            _obj = obj;
        }

        public object Object { get { return _obj; } }
        public string CacheKey { get { return _cacheKey; } }
        public string Source { get { return _source; } }
    }
}
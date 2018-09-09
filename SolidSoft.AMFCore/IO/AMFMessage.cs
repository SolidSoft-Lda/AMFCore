using System.Collections.Generic;
using SolidSoft.AMFCore.Exceptions;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
    public class AMFMessage
	{
        /// <summary>
        /// AMF packet version.
        /// </summary>
		protected ushort _version = 0;
        /// <summary>
        /// AMF packet body values.
        /// </summary>
        protected List<AMFBody> _bodies;
        /// <summary>
        /// AMF packet headers.
        /// </summary>
        protected List<AMFHeader> _headers;

        /// <summary>
		/// Initializes a new instance of the AMFMessage class.
		/// </summary>
		public AMFMessage() : this(0)
		{
		}
		/// <summary>
		/// Initializes a new instance of the AMFMessage class.
		/// </summary>
		/// <param name="version"></param>
		public AMFMessage(ushort version)
		{
			this._version = version;
            _headers = new List<AMFHeader>(1);
            _bodies = new List<AMFBody>(1);
		}
        /// <summary>
        /// Gets the AMF packet version.
        /// </summary>
		public ushort Version
		{
			get{ return _version; }
		}
        /// <summary>
        /// Adds a body to the AMF packet.
        /// </summary>
        /// <param name="body">The body object to add.</param>
		public void AddBody(AMFBody body)
		{
			this._bodies.Add(body);
		}
        /// <summary>
        /// Adds a header to the AMF packet.
        /// </summary>
        /// <param name="header">The header object to add.</param>
		public void AddHeader(AMFHeader header)
		{
			this._headers.Add(header);
		}
        /// <summary>
        /// Gets the body count.
        /// </summary>
		public int BodyCount
		{
			get{ return _bodies.Count; }
		}

        /// <summary>
        /// Gets a readonly collection of AMF bodies.
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AMFBody> Bodies
        {
            get { return _bodies.AsReadOnly(); }
        }
        /// <summary>
		/// Gets the header count.
		/// </summary>
		public int HeaderCount
		{
			get{ return _headers.Count; }
		}
        /// <summary>
        /// Gets a single AMF body object by index.
        /// </summary>
        /// <param name="index">The numerical index of the body.</param>
        /// <returns>The body referenced by index.</returns>
		public AMFBody GetBodyAt(int index)
		{
			return _bodies[index] as AMFBody;
		}
        /// <summary>
        /// Gets a single AMF header object by index.
        /// </summary>
        /// <param name="index">The numerical index of the header.</param>
        /// <returns>The header referenced by index.</returns>
		public AMFHeader GetHeaderAt(int index)
		{
			return _headers[index] as AMFHeader;
		}
        /// <summary>
        /// Gets the value of a single AMF header object by name.
        /// </summary>
        /// <param name="header">The name of the header.</param>
        /// <returns>The header referenced by name.</returns>
		public AMFHeader GetHeader(string header)
		{
			for(int i = 0; _headers != null && i < _headers.Count; i++)
			{
				AMFHeader amfHeader = _headers[i] as AMFHeader;
				if( amfHeader.Name == header )
					return amfHeader;
			}
			return null;
		}
        /// <summary>
        /// Removes the named header from teh AMF packet.
        /// </summary>
        /// <param name="header">The name of the header.</param>
        public void RemoveHeader(string header)
        {
            for (int i = 0; _headers != null && i < _headers.Count; i++)
            {
                AMFHeader amfHeader = _headers[i] as AMFHeader;
                if (amfHeader.Name == header)
                {
                    _headers.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Gets the AMF version/encoding used for this AMF packet.
        /// </summary>
		public ObjectEncoding ObjectEncoding
		{
			get
			{
                if (_version == 0 || _version == 1)
                    return ObjectEncoding.AMF0;
                if (_version == 3)
                    return ObjectEncoding.AMF3;
                throw new UnexpectedAMF();
            }
		}
	}
}
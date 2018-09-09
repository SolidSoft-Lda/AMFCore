namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFHeader
	{
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string CredentialsHeader = "Credentials";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string ServiceBrowserHeader = "DescribeService";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string ClearedCredentials = "ClearedCredentials";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string CredentialsIdHeader = "CredentialsId";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string RequestPersistentHeader = "RequestPersistentHeader";

		object	_content;
		bool	_mustUnderstand;
		string	_name;

		/// <summary>
		/// Initializes a new instance of the AMFHeader class.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="mustUnderstand"></param>
		/// <param name="content"></param>
		public AMFHeader(string name, bool mustUnderstand, object content)
		{
			this._name = name;
			this._mustUnderstand = mustUnderstand;
			this._content = content;
		}
        /// <summary>
        /// Gets the header name.
        /// </summary>
		public string Name
		{
			get{ return _name; }
		}
        /// <summary>
        /// Gets the header content.
        /// </summary>
		public object Content
		{
			get{ return _content; }
		}
        /// <summary>
        /// If a header is sent to the Flash Player with must understand set to true and the NetConnection instance's client object does not have a method to handle the header, then the Flash Player will invoke the onStatus handler on the NetConnection object.
        /// </summary>
		public bool MustUnderstand
		{
			get{ return _mustUnderstand; }
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public bool IsClearedCredentials
		{
			get
			{
				if( _content is string )
					return (string)_content == AMFHeader.ClearedCredentials;
				return false;
			}
		}
	}
}
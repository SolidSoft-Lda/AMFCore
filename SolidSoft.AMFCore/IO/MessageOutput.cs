namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
    public class MessageOutput : AMFMessage
	{
		/// <summary>
		/// Initializes a new instance of the MessageOutput class.
		/// </summary>
		public MessageOutput():this(0)
		{
		}
		/// <summary>
		/// Initializes a new instance of the MessageOutput class.
		/// </summary>
		/// <param name="version"></param>
		public MessageOutput(ushort version):base(version)
		{
		}

        
        public bool ContainsResponse(AMFBody requestBody)
		{
			return GetResponse(requestBody) != null;
		}

        
        public ResponseBody GetResponse(AMFBody requestBody)
		{
			for(int i = 0; i < _bodies.Count; i++)
			{
				ResponseBody responseBody = _bodies[i] as ResponseBody;
				if( responseBody.RequestBody == requestBody )
					return responseBody;
			}
			return null;
		}
	}
}
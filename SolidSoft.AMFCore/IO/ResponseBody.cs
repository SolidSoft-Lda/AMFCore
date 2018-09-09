using System.Collections;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
	public class ResponseBody : AMFBody
	{
		AMFBody	_requestBody;

		/// <summary>
		/// Initializes a new instance of the ResponseBody class.
		/// </summary>
		internal ResponseBody()
		{
		}
		/// <summary>
		/// Initializes a new instance of the ResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		public ResponseBody(AMFBody	requestBody)
		{
			_requestBody = requestBody;
		}
		/// <summary>
		/// Initializes a new instance of the ResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="content"></param>
		public ResponseBody(AMFBody	requestBody, object content)
		{
			_requestBody = requestBody;
			_target = requestBody.Response + AMFBody.OnResult;
			_content = content;
			_response = "null";
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public AMFBody RequestBody
		{
			get{ return _requestBody; }
			set{ _requestBody = value; }
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public override IList GetParameterList()
		{
			if( _requestBody == null )
				return null;

			return _requestBody.GetParameterList ();
		}
	}
}
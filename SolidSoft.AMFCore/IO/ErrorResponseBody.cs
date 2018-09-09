using System;
using System.Collections;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ErrorResponseBody : ResponseBody
	{
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		private ErrorResponseBody()
		{
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="error"></param>
		public ErrorResponseBody(AMFBody requestBody, string error):base(requestBody)
		{
			this.IgnoreResults = requestBody.IgnoreResults;
			this.Target = requestBody.Response + AMFBody.OnStatus;
			this.Response = null;
			this.Content = error;
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="exception"></param>
		public ErrorResponseBody(AMFBody requestBody, Exception exception):base(requestBody)
		{
			this.Content = exception;
			if( requestBody.IsEmptyTarget )
			{
				object content = requestBody.Content;
				if( content is IList )
					content = (content as IList)[0];
				IMessage message = content as IMessage;
				//Check for Flex2 messages and handle
				if( message != null )
				{
					ErrorMessage errorMessage = ErrorMessage.GetErrorMessage(message, exception);
					this.Content = errorMessage;
				}
			}
			this.IgnoreResults = requestBody.IgnoreResults;
            this.Target = requestBody.Response + AMFBody.OnStatus;
			this.Response = null;
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="message"></param>
		/// <param name="exception"></param>
		public ErrorResponseBody(AMFBody requestBody, IMessage message, Exception exception):base(requestBody)
		{
			ErrorMessage errorMessage = ErrorMessage.GetErrorMessage(message, exception);
			this.Content = errorMessage;
            this.Target = requestBody.Response + AMFBody.OnStatus;
			this.IgnoreResults = requestBody.IgnoreResults;
			this.Response = "";
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="message"></param>
		/// <param name="errorMessage"></param>
		public ErrorResponseBody(AMFBody requestBody, IMessage message, ErrorMessage errorMessage):base(requestBody)
		{
			this.Content = errorMessage;
            this.Target = requestBody.Response + AMFBody.OnStatus;
			this.IgnoreResults = requestBody.IgnoreResults;
			this.Response = "";
		}
	}
}
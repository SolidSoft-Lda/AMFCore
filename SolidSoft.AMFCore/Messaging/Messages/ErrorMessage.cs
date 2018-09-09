using System;
using System.Security;

namespace SolidSoft.AMFCore.Messaging.Messages
{
	/// <summary>
	/// The ErrorMessage class is used to report errors within the messaging system.
	/// An error message only occurs in response to a message sent within the system.
	/// </summary>
    
    public class ErrorMessage : AcknowledgeMessage
	{
        /// <summary>
        /// Client authentication fault code.
        /// </summary>
        public const string ClientAuthenticationError = "Client.Authentication";
        /// <summary>
        /// Client authorization fault code.
        /// </summary>
        public const string ClientAuthorizationError = "Client.Authorization";

		string _faultCode;
		string _faultString;
		string _faultDetail;
		object _rootCause;
		ASObject _extendedData;

		/// <summary>
		/// Initializes a new instance of the ErrorMessage class.
		/// </summary>
		public ErrorMessage()
		{
		}
		/// <summary>
		/// The fault code for the error. 
		/// This value typically follows the convention of "[outer_context].[inner_context].[issue]".
		/// 
		/// For example: "Channel.Connect.Failed", "Server.Call.Failed"
		/// </summary>
		public string faultCode
		{
			get{ return _faultCode; }
			set{ _faultCode = value; }
		}
		/// <summary>
		/// A simple description of the error.
		/// </summary>
		public string faultString
		{
			get{ return _faultString; }
			set{ _faultString = value; }
		}
		/// <summary>
		/// Detailed description of what caused the error. This is typically a stack trace from the remote destination
		/// </summary>
		public string faultDetail
		{
			get{ return _faultDetail; }
			set{ _faultDetail = value; }
		}
		/// <summary>
		/// Root cause for the error.
		/// </summary>
		public object rootCause
		{
			get{ return _rootCause; }
			set{ _rootCause = value; }
		}
        /// <summary>
        /// Extended data that the remote destination can choose to associate with this error for custom error processing on the client.
        /// </summary>
		public ASObject extendedData
		{
			get{ return _extendedData; }
			set{ _extendedData = value; }
		}

		internal static ErrorMessage GetErrorMessage(IMessage message, Exception exception)
		{
			MessageException me = null;
			if( exception is MessageException )
				me = exception as MessageException;
			else
				me = new MessageException(exception);
			ErrorMessage errorMessage = me.GetErrorMessage();
            if (message.clientId != null)
                errorMessage.clientId = message.clientId;
            else
                errorMessage.clientId = Guid.NewGuid().ToString("D");
			errorMessage.correlationId = message.messageId;
			errorMessage.destination = message.destination;
			if(exception is SecurityException)
                errorMessage.faultCode = ErrorMessage.ClientAuthenticationError;
			if(exception is UnauthorizedAccessException)
                errorMessage.faultCode = ErrorMessage.ClientAuthorizationError;
			return errorMessage;
		}
	}
}
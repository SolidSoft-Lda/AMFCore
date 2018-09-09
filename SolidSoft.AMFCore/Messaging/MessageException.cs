using System;
using SolidSoft.AMFCore.Messaging.Messages;
using SolidSoft.AMFCore.Exceptions;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// The MessageException class is used to report exceptions within the messaging system.
	/// </summary>
	public class MessageException : AMFException
	{
		ASObject _extendedData;
		string _faultCode = "Server.Processing";
		object _rootCause;

		/// <summary>
		/// Initializes a new instance of the MessageException class.
		/// </summary>
		public MessageException()
		{
			_extendedData = new ASObject();
		}
		/// <summary>
		/// Initializes a new instance of the MessageException class.
		/// </summary>
		/// <param name="extendedData">Additional information.</param>
		public MessageException(ASObject extendedData)
		{
			_extendedData = extendedData;
		}
		/// <summary>
		/// Initializes a new instance of the MessageException class.
		/// </summary>
		/// <param name="inner">Reference to the inner exception that is the cause of this exception.</param>
		public MessageException(Exception inner):base(inner.Message, inner)
		{
			_extendedData = new ASObject();
			_rootCause = inner;
		}
        /// <summary>
        /// Initializes a new instance of the MessageException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>			
        public MessageException(string message): base(message)
        {
            _extendedData = new ASObject();
        }
		/// <summary>
		/// Initializes a new instance of the AMFCoreException class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the innerException parameter is not a null reference (Nothing in Visual Basic), the current exception is raised in a catch block that handles the inner exception.</param>	
		/// <remarks>An exception that is thrown as a direct result of a previous exception should include a reference to the previous exception in the InnerException property. The InnerException property returns the same value that is passed into the constructor, or a null reference (Nothing in Visual Basic) if the InnerException property does not supply the inner exception value to the constructor.</remarks>			
        public MessageException(string message, Exception inner): base(message, inner)																 
		{																 
            _extendedData = new ASObject();
		}
		/// <summary>
		/// Initializes a new instance of the MessageException class.
		/// </summary>
		/// <param name="inner">Reference to the inner exception that is the cause of this exception.</param>
		/// <param name="extendedData">Additional information.</param>
		public MessageException(Exception inner, ASObject extendedData):base(inner.Message, inner)
		{
			_extendedData = extendedData;
			_rootCause = inner;
		}
		/// <summary>
		/// Initializes a new instance of the MessageException class with a specified error message.
		/// </summary>
		/// <param name="extendedData">Additional information.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public MessageException(ASObject extendedData, string message) : base(message)
		{
			_extendedData = extendedData;
		}
		/// <summary>
		/// Initializes a new instance of the MessageException class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="extendedData">Additional information.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">Reference to the inner exception that is the cause of this exception.</param>
		/// <remarks>An exception that is thrown as a direct result of a previous exception should include a reference to the previous exception in the InnerException property. The InnerException property returns the same value that is passed into the constructor, or a null reference (Nothing in Visual Basic) if the InnerException property does not supply the inner exception value to the constructor.</remarks>			
		public MessageException(ASObject extendedData, string message, Exception inner) : base(message, inner)																 
		{																 
			_extendedData = extendedData;
			_rootCause = inner;
		}

		/// <summary>
		/// Gets or sets the fault code for the error.
		/// </summary>
		public string FaultCode
		{
			get{ return _faultCode; }
			set{ _faultCode = value; }
		}
		/// <summary>
		/// Root cause for the error.
		/// </summary>
		public object RootCause
		{
			get{ return _rootCause; }
			set{ _rootCause = value; }
		}

		/// <summary>
		/// Return additional information to the client as part of a message exception.
		/// </summary>
		public ASObject ExtendedData
		{
			get{ return _extendedData; }
		}

		internal virtual ErrorMessage GetErrorMessage()
		{
			ErrorMessage errorMessage = new ErrorMessage();
			errorMessage.faultCode = this.FaultCode;
			errorMessage.faultString = this.Message;
            errorMessage.extendedData = this.ExtendedData;
			return errorMessage;
		}
	}
}
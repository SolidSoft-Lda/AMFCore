using System;
using System.Runtime.Serialization;

namespace SolidSoft.AMFCore.Exceptions
{
	/// <summary>
	/// The exception that is the base class for AMFCore exceptions.
	/// </summary>
	[Serializable]
	public class AMFException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the AMFCoreException class.
		/// </summary>
		public AMFException()
		{
		}
		/// <summary>
		/// Initializes a new instance of the AMFCoreException class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public AMFException(string message) : base(message)
		{
		}
		/// <summary>
		/// Initializes a new instance of the AMFCoreException class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the innerException parameter is not a null reference (Nothing in Visual Basic), the current exception is raised in a catch block that handles the inner exception.</param>	
		/// <remarks>An exception that is thrown as a direct result of a previous exception should include a reference to the previous exception in the InnerException property. The InnerException property returns the same value that is passed into the constructor, or a null reference (Nothing in Visual Basic) if the InnerException property does not supply the inner exception value to the constructor.</remarks>			
		public AMFException(string message, Exception inner) : base(message, inner)																 
		{																 
		}
		/// <summary>
		/// Initializes a new instance of the AMFCoreException class with serialized data.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		public AMFException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
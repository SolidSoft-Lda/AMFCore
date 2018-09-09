using System;

namespace SolidSoft.AMFCore.Exceptions
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [Serializable]
    public class UnexpectedAMF : AMFException
	{
		/// <summary>
		/// Initializes a new instance of the UnexpectedAMF class.
		/// </summary>
		public UnexpectedAMF()
		{
		}
		/// <summary>
		/// Initializes a new instance of the UnexpectedAMF class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public UnexpectedAMF(string message) : base(message)
		{
		}
	}
}
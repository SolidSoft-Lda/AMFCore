using System;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class ExceptionASO : ASObject
	{
		/// <summary>
		/// Initializes a new instance of the ExceptionASO class.
		/// </summary>
        /// <param name="exception">The exception that is the cause of the current exception.</param>
		public ExceptionASO(Exception exception)
		{
			// When Flash Remoting MX receives a Status event, Flash passes an error object that contains 
			// information about the error to the status event handler. 
			// The error object has the following format
			//
			// code			Currently, always "SERVER.PROCESSING".
			// level		Currently, always "Error".
			// description	A string that describes the error.
			// details		A stack trace that indicates the processing state at the time of the exception. 
			// type			The error class name.
			// rootcause	A nested error object that contains additional information on the cause of the error. Provided only if a Java servletException is thrown.
 
			Add("code", "SERVER.PROCESSING");
			Add("level", "error");
			Add("description", exception.Message);
			Add("details", exception.StackTrace);
			Add("type", exception.GetType().FullName);
			if(exception.InnerException != null)
				Add("rootcause", new ExceptionASO(exception.InnerException));
		}
	}
}
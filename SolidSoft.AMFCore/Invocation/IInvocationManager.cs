using System.Collections.Generic;

namespace SolidSoft.AMFCore.Invocation
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IInvocationManager
	{
        /// <summary>
        /// Gets a stack-based, user-defined storage area that is useful for communication between callback handlers.
        /// </summary>
        Stack<object> Context { get; }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        Dictionary<object, object> Properties { get; }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		object Result {get; set;}
	}
}
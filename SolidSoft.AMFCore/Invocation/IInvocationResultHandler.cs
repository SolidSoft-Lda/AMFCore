using System.Reflection;

namespace SolidSoft.AMFCore.Invocation
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IInvocationResultHandler
	{
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="invocationManager"></param>
        /// <param name="methodInfo"></param>
        /// <param name="obj"></param>
        /// <param name="arguments"></param>
        /// <param name="result"></param>
		void HandleResult(IInvocationManager invocationManager, MethodInfo methodInfo, object obj, object[] arguments, object result);
	}
}
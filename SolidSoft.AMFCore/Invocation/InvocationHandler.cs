using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SolidSoft.AMFCore.Invocation
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class InvocationHandler
	{
		MethodInfo _methodInfo;
		/// <summary>
		/// Initializes a new instance of the InvocationHandler class.
		/// </summary>
		/// <param name="methodInfo"></param>
		public InvocationHandler(MethodInfo methodInfo)
		{
			_methodInfo = methodInfo;
		}

        public async Task<object> Invoke(object obj, object[] arguments)
        {
            object result = null;
            if (_methodInfo.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) == null)
            {
                result = _methodInfo.Invoke(obj, arguments);
            }
            else
            {
                Task task = (Task)_methodInfo.Invoke(obj, arguments);
                await task;
                result = task.GetType().GetProperty("Result").GetValue(task);
            }

			object[] attributes = _methodInfo.GetCustomAttributes( false );
			if( attributes != null && attributes.Length > 0 )
			{
				InvocationManager invocationManager = new InvocationManager();
				invocationManager.Result = result;
				for(int i = 0; i < attributes.Length; i++)
				{
					Attribute attribute = attributes[i] as Attribute;
					if( attribute is IInvocationCallback )
					{
						IInvocationCallback invocationCallback = attribute as IInvocationCallback;
						invocationCallback.OnInvoked(invocationManager, _methodInfo, obj, arguments, result);
					}
				}
				for(int i = 0; i < attributes.Length; i++)
				{
					Attribute attribute = attributes[i] as Attribute;
					if( attribute is IInvocationResultHandler )
					{
						IInvocationResultHandler invocationResultHandler = attribute as IInvocationResultHandler;
						invocationResultHandler.HandleResult(invocationManager, _methodInfo, obj, arguments, result);
					}
				}
				return invocationManager.Result;
			}
			return result;
		}
	}
}
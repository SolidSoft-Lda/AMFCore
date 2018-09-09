using System;
using System.Reflection;

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

		public object Invoke(object obj, object[] arguments)
		{
			object result = _methodInfo.Invoke( obj, arguments );

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
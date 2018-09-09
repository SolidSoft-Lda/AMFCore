using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using SolidSoft.AMFCore.Exceptions;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class MethodHandler
	{
        /// <summary>
        /// Initializes a new instance of the MethodHandler class.
        /// </summary>
		private MethodHandler()
		{
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
		public static MethodInfo GetMethod(Type type, string methodName, IList arguments)
		{
			return GetMethod(type, methodName, arguments, false);
		}

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <param name="exactMatch"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, string methodName, IList arguments, bool exactMatch)
        {
            return GetMethod(type, methodName, arguments, exactMatch, true);
        }

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <param name="exactMatch"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, string methodName, IList arguments, bool exactMatch, bool throwException)
        {
            return GetMethod(type, methodName, arguments, exactMatch, throwException, true);
        }

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <param name="exactMatch"></param>
        /// <param name="throwException"></param>
        /// <param name="traceError"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, string methodName, IList arguments, bool exactMatch, bool throwException, bool traceError)
		{
			MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static);
            List<MethodInfo> suitableMethodInfos = new List<MethodInfo>();

            for (int i = 0; i < methodInfos.Length; i++)
            {
                MethodInfo methodInfo = methodInfos[i];
                if (methodInfo.Name == methodName)
                {
                    if ((methodInfo.GetParameters().Length == 0 && arguments == null)
                        || (arguments != null && methodInfo.GetParameters().Length == arguments.Count))
                        suitableMethodInfos.Add(methodInfo);
                }
            }
            if (suitableMethodInfos.Count > 0)
            {
                //Overloaded methods may suffer performance penalties because of type conversion checking
                for (int i = suitableMethodInfos.Count-1; i >= 0; i--)
                {
                    MethodInfo methodInfo = suitableMethodInfos[i] as MethodInfo;
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    bool match = true;
                    //Matching method name and parameters number
                    for (int j = 0; j < parameterInfos.Length; j++)
                    {
                        ParameterInfo parameterInfo = parameterInfos[j];
                        if (!exactMatch)
                        {
                            if (!TypeHelper.IsAssignable(arguments[j], parameterInfo.ParameterType))
                            {
                                match = false;
                                break;
                            }
                        }
                        else
                        {
                            if (arguments[j] == null || arguments[j].GetType() != parameterInfo.ParameterType)
                            {
                                match = false;
                                break;
                            }
                        }
                    }
                    if (!match)
                        suitableMethodInfos.Remove(methodInfo);
                }
            }
			if (suitableMethodInfos.Count == 0)
			{
                string msg = __Res.GetString(__Res.Invocation_NoSuitableMethod, methodName);
				if (throwException)
					throw new AMFException(msg);
			}
			if (suitableMethodInfos.Count > 1)
			{
                string msg = __Res.GetString(__Res.Invocation_Ambiguity, methodName);
				if( throwException )
					throw new AMFException(msg);
			}

            if (suitableMethodInfos.Count > 0)
                return suitableMethodInfos[0] as MethodInfo;
            return null;
		}
	}
}
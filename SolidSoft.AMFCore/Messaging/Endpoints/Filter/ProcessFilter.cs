using System;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using SolidSoft.AMFCore.IO;
using SolidSoft.AMFCore.Exceptions;
using SolidSoft.AMFCore.Invocation;
using SolidSoft.AMFCore.Messaging.Services;

namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ProcessFilter : AbstractFilter
	{
		EndpointBase _endpoint;

		/// <summary>
		/// Initializes a new instance of the ProcessFilter class.
		/// </summary>
		public ProcessFilter(EndpointBase endpoint)
		{
			_endpoint = endpoint;
		}

		#region IFilter Members

		public override Task Invoke(AMFContext context)
		{
			MessageOutput messageOutput = context.MessageOutput;
			for(int i = 0; i < context.AMFMessage.BodyCount; i++)
			{
				AMFBody amfBody = context.AMFMessage.GetBodyAt(i);
				ResponseBody responseBody = null;
				//Check for Flex2 messages and skip
				if( amfBody.IsEmptyTarget )
					continue;

				//Check if response exists.
				responseBody = messageOutput.GetResponse(amfBody);
				if( responseBody != null )
				{
					continue;
				}

				try
				{
				    MessageBroker messageBroker = _endpoint.GetMessageBroker();
                    RemotingService remotingService = messageBroker.GetService(RemotingService.RemotingServiceId) as RemotingService;
                    if (remotingService == null)
                    {
                        string serviceNotFound = __Res.GetString(__Res.Service_NotFound, RemotingService.RemotingServiceId);
                        responseBody = new ErrorResponseBody(amfBody, new AMFException(serviceNotFound));
                        messageOutput.AddBody(responseBody);
                        continue;
                    }
                    Destination destination = null;
                    if (destination == null)
                        destination = remotingService.GetDestinationWithSource(amfBody.TypeName);
                    if (destination == null)
                        destination = remotingService.DefaultDestination;
                    //At this moment we got a destination with the exact source or we have a default destination with the "*" source.
                    if (destination == null)
                    {
                        string destinationNotFound = __Res.GetString(__Res.Destination_NotFound, amfBody.TypeName);
                        responseBody = new ErrorResponseBody(amfBody, new AMFException(destinationNotFound));
                        messageOutput.AddBody(responseBody);
                        continue;
                    }

                    //Cache check
                    string source = amfBody.TypeName + "." + amfBody.Method;
                    IList parameterList = amfBody.GetParameterList();

                    FactoryInstance factoryInstance = destination.GetFactoryInstance();
				    factoryInstance.Source = amfBody.TypeName;
				    object instance = factoryInstance.Lookup();

				    if( instance != null )
                    {
                        bool isAccessible = TypeHelper.GetTypeIsAccessible(instance.GetType());
                        if (!isAccessible)
                        {
                            string msg = __Res.GetString(__Res.Type_InitError, amfBody.TypeName);
                            responseBody = new ErrorResponseBody(amfBody, new AMFException(msg));
                            messageOutput.AddBody(responseBody);
                            continue;
                        }

                        MethodInfo mi = null;
                        if (!amfBody.IsRecordsetDelivery)
                        {
                            mi = MethodHandler.GetMethod(instance.GetType(), amfBody.Method, amfBody.GetParameterList());
                        }
                        else
                        {
                            //will receive recordsetid only (ignore)
                            mi = instance.GetType().GetMethod(amfBody.Method);
                        }
                        if (mi != null)
                        {
                            #region Invocation handling
                            ParameterInfo[] parameterInfos = mi.GetParameters();
                            //Try to handle missing/optional parameters.
                            object[] args = new object[parameterInfos.Length];
                            if (!amfBody.IsRecordsetDelivery)
                            {
                                if (args.Length != parameterList.Count)
                                {
                                    string msg = __Res.GetString(__Res.Arg_Mismatch, parameterList.Count, mi.Name, args.Length);
                                    responseBody = new ErrorResponseBody(amfBody, new ArgumentException(msg));
                                    messageOutput.AddBody(responseBody);
                                    continue;
                                }
                                parameterList.CopyTo(args, 0);
                            }
                            else
                            {
                                if (amfBody.Target.EndsWith(".release"))
                                {
                                    responseBody = new ResponseBody(amfBody, null);
                                    messageOutput.AddBody(responseBody);
                                    continue;
                                }
                                string recordsetId = parameterList[0] as string;
                                string recordetDeliveryParameters = amfBody.GetRecordsetArgs();
                                byte[] buffer = System.Convert.FromBase64String(recordetDeliveryParameters);
                                recordetDeliveryParameters = System.Text.Encoding.UTF8.GetString(buffer);
                                if (recordetDeliveryParameters != null && recordetDeliveryParameters != string.Empty)
                                {
                                    string[] stringParameters = recordetDeliveryParameters.Split(new char[] { ',' });
                                    for (int j = 0; j < stringParameters.Length; j++)
                                    {
                                        if (stringParameters[j] == string.Empty)
                                            args[j] = null;
                                        else
                                            args[j] = stringParameters[j];
                                    }
                                    //TypeHelper.NarrowValues(argsStore, parameterInfos);
                                }
                            }

                            TypeHelper.NarrowValues(args, parameterInfos);

                            try
                            {
                                InvocationHandler invocationHandler = new InvocationHandler(mi);
                                object result = invocationHandler.Invoke(instance, args);

                                responseBody = new ResponseBody(amfBody, result);
                            }
                            catch (UnauthorizedAccessException exception)
                            {
                                responseBody = new ErrorResponseBody(amfBody, exception);
                            }
                            catch (Exception exception)
                            {
                                if (exception is TargetInvocationException && exception.InnerException != null)
                                    responseBody = new ErrorResponseBody(amfBody, exception.InnerException);
                                else
                                    responseBody = new ErrorResponseBody(amfBody, exception);
                            }
                            #endregion Invocation handling
                        }
                        else
                            responseBody = new ErrorResponseBody(amfBody, new MissingMethodException(amfBody.TypeName, amfBody.Method));
                    }
                    else
                        responseBody = new ErrorResponseBody(amfBody, new TypeInitializationException(amfBody.TypeName, null));
                }
			    catch (Exception exception)
			    {
				    responseBody = new ErrorResponseBody(amfBody, exception);
			    }
				messageOutput.AddBody(responseBody);
			}

            return Task.FromResult<object>(null);
        }
		#endregion

	}
}
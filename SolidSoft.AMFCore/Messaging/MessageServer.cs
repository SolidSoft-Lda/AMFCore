using System;
using SolidSoft.AMFCore.Messaging.Config;
using SolidSoft.AMFCore.Messaging.Endpoints;
using SolidSoft.AMFCore.Messaging.Services;
using SolidSoft.AMFCore.Util;
using SolidSoft.AMFCore.Exceptions;
using SolidSoft.AMFCore.DependencyInjection;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class MessageServer : DisposableBase
	{
        ServiceConfigSettings _serviceConfigSettings;
		MessageBroker	_messageBroker;

		/// <summary>
		/// Initializes a new instance of the MessageServer class.
		/// </summary>
		public MessageServer()
		{
		}
        
        internal ServiceConfigSettings ServiceConfigSettings
        {
            get { return _serviceConfigSettings; }
        }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public void Init()
        {
 			_messageBroker = new MessageBroker(this);

            _serviceConfigSettings = ServiceConfigSettings.Load();
            foreach (ChannelSettings channelSettings in _serviceConfigSettings.ChannelsSettings)
            {
                Type type = ObjectFactory.Locate(channelSettings.Class);
                if (type != null)
                {
                    IEndpoint endpoint = ObjectFactory.CreateInstance(type, new object[] { _messageBroker, channelSettings }) as IEndpoint;
                    if (endpoint != null)
                        _messageBroker.AddEndpoint(endpoint);
                }
            }
            foreach (FactorySettings factorySettings in _serviceConfigSettings.FactoriesSettings)
            {
                Type type = ObjectFactory.Locate(factorySettings.ClassId);
                if (type != null)
                {
                    IFlexFactory flexFactory = ObjectFactory.CreateInstance(type, new object[0]) as IFlexFactory;
                    if (flexFactory != null)
                        _messageBroker.AddFactory(factorySettings.Id, flexFactory);
                }
            }
            //Add the dotnet Factory
            _messageBroker.AddFactory("dotnet", new DotNetFactory());

            foreach (ServiceSettings serviceSettings in _serviceConfigSettings.ServiceSettings)
            {
                Type type = ObjectFactory.Locate(serviceSettings.Class);//current assembly only
                if (type != null)
                {
                    IService service = ObjectFactory.CreateInstance(type, new object[] { _messageBroker, serviceSettings }) as IService;
                    if (service != null)
                        _messageBroker.AddService(service);
                }
            }
		}

        private void InstallServiceBrowserDestinations(ServiceSettings serviceSettings, AdapterSettings adapterSettings)
        {
            //ServiceBrowser destinations
            DestinationSettings destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.AMFServiceBrowserDestination, adapterSettings, DestinationSettings.AMFServiceBrowserDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);

            destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.AMFManagementDestination, adapterSettings, DestinationSettings.AMFManagementDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);

            destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.AMFCodeGeneratorDestination, adapterSettings, DestinationSettings.AMFCodeGeneratorDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);
        }

        /// <summary>
        /// Gets the message broker started by this server.
        /// </summary>
		public MessageBroker MessageBroker{ get { return _messageBroker; } }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public void Start()
		{
            if (_messageBroker != null)
                _messageBroker.Start();
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public void Stop()
		{
			if( _messageBroker != null )
			{
				_messageBroker.Stop();
				_messageBroker = null;
			}
		}

		#region IDisposable Members

		protected override void Free()
		{
			if (_messageBroker != null)
			{
				Stop();
			}
		}

		protected override void FreeUnmanaged()
		{
			if (_messageBroker != null)
			{
				Stop();
			}
		}


		#endregion
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public void Service()
		{
			if( _messageBroker == null )
			{
                string msg = __Res.GetString(__Res.MessageBroker_NotAvailable);
                throw new AMFException(msg);
			}

            //This is equivalent to request.getContextPath() (Java) or the HttpRequest.ApplicationPath (.Net).
            string contextPath = HttpContextManager.ContextPath;
            string endpointPath = contextPath + "/Gateway";
            bool isSecure = HttpContextManager.IsSecure;

            //http://www.adobe.com/cfusion/knowledgebase/index.cfm?id=e329643d&pss=rss_flex_e329643d
            IEndpoint endpoint = _messageBroker.GetEndpoint(endpointPath, contextPath, isSecure);
			if( endpoint != null )
			{
				endpoint.Service();
			}
			else
			{
				string msg = __Res.GetString(__Res.Endpoint_BindFail, endpointPath, contextPath);
                _messageBroker.TraceChannelSettings();
                throw new AMFException(msg);
			}
		}
	}
}
using System;
using System.Collections;
using SolidSoft.AMFCore.Messaging.Services;
using SolidSoft.AMFCore.Messaging.Config;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// The Destination class is a source and sink for messages sent through 
	/// a service destination and uses an adapter to process messages.
	/// </summary>
    
    public class Destination
	{
        /// <summary>
        /// Service managing this Destination.
        /// </summary>
		protected IService				_service;
        /// <summary>
        /// Destination settings.
        /// </summary>
		protected DestinationSettings	_settings;
        /// <summary>
        /// ServiceAdapter for the Destination.
        /// </summary>
		protected ServiceAdapter		_adapter;
		private FactoryInstance			_factoryInstance;

        private Destination()
        {
        }
        
		internal Destination(IService service, DestinationSettings settings)
		{
			_service = service;
			_settings = settings;
		}
        /// <summary>
        /// Gets the Destination identity.
        /// </summary>
		public string Id
		{
			get{ return _settings.Id; }
		}
        /// <summary>
        /// Gets the Destination's factory property.
        /// </summary>
		public string FactoryId
		{
			get
			{
				if( _settings.Properties.Contains("factory") )
					return _settings.Properties["factory"] as string;
				return "dotnet";
			}
		}
        /// <summary>
        /// Returns the Service managing this Destination.
        /// </summary>
		public IService Service{ get{ return _service; } }

		internal void Init(AdapterSettings adapterSettings)
		{
			if( adapterSettings != null )
			{
				string typeName = adapterSettings.Class;
				Type type = ObjectFactory.Locate(typeName);
				if( type != null )
				{
                    _adapter = ObjectFactory.CreateInstance(type) as ServiceAdapter;
					_adapter.SetDestination(this);
                    _adapter.SetAdapterSettings(adapterSettings);
                    _adapter.SetDestinationSettings(_settings);
					_adapter.Init();

				}
			}
            MessageBroker messageBroker = this.Service.GetMessageBroker();
            messageBroker.RegisterDestination(this, _service);

            //If the source has application scope create an instance here, so the service can listen for SessionCreated events for the first request
            if (this.Scope == "application")
            {
                FactoryInstance factoryInstance = GetFactoryInstance();
                object inst = factoryInstance.Lookup();
            }
        }
        /// <summary>
        /// Gets the ServiceAdapter used by the Destination for message processing.
        /// </summary>
        public ServiceAdapter ServiceAdapter { get { return _adapter; } }
        /// <summary>
        /// Gets the Destination settings.
        /// </summary>
		public DestinationSettings DestinationSettings{ get{ return _settings; } }

        /// <summary>
        /// Gets the source property where applicable.
        /// </summary>
        public string Source
        {
            get
            {
                if (_settings != null && _settings.Properties != null )
                {
                    return _settings.Properties["source"] as string;
                }
                return null;
            }
        }
        /// <summary>
        /// Gets the scope property where applicable.
        /// </summary>
        public string Scope
        {
            get
            {
                if (_settings != null && _settings.Properties != null )
                {
                    return _settings.Properties["scope"] as string;
                }
                return "request";
            }
        }

        /// <summary>
        /// Returns the FactoryInstance used by the Destination to create object instances.
        /// </summary>
        /// <returns></returns>
		public FactoryInstance GetFactoryInstance()
		{
			if( _factoryInstance != null )
				return _factoryInstance;

			MessageBroker messageBroker = this.Service.GetMessageBroker();
			IFlexFactory factory = messageBroker.GetFactory(this.FactoryId);
			Hashtable properties = _settings.Properties;
			_factoryInstance = factory.CreateFactoryInstance(this.Id, properties);
			return _factoryInstance;
		}
	}
}
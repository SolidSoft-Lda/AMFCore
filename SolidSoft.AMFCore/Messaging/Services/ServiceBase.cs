using System;
using System.Collections;
using SolidSoft.AMFCore.Messaging.Config;
using SolidSoft.AMFCore.Messaging.Messages;
using SolidSoft.AMFCore.Configuration;

namespace SolidSoft.AMFCore.Messaging.Services
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
    public class ServiceBase : IService
	{
        /// <summary>
        /// Reference to the MessageBroker.
        /// </summary>
		protected MessageBroker	_messageBroker;
        /// <summary>
        /// Service settings.
        /// </summary>
        protected ServiceSettings _serviceSettings;
        /// <summary>
        /// Destinations in this service.
        /// </summary>
        protected Hashtable _destinations;
        object _objLock = new object();
        /// <summary>
        /// Reference to the default Destination is available.
        /// </summary>
        protected Destination _defaultDestination;

        internal ServiceBase()
        {
        }

		internal ServiceBase(MessageBroker messageBroker, ServiceSettings serviceSettings)
		{
			_messageBroker = messageBroker;
			_serviceSettings = serviceSettings;

			_destinations = new Hashtable();
            foreach (DestinationSettings destinationSettings in serviceSettings.DestinationSettings)
			{
				CreateDestination(destinationSettings);
			}
		}
        /// <summary>
        /// Creates a new Destination.
        /// </summary>
        /// <param name="destinationSettings">Destination settings.</param>
        /// <returns>The new Destination instance.</returns>
		protected virtual Destination NewDestination(DestinationSettings destinationSettings)
		{
			return new Destination(this, destinationSettings);
		}
        /// <summary>
        /// Gets service settings.
        /// </summary>
		public ServiceSettings ServiceSettings{ get { return _serviceSettings; } }

		#region IService Members

        /// <summary>
        /// Gets the service identity.
        /// </summary>
		public string id
		{
			get
			{
				return _serviceSettings.Id;
			}
		}
        /// <summary>
        /// Retrievs the MessageBroker managing this service.
        /// This MessageBroker is used to push a message to one or more endpoints managed by the broker. 
        /// </summary>
        /// <returns>The MessageBroker managing this service.</returns>
		public MessageBroker GetMessageBroker()
		{
			return _messageBroker;
		}
        /// <summary>
        /// Retrieves the destination in this service for which the given message is intended.
        /// </summary>
        /// <param name="message">The message that should be handled by the destination.</param>
        /// <returns>The destination if it is found; otherwise, null.</returns>
		public Destination GetDestination(IMessage message)
		{
			lock(_objLock)
			{
				return _destinations[message.destination] as Destination;
			}
		}
        /// <summary>
        /// Returns all destinations in this service.
        /// </summary>
        /// <returns>The collection of destinations.</returns>
		public Destination[] GetDestinations()
		{
			lock(_objLock)
			{
				ArrayList result = new ArrayList(_destinations.Values);
				return result.ToArray(typeof(Destination)) as Destination[];
			}
		}
        /// <summary>
        /// Returns the destination for the specified source.
        /// </summary>
        /// <param name="source">The destination's source property.</param>
        /// <returns>The destination if it is found; otherwise, null.</returns>
		public Destination GetDestinationWithSource(string source)
		{
			lock(_objLock)
			{
				foreach(Destination destination in _destinations.Values)
				{
					string sourceTmp = destination.DestinationSettings.Properties["source"] as string;
					if( source == sourceTmp )
						return destination;
				}
				return null;
			}
		}
        /// <summary>
        /// Gets the default destination if available.
        /// </summary>
		public Destination DefaultDestination
		{
			get{ return _defaultDestination; }
		}
        /// <summary>
        /// Returns the destination with the specified Id.
        /// </summary>
        /// <param name="id">The destination's identity.</param>
        /// <returns>The destination if it is found; otherwise, null.</returns>
        public Destination GetDestination(string id)
		{
			lock(_objLock)
			{
				return _destinations[id] as Destination;
			}
		}
        /// <summary>
        /// Handles a message routed to the service by the MessageBroker.
        /// </summary>
        /// <param name="message">The message that should be handled by the service.</param>
        /// <returns>The result of the message processing.</returns>
		public virtual object ServiceMessage(IMessage message)
		{
			CommandMessage commandMessage = message as CommandMessage;
			if( commandMessage != null && commandMessage.operation == CommandMessage.ClientPingOperation )
				return true;
			throw new NotSupportedException();
		}
        /// <summary>
        /// Returns whether this Service is capable of handling the given Message instance.
        /// </summary>
        /// <param name="message">The message that should be handled by the service.</param>
        /// <returns>true if the Service is capable of handling the message; otherwise, false.</returns>
		public bool IsSupportedMessage(IMessage message)
		{
			return IsSupportedMessageType(message.GetType().FullName);
		}
        /// <summary>
        /// Returns whether this Service is capable of handling messages of a given type.
        /// </summary>
        /// <param name="messageClassName">The message type.</param>
        /// <returns>true if the Service is capable of handling messages of a given type; otherwise, false.</returns>
        public bool IsSupportedMessageType(string messageClassName)
		{
			bool result = _serviceSettings.SupportedMessageTypes.Contains(messageClassName);
			if(!result)
			{
				//Check whether this type is mapped				
				string typeName = AMFConfiguration.Instance.ClassMappings.GetCustomClass(messageClassName);
				return _serviceSettings.SupportedMessageTypes.Contains(typeName);
			}
			return result;
		}

        /// <summary>
        /// Performs any startup actions necessary after the service has been added to the broker.
        /// </summary>
        public virtual void Start()
		{
		}
        /// <summary>
        /// Performs any actions necessary before removing the service from the broker.
        /// </summary>
        public virtual void Stop()
		{
		}

		#endregion

        /// <summary>
        /// Creates a destination with the specified settings.
        /// </summary>
        /// <param name="destinationSettings">Destination settings.</param>
        /// <returns>The created destination instance.</returns>
		public virtual Destination CreateDestination(DestinationSettings destinationSettings)
		{
			lock(_objLock)
			{
				if( !_destinations.ContainsKey(destinationSettings.Id) )
				{
					Destination destination = NewDestination(destinationSettings);
					if( destinationSettings.Adapter != null )
                        destination.Init(destinationSettings.Adapter);
					else
                        destination.Init(_serviceSettings.DefaultAdapter);
					_destinations[destination.Id] = destination;
					
					string source = destination.DestinationSettings.Properties["source"] as string;
					//TODO: warn if more then one "*" source occurs.
					if( source != null && source == "*" )
						_defaultDestination = destination;
					return destination;
				}
				else
					return _destinations[destinationSettings.Id] as Destination;
			}
		}
	}
}
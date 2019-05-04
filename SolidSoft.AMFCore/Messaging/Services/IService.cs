using System.Threading.Tasks;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Services
{
	/// <summary>
	/// The MessageBroker has endpoints on one end and services on the other.
	/// The Service interface defines the contract between the MessageBroker 
	/// and all Service implementations.
	/// </summary>
    
    public interface IService
	{
        /// <summary>
        /// Gets the service identity.
        /// </summary>
		string id { get; }
		/// <summary>
        /// Retrieves the MessageBroker managing this service.
        /// This MessageBroker is used to push a message to one or more endpoints managed by the broker. 
		/// </summary>
        /// <returns>The MessageBroker managing this service.</returns>
		MessageBroker GetMessageBroker();
		/// <summary>
		/// Retrieves the destination in this service for which the given message is intended.
		/// </summary>
		/// <param name="message"></param>
		/// <returns>The requested Destination.</returns>
        
        Destination GetDestination(IMessage message);
        /// <summary>
        /// Handles a message routed to the service by the MessageBroker.
        /// </summary>
        /// <param name="message">The message sent by the MessageBroker.</param>
        /// <returns></returns>
        Task<object> ServiceMessage(IMessage message);
		/// <summary>
		/// Determines whether this Service is capable of handling a given Message instance.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		bool IsSupportedMessage(IMessage message);
		/// <summary>
		/// Determines whether this Service is capable of handling messages of a given type.
		/// </summary>
		/// <param name="messageClassName"></param>
		/// <returns></returns>
		bool IsSupportedMessageType(string messageClassName);
		/// <summary>
		/// Performs any startup actions necessary after the service has been added to the broker.
		/// </summary>
		void Start();
		/// <summary>
		/// Performs any actions necessary before removing the service from the broker.
		/// </summary>
		void Stop();
        /// <summary>
        /// Retrieves the destination in this service for with the given destination identity.
        /// </summary>
        /// <param name="id">Destination identity.</param>
        /// <returns></returns>
        
        Destination GetDestination(string id);
        /// <summary>
        /// Retrieves the list of destinations in this service.
        /// </summary>
        /// <returns></returns>
        
        Destination[] GetDestinations();
	}
}
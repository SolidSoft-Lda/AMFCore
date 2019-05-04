using System.Threading.Tasks;
using SolidSoft.AMFCore.Messaging.Config;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Endpoints
{
	/// <summary>
    /// <para>
	/// Endpoint interface.
    /// </para>
    /// <para>
    /// An endpoint receives messages from clients and decodes them, then sends them on to a MessageBroker for routing to a service.
    /// The endpoint also encodes messages and delivers them to clients. Endpoints are specific to a message format and network transport, 
    /// and are defined by the named URI path on which they are located. 
    /// </para>
	/// </summary>
	public interface IEndpoint
	{
        /// <summary>
        /// Gets or sets endpoint id.
        /// </summary>
        /// <remarks>All endpoints are referenceable by an id that is unique among all the endpoints registered to a single broker instance.</remarks>
		string Id{ get; set; }
        /// <summary>
        /// Returns a reference to the message broker managing this endpoint.
        /// </summary>
        /// <returns></returns>
		MessageBroker GetMessageBroker();
        /// <summary>
        /// Returns channel settings.
        /// </summary>
        /// <returns></returns>
		ChannelSettings GetSettings();
        /// <summary>
        /// Starts the endpoint.
        /// </summary>
		void Start();
        /// <summary>
        /// Stops and destroys the endpoint.
        /// </summary>
		void Stop();
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageclient"></param>
		void Push(IMessage message, MessageClient messageclient);
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        Task Service();
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
		Task<IMessage> ServiceMessage(IMessage message);
        /// <summary>
        /// Specifies whether this protocol requires the secure HTTPS protocol.
        /// </summary>
		bool IsSecure{ get; }
	}
}
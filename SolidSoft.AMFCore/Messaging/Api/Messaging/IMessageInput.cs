using System.Collections;
using System.Collections.Generic;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// Input Endpoint for a consumer to connect.
    /// </summary>
    
    public interface IMessageInput
    {
        /// <summary>
        /// Pull message from this input endpoint. Return w/o waiting.
        /// </summary>
        /// <returns>The pulled message or null if message is not available.</returns>
        IMessage PullMessage();
        /// <summary>
        /// Pull message from this input endpoint. Wait "wait" milliseconds if message is not available.
        /// </summary>
        /// <param name="wait">Milliseconds to wait when message is not available.</param>
        /// <returns>The pulled message or null if message is not available.</returns>
        IMessage PullMessage(long wait);
        /// <summary>
        /// Connect to a consumer.
        /// </summary>
        /// <param name="consumer">Consumer object.</param>
        /// <param name="parameterMap">Parameters map.</param>
        /// <returns>true when successfully subscribed, false otherwise.</returns>
        bool Subscribe(IConsumer consumer, Dictionary<string, object> parameterMap);
        /// <summary>
        /// Disconnect from a consumer.
        /// </summary>
        /// <param name="consumer">Consumer to disconnect.</param>
        /// <returns>true when successfully unsubscribed, false otherwise.</returns>
        bool Unsubscribe(IConsumer consumer);
        /// <summary>
        /// Returns a collection of IConsumer objects.
        /// </summary>
        /// <returns>A collection of IConsumer objects.</returns>
        ICollection GetConsumers();
        /// <summary>
        /// Sends OOB Control Message to all providers on the other side of pipe.
        /// </summary>
        /// <param name="consumer">The consumer that sends the message.</param>
        /// <param name="oobCtrlMsg">Out-of-band control message.</param>
        void SendOOBControlMessage(IConsumer consumer, OOBControlMessage oobCtrlMsg);
    }
}
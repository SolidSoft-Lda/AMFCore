using System.Collections;
using System.Collections.Generic;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// Output Endpoint for a provider to connect.
    /// </summary>
    
    public interface IMessageOutput
    {
        /// <summary>
        /// Push a message to this output endpoint. May block the pusher when output can't handle the message at the time.
        /// </summary>
        /// <param name="message">Message to be pushed.</param>
        void PushMessage(IMessage message);
        /// <summary>
        /// Connect to a provider. Note that parameters passed have nothing to deal with NetConnection.connect in client-side Flex/Flash RIA.
        /// </summary>
        /// <param name="provider">Provider object.</param>
        /// <param name="parameterMap">Parameters passed with connection</param>
        /// <returns>true when successfully subscribed, false otherwise.</returns>
        bool Subscribe(IProvider provider, Dictionary<string, object> parameterMap);
        /// <summary>
        /// Disconnect from a provider.
        /// </summary>
        /// <param name="provider">Provider object.</param>
        /// <returns>true when successfully unsubscribed, false otherwise.</returns>
        bool Unsubscribe(IProvider provider);
        /// <summary>
        /// Returns collection of providers.
        /// </summary>
        /// <returns>Collection of IProvider objects.</returns>
        ICollection GetProviders();
        /// <summary>
        /// Send OOB Control Message to all consumers on the other side of pipe.
        /// </summary>
        /// <param name="provider">The provider that sends the message.</param>
        /// <param name="oobCtrlMsg">Out-of-band control message.</param>
        void SendOOBControlMessage(IProvider provider, OOBControlMessage oobCtrlMsg);
    }
}
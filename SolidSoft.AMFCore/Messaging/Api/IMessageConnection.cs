using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IMessageConnection
	{
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="client"></param>
		void RegisterMessageClient(IMessageClient client);
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="clientId"></param>
		void RemoveMessageClient(string clientId);
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		void RemoveMessageClients();
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
		bool IsClientRegistered(string clientId);
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		int ClientCount{ get; }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageClient"></param>
		void Push(IMessage message, IMessageClient messageClient);
	}
}
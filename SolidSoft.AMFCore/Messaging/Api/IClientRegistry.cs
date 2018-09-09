using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IClientRegistry
	{
		/// <summary>
		/// Check if a client with a given id exists.
		/// </summary>
		/// <param name="id">The identity of the client to check for.</param>
		/// <returns><c>true</c> if the client exists, <c>false</c> otherwise.</returns>
		bool HasClient(string id);

        /*
        /// <summary>
        /// Create a new client client object from connection parameters.
        /// </summary>
        /// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
        /// <param name="parameters">The parameters the client passed during connection.</param>
        /// <returns>The new client.</returns>
        IClient NewClient(int clientLeaseTime, object[] parameters);
        /// <summary>
        /// Create a new client client object from connection parameters.
        /// </summary>
        /// <param name="id">Client identity.</param>
        /// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
        /// <param name="parameters">The parameters the client passed during connection.</param>
        /// <returns></returns>
        IClient NewClient(string id, int clientLeaseTime, object[] parameters);
        */
		/// <summary>
		/// Returns an existing client from a client id.
		/// </summary>
		/// <param name="id">The identity of the client to return.</param>
		/// <returns>The client object.</returns>
		IClient LookupClient(string id);
        /// <summary>
        /// Returns an existing client from a client id or creates a new one if not found.
        /// </summary>
        /// <param name="id">The identity of the client to return.</param>
        /// <returns>The client object.</returns>
        IClient GetClient(string id);
        /// <summary>
        /// Returns an existing client from the message header transporting the global FlexClient Id value or creates a new one if not found.
        /// </summary>
        /// <param name="message">Message sent from client.</param>
        /// <returns>The client object.</returns>
        IClient GetClient(IMessage message);
	}
}
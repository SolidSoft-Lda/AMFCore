namespace SolidSoft.AMFCore.Messaging.Api
{
    /// <summary>
    /// MessageClient interface.
    /// </summary>
    public interface IMessageClient
    {
        /// <summary>
        /// Gets an object that can be used to synchronize access. 
        /// </summary>
        object SyncRoot { get; }
        /// <summary>
        /// Gets the MessageClient identity.
        /// </summary>
        string ClientId { get; }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
        byte[] GetBinaryId();
        /// <summary>
        /// Gets whether the connection is being disconnected.
        /// </summary>
        bool IsDisconnecting { get;}
    }
}
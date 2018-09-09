namespace SolidSoft.AMFCore.Messaging.Api
{
    /// <summary>
    /// Interface to be notified when a MessageClient is created or destroyed.
    /// </summary>
    public interface IMessageClientListener
    {
        /// <summary>
        /// Notification that a MessageClient instance was created.
        /// </summary>
        /// <param name="messageClient">The MessageClient that was created.</param>
        void MessageClientCreated(IMessageClient messageClient);
        /// <summary>
        /// Notification that a MessageClient is about to be destroyed.
        /// </summary>
        /// <param name="messageClient">The MessageClient that will be destroyed.</param>
        void MessageClientDestroyed(IMessageClient messageClient);
    }
}
namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// A pipe is an object that connects message providers and
    /// message consumers. Its main function is to transport messages
    /// in kind of ways it provides.
    /// 
    /// Pipes fire events as they go, these events are common way to work with pipes for
    /// higher level parts of server.
    /// </summary>
    
    public interface IPipe : IMessageInput, IMessageOutput
    {
        /// <summary>
        /// Adds connection event listener to pipe.
        /// </summary>
        /// <param name="listener">Connection event listener.</param>
        void AddPipeConnectionListener(IPipeConnectionListener listener);
        /// <summary>
        /// Removes connection event listener to pipe.
        /// </summary>
        /// <param name="listener">Connection event listener.</param>
        void RemovePipeConnectionListener(IPipeConnectionListener listener);
    }
}
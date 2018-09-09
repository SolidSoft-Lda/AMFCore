namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// A listener that wants to listen to events when provider/consumer connects to or disconnects from a specific pipe.
    /// </summary>
    
    public interface IPipeConnectionListener
    {
        /// <summary>
        /// Pipe connection event handler.
        /// </summary>
        /// <param name="evt">Pipe connection event.</param>
        void OnPipeConnectionEvent(PipeConnectionEvent evt);
    }
}
namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// Message component handles out-of-band control messages.
    /// </summary>
    
    public interface IMessageComponent
    {
        /// <summary>
        /// Handles out-of-band control message.
        /// </summary>
        /// <param name="source">Message component source.</param>
        /// <param name="pipe">Connection pipe.</param>
        /// <param name="oobCtrlMsg">Out-of-band control message</param>
        void OnOOBControlMessage(IMessageComponent source, IPipe pipe, OOBControlMessage oobCtrlMsg);
    }
}
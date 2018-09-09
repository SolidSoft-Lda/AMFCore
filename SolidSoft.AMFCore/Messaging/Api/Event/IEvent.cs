namespace SolidSoft.AMFCore.Messaging.Api.Event
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum EventType 
	{
		SYSTEM, STATUS, SERVICE_CALL, SHARED_OBJECT, STREAM_CONTROL, STREAM_DATA, CLIENT, SERVER
	}
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IEvent
	{
        /// <summary>
        /// Gets event type.
        /// </summary>
		EventType EventType{ get; }
        /// <summary>
        /// Gets event context object.
        /// </summary>
		object Object{ get; }
        /// <summary>
        /// Gets whether event has source (event listeners).
        /// </summary>
		bool HasSource{ get; }
        /// <summary>
        /// Gets event listener.
        /// </summary>
		IEventListener Source{ get;set; }
	}
}
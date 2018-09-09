namespace SolidSoft.AMFCore.Messaging.Api.Event
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IEventDispatcher
	{
        /// <summary>
        /// Dispatches an event.
        /// </summary>
        /// <param name="evt">Event to dispatch.</param>
		void DispatchEvent(IEvent evt);
	}
}
using System.Collections;

namespace SolidSoft.AMFCore.Messaging.Api.Event
{
	/// <summary>
    /// Provides an Observer pattern, that is it has a list of objects that listen to events.
	/// </summary>
	public interface IEventObservable
	{
        /// <summary>
        /// Add event listener to this observable.
        /// </summary>
        /// <param name="listener">Event listener.</param>
		void AddEventListener(IEventListener listener);
        /// <summary>
        /// Remove event listener from this observable.
        /// </summary>
        /// <param name="listener">Event listener.</param>
		void RemoveEventListener(IEventListener listener);
        /// <summary>
        /// Get the event listeners collection.
        /// </summary>
        /// <returns>Collection of event listeners.</returns>
		ICollection GetEventListeners();
	}
}
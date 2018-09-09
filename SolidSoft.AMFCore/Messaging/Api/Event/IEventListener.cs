using System;

namespace SolidSoft.AMFCore.Messaging.Api.Event
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IEventListener
	{
        /// <summary>
        /// Event notification. 
        /// </summary>
        /// <param name="evt">The event object.</param>
		void NotifyEvent(IEvent evt);
	}
}
namespace SolidSoft.AMFCore.Messaging.Api.Service
{
	/// <summary>
    /// IPendingServiceCall is a service call with a list of callbacks.
	/// </summary>
	public interface IPendingServiceCall : IServiceCall
	{
        /// <summary>
        /// Gets or sets the service call result.
        /// </summary>
		object Result{get;set;}
        /// <summary>
        /// Registers callback object that implements IPendingServiceCallback interface.
        /// </summary>
        /// <param name="callback"></param>
		void RegisterCallback(IPendingServiceCallback callback);
        /// <summary>
        /// Unregisters callback object that implements IPendingServiceCallback interface.
        /// </summary>
        /// <param name="callback"></param>
		void UnregisterCallback(IPendingServiceCallback callback);
        /// <summary>
        /// Returns list of callback objects that implements IPendingServiceCallback.
        /// </summary>
        /// <returns></returns>
		IPendingServiceCallback[] GetCallbacks();
	}
}
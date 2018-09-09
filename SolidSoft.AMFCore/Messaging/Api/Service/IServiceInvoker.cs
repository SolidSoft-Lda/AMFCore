namespace SolidSoft.AMFCore.Messaging.Api.Service
{
	/// <summary>
    /// Interface for objects that execute service calls (remote calls from client).
	/// </summary>
	public interface IServiceInvoker
	{
		/// <summary>
		/// Execute the passed service call in the given scope.  This looks up the
		/// handler for the call in the scope and the context of the scope.
		/// </summary>
        /// <param name="call">The call to invoke.</param>
        /// <param name="scope">The scope to search for a handler.</param>
        /// <returns><code>true</code> if the call was performed, otherwise <code>false</code>.</returns>
        bool Invoke(IServiceCall call, IScope scope);
		/// <summary>
		/// Execute the passed service call in the given object.
		/// </summary>
        /// <param name="call">The call to invoke.</param>
        /// <param name="service">The service to use.</param>
        /// <returns><code>true</code> if the call was performed, otherwise <code>false</code>.</returns>
        bool Invoke(IServiceCall call, object service);
	}
}
namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
    /// The global scope that acts as root for all applications in a host.
	/// </summary>
	public interface IGlobalScope : IScope
	{
        /// <summary>
        /// Register the global scope in the server and initialize it.
        /// </summary>
		void Register();
        /// <summary>
        /// Gets the root service provide object.
        /// </summary>
        IServiceProvider ServiceProvider { get; }
	}
}
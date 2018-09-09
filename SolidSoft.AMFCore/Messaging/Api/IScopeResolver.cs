namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IScopeResolver
	{
		/// <summary>
		/// Gets the global scope.
		/// </summary>
		IGlobalScope GlobalScope{ get; }
		/// <summary>
		/// Gets the scope for a given path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		IScope ResolveScope(string path);
        /// <summary>
        /// Resolves scope from given root using scope resolver.
        /// </summary>
        /// <param name="root">Scope to start from.</param>
        /// <param name="path">Path to resolve.</param>
        /// <returns></returns>
        IScope ResolveScope(IScope root, string path);
	}
}
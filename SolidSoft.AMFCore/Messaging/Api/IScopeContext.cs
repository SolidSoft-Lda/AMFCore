using SolidSoft.AMFCore.Messaging.Api.Persistence;
using SolidSoft.AMFCore.Messaging.Api.Service;

namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IScopeContext
	{
		/// <summary>
		/// Returns scope by path. You can think of IScope as of tree items, used to
		/// separate context and resources between users.
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
		/// <summary>
		/// Returns global scope reference.
		/// </summary>
		/// <returns></returns>
		IScope GetGlobalScope();
        /// <summary>
        /// Gets the client registry. Client registry is a place where all clients are registered.
        /// </summary>
        IClientRegistry ClientRegistry { get; }
		/// <summary>
		/// Gets persistence store object, a storage for persistent objects like
		/// persistent SharedObjects.
		/// </summary>
        IPersistenceStore PersistenceStore { get; }
		/// <summary>
		/// Returns scope handler (object that handler all actions related to the scope) by path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		IScopeHandler LookupScopeHandler(string path);
        /// <summary>
        /// Gets the service invoker object. Service invokers are objects that make
        /// service calls to client side NetConnection objects.
        /// </summary>
        IServiceInvoker ServiceInvoker { get; }
        /// <summary>
        /// Gets the scope resolverobject.
        /// </summary>
        IScopeResolver ScopeResolver { get; }
	}
}
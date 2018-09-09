using System.Collections;
using SolidSoft.AMFCore.Messaging.Api.Event;
using SolidSoft.AMFCore.Messaging.Api.Persistence;

namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// Base interface for all scope objects.
	/// </summary>
	public interface IBasicScope : ICoreObject, IEventObservable, IPersistable, IEnumerable
	{
		/// <summary>
        /// Checks whether the scope has a parent.
		/// You can think of scopes as of tree items
		/// where scope may have a parent and children (child).
		/// </summary>
		bool HasParent { get; }
		/// <summary>
		/// Get this scope's parent.
		/// </summary>
		IScope Parent { get; }
		/// <summary>
		/// Get the scopes depth, how far down the scope tree is it. The lowest depth
		/// is 0x00, the depth of Global scope. Application scope depth is 0x01. Room
		/// depth is 0x02, 0x03 and so forth.
		/// </summary>
		int Depth { get; }
		/// <summary>
		/// Gets the name of this scope.
		/// </summary>
		new string Name { get; }
		/// <summary>
		/// Gets the full absolute path.
		/// </summary>
		new string Path { get; }
		/// <summary>
		/// Gets the type of the scope.
		/// </summary>
		string Type{ get; }
        /// <summary>
        /// Gets an object that can be used to synchronize access. 
        /// </summary>
        object SyncRoot { get; }
	}
}
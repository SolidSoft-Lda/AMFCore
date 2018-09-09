using System;
using System.Collections;

namespace SolidSoft.AMFCore.Messaging.Api.Persistence
{
	/// <summary>
	/// Storage for persistent objects.
	/// </summary>
	public interface IPersistenceStore
	{
		/// <summary>
		/// Make the passed object persistent.
		/// </summary>
		/// <param name="obj">The object to store.</param>
		/// <returns></returns>
		bool Save(IPersistable obj);
		/// <summary>
		/// Load a persistent object with the given name.  The object must provide
		/// either a constructor that takes an input stream as only parameter or an
		/// empty constructor so it can be loaded from the persistence store.
		/// </summary>
		/// <param name="name">The name of the object to load.</param>
		/// <returns>The loaded object or <code>null</code> if no such object was found.</returns>
		IPersistable Load(String name);
		/// <summary>
		/// Load state of an already instantiated persistent object.
		/// </summary>
		/// <param name="obj">The object to initialize.</param>
		/// <returns>true if the object was initialized, false otherwise.</returns>
		bool Load(IPersistable obj);
		/// <summary>
		/// Delete the passed persistent object.
		/// </summary>
		/// <param name="obj">The object to delete.</param>
		/// <returns></returns>
		bool Remove(IPersistable obj);
		/// <summary>
		/// Delete the persistent object with the given name.
		/// </summary>
		/// <param name="name">The name of the object to delete.</param>
		/// <returns></returns>
		bool Remove(string name);
		/// <summary>
		/// Return iterator over the names of all already loaded objects in the storage.
		/// </summary>
		/// <returns></returns>
		//string[] GetObjectNames();
		ICollection GetObjectNames();
		/// <summary>
		/// Return iterator over the already loaded objects in the storage.
		/// </summary>
		/// <returns></returns>
		//IPersistable[] GetObjects();
		ICollection GetObjects();
	}
}
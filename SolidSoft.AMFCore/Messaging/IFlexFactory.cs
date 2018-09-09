using System.Collections;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// The IFlexFactory interface is implemented by factory components that provide object instances.
	/// </summary>
	public interface IFlexFactory
	{
		/// <summary>
		/// This method is called when the definition of an instance that this factory looks up is initialized. 
		/// </summary>
		/// <param name="id">The factory identity.</param>
		/// <param name="properties">Configuration properties.</param>
        /// <returns>A FactoryInstance instance.</returns>
		FactoryInstance CreateFactoryInstance(string id, Hashtable properties);
		/// <summary>
		/// This method is called by the default implementation of FactoryInstance.Lookup.
		/// </summary>
        /// <param name="factoryInstance">FactoryInstance used to retrieve the object instance.</param>
        /// <returns>The Object instance to use for the given operation for the current destination.</returns>
		object Lookup(FactoryInstance factoryInstance);
	}
}
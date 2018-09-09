using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.Messaging.Api.Persistence
{
	/// <summary>
	/// Base interface for objects that can be made persistent.
	/// 
	/// Every object that complies to this interface must provide either a
	/// constructor that takes an input stream as only parameter or an empty
	/// constructor so it can be loaded from the persistence store.
	/// 
	/// However this is not required for objects that are created by the application
	/// and initialized afterwards.
	/// </summary>
	public interface IPersistable
	{
        /// <summary>
        /// Gets or sets whether the object is persistent.
        /// </summary>
		bool IsPersistent{ get; set; }
        /// <summary>
        /// Gets or sets the name of the persistent object.
        /// </summary>
		string Name{ get; set; }
        /// <summary>
        /// Gets or sets the path of the persistent object.
        /// </summary>
		string Path{ get; set; }
        /// <summary>
        /// Gets the timestamp when the object was last modified.
        /// </summary>
		long LastModified{ get; }
        /// <summary>
        /// Gets or sets the persistence store this object is stored in.
        /// </summary>
		IPersistenceStore Store{ get; set; }
        /// <summary>
        /// Writes the object to the specified output stream.
        /// </summary>
        /// <param name="writer">Writer to write to.</param>
		void Serialize(AMFWriter writer);
        /// <summary>
        /// Loads the object from the specified input stream.
        /// </summary>
        /// <param name="reader">Reader to load from.</param>
		void Deserialize(AMFReader reader);
	}
}
namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// Marker interface for all objects that are aware of the scope they are located in.
	/// </summary>
	public interface IScopeAware
	{
		/// <summary>
		/// Sets the scope the object is located in.
		/// </summary>
		/// <param name="scope">Scope for this object.</param>
		void SetScope(IScope scope);
	}
}
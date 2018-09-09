using System;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// Indicates that serialization is turned off on a certain field or property.
	/// Member variables marked by the transient attribute are not transferred.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public class TransientAttribute : System.Attribute
	{
		/// <summary>
		/// Initializes a new instance of the TransientAttribute class.
		/// </summary>
		public TransientAttribute()
		{
		}
	}
}
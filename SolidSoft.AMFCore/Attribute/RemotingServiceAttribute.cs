using System;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// Indicates whether a type is a remoting service. This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class RemotingServiceAttribute : System.Attribute
	{
		string	_serviceName;

		/// <summary>
		/// Initializes a new instance of the RemotingServiceAttribute class.
		/// </summary>
		public RemotingServiceAttribute()
		{
		}
		/// <summary>
		/// Initializes a new instance of the RemotingServiceAttribute class.
		/// </summary>
		/// <param name="serviceName">Specifies a description for the remoting service.</param>
		public RemotingServiceAttribute(string serviceName)
		{
			_serviceName = serviceName;
		}
	}
}
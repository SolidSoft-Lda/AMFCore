using SolidSoft.AMFCore.Messaging.Config;

namespace SolidSoft.AMFCore.Messaging.Services.Remoting
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class RemotingDestination : Destination
	{
		public RemotingDestination(IService service, DestinationSettings destinationSettings) : base(service, destinationSettings)
		{
		}
	}
}
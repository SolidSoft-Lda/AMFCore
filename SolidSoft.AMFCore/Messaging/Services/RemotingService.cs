using System.Threading.Tasks;
using SolidSoft.AMFCore.Messaging.Config;
using SolidSoft.AMFCore.Messaging.Messages;
using SolidSoft.AMFCore.Messaging.Services.Remoting;

namespace SolidSoft.AMFCore.Messaging.Services
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class RemotingService : ServiceBase
	{
		public const string RemotingServiceId = "remoting-service";

		public RemotingService(MessageBroker broker, ServiceSettings settings) : base(broker, settings)
		{
		}

		protected override Destination NewDestination(DestinationSettings destinationSettings)
		{
			RemotingDestination remotingDestination = new RemotingDestination(this, destinationSettings);
			return remotingDestination;
		}

		public override async Task<object> ServiceMessage(IMessage message)
		{
			RemotingMessage remotingMessage = message as RemotingMessage;
			RemotingDestination destination = GetDestination(message) as RemotingDestination;
			ServiceAdapter adapter = destination.ServiceAdapter;
            Task<object> result = adapter.Invoke(message);
            await result;
            return result.Result;
        }
	}
}
using System;
using System.Threading.Tasks;
using SolidSoft.AMFCore.Util;
using SolidSoft.AMFCore.Messaging.Config;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging.Endpoints
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class EndpointBase : IEndpoint
	{
		protected MessageBroker _messageBroker;
		protected ChannelSettings _channelSettings;
		string _id;

		public EndpointBase(MessageBroker messageBroker, ChannelSettings channelSettings)
		{
			_messageBroker = messageBroker;
			_channelSettings = channelSettings;
			_id = _channelSettings.Id;
		}

		#region IEndpoint Members

		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public MessageBroker GetMessageBroker()
		{
			return _messageBroker;
		}

		public ChannelSettings GetSettings()
		{
			return _channelSettings;
		}

		public virtual void Start()
		{
		}

		public virtual void Stop()
		{
		}

		public virtual void Push(IMessage message, MessageClient messageClient)
		{
			throw new NotSupportedException();
		}

        public virtual Task Service()
        {
            return Task.FromResult<object>(null);
        }

        public virtual Task<IMessage> ServiceMessage(IMessage message)
        {
            ValidationUtils.ArgumentNotNull(message, "message");
            return _messageBroker.RouteMessage(message, this);
        }

		public virtual bool IsSecure
		{
            get
            {
                return false;
            }
		}

		#endregion
	}
}
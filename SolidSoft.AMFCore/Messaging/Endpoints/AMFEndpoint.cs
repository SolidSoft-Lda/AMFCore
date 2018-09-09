using SolidSoft.AMFCore.Context;
using SolidSoft.AMFCore.Configuration;
using SolidSoft.AMFCore.Messaging.Config;
using SolidSoft.AMFCore.Messaging.Messages;
using SolidSoft.AMFCore.Messaging.Endpoints.Filter;
using SolidSoft.AMFCore.Util;
using SolidSoft.AMFCore.DependencyInjection;

namespace SolidSoft.AMFCore.Messaging.Endpoints
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFEndpoint : EndpointBase
	{
		FilterChain _filterChain;
		const string LegacyCollectionKey = "legacy-collection";
        AtomicInteger _waitingPollRequests;

		public AMFEndpoint(MessageBroker messageBroker, ChannelSettings channelSettings):base(messageBroker, channelSettings)
		{
            _waitingPollRequests = new AtomicInteger();
		}

		public override void Start()
		{
			DeserializationFilter deserializationFilter = new DeserializationFilter();
			deserializationFilter.UseLegacyCollection = GetIsLegacyCollection();
			ServiceMapFilter serviceMapFilter = new ServiceMapFilter(this);
			ProcessFilter processFilter = new ProcessFilter(this);
			MessageFilter messageFilter = new MessageFilter(this);
			SerializationFilter serializationFilter = new SerializationFilter();
			serializationFilter.UseLegacyCollection = GetIsLegacyCollection();
			
			deserializationFilter.Next = serviceMapFilter;
			serviceMapFilter.Next = processFilter;
			processFilter.Next = messageFilter;
			messageFilter.Next = serializationFilter;

			_filterChain = new FilterChain(deserializationFilter);
		}

		public bool GetIsLegacyCollection()
		{
			if( !_channelSettings.Contains(LegacyCollectionKey) )
				return false;
			string value = _channelSettings[LegacyCollectionKey] as string;
			bool isLegacy = System.Convert.ToBoolean(value);
			return isLegacy;
		}

		public override void Stop()
		{
			_filterChain = null;
			base.Stop();
		}

		public override void Service()
		{
            AMFContext amfContext = new AMFContext(HttpContextManager.HttpContext.GetInputStream(), HttpContextManager.HttpContext.GetOutputStream());
			_filterChain.InvokeFilters(amfContext);
		}

        public override IMessage ServiceMessage(IMessage message)
        {
            if (message is CommandMessage)
            {
                CommandMessage commandMessage = message as CommandMessage;
                switch (commandMessage.operation)
                {
                    case CommandMessage.PollOperation:
                        {
                            if (Context.AMFContext.Current.Client != null)
                                Context.AMFContext.Current.Client.Renew();

                            IMessage[] messages = null;
                            _waitingPollRequests.Increment();
                            int waitIntervalMillis = _channelSettings.WaitIntervalMillis != -1 ? _channelSettings.WaitIntervalMillis : 60000;// int.MaxValue;

                            if (Context.AMFContext.Current.Client != null)
                                Context.AMFContext.Current.Client.Renew();

                            if (commandMessage.HeaderExists(CommandMessage.AMFSuppressPollWaitHeader))
                                waitIntervalMillis = 0;
                            //If async handling was not set long polling is not supported
                            if (!AMFConfiguration.Instance.AMFSettings.Runtime.AsyncHandler)
                                waitIntervalMillis = 0;
                            if (_channelSettings.MaxWaitingPollRequests <= 0 || _waitingPollRequests.Value >= _channelSettings.MaxWaitingPollRequests)
                                waitIntervalMillis = 0;

                            if (message.destination != null && message.destination != string.Empty)
                            {
                                string clientId = commandMessage.clientId as string;
                            }
                            else
                            {
                                if (Context.AMFContext.Current.Client != null)
                                    messages = Context.AMFContext.Current.Client.GetPendingMessages(waitIntervalMillis);
                            }
                            _waitingPollRequests.Decrement();

                            if (messages == null || messages.Length == 0)
                                return new AcknowledgeMessage();
                            else
                            {
                                CommandMessage resultMessage = new CommandMessage();
                                resultMessage.operation = CommandMessage.ClientSyncOperation;
                                resultMessage.body = messages;
                                return resultMessage;
                            }
                        }
                }
            }
            return base.ServiceMessage(message);
        }

        public override void Push(IMessage message, MessageClient messageClient)
        {
            if (_channelSettings != null && _channelSettings.IsPollingEnabled)
            {
                IMessage messageClone = message.Clone() as IMessage;
                messageClone.SetHeader(MessageBase.DestinationClientIdHeader, messageClient.ClientId);
                messageClone.clientId = messageClient.ClientId;
            }
        }
	}
}
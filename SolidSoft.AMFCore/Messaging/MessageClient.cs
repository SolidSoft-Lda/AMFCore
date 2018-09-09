using System;
using System.Text;
using System.Collections;
using SolidSoft.AMFCore.Context;
using SolidSoft.AMFCore.Messaging.Messages;
using SolidSoft.AMFCore.Messaging.Services.Messaging;
using SolidSoft.AMFCore.Messaging.Api;

namespace SolidSoft.AMFCore.Messaging
{
    /// <summary>
    /// Represents a client-side MessageAgent instance. 
    /// A server-side MessageClient is only created if its client-side counterpart has subscribed to a destination for pushed data (e.g. Consumer).
    /// </summary>
    /// <remarks>
    /// 	<para>Client-side Producers do not result in the creation of corresponding
    ///     server-side MessageClient instances.</para>
    /// 	<para></para>
    /// 	<para>Each MessageClient instance is bound to a client class (session) and when the
    ///     client is invalidated any associated MessageClient instances are invalidated as
    ///     well.</para>
    /// 	<para>MessageClient instances may also be timed out on a per-destination basis and
    ///     based on subscription inactivity. If no messages are pushed to the MessageClient
    ///     within the destination's subscription timeout period the MessageClient will be
    ///     shutdown.</para>
    /// 	<para>Per-destination subscription timeout should be used when inactive
    ///     subscriptions should be shut down opportunistically to preserve server
    ///     resources.</para>
    /// </remarks>
    public sealed class MessageClient : IMessageClient
	{
        private static object _syncLock = new object();

		string				_messageClientId;
		byte[]				_binaryId;

		string				_endpoint;
        IMessageConnection _connection;
        IClient _client;

		Subtopic			_subtopic;

        static Hashtable    _messageClientCreatedListeners;
        Hashtable           _messageClientDestroyedListeners;
        bool _isDisconnecting;

        private MessageClient()
        {
        }

		internal MessageClient(IClient client, string messageClientId, string endpoint)
		{
            _client = client;
            _messageClientId = messageClientId;
            _endpoint = endpoint;
            _connection = AMFContext.Current.Connection as IMessageConnection;
            if (_connection != null)
                _connection.RegisterMessageClient(this);

            if (_messageClientCreatedListeners != null)
            {
                foreach (IMessageClientListener listener in _messageClientCreatedListeners.Keys)
                    listener.MessageClientCreated(this);
            }
		}

        /// <summary>
        /// Gets an object that can be used to synchronize access. 
        /// </summary>
        public object SyncRoot { get { return _syncLock; } }

        internal IMessageConnection MessageConnection { get { return _connection; } }

        /// <summary>
        /// Gets the endpoint identity the MessageClient is subscribed to.
        /// </summary>
        public string Endpoint { get { return _endpoint; } }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
        public byte[] GetBinaryId()
		{
			if( _binaryId == null )
			{
				UTF8Encoding utf8Encoding = new UTF8Encoding();
				_binaryId = utf8Encoding.GetBytes(_messageClientId);
			}
			return _binaryId;
		}
        /// <summary>
        /// Gets the client identity.
        /// </summary>
        /// <value>The client identity.</value>
		public string ClientId
		{
			get
			{
				return _messageClientId;
			}
		}
        /// <summary>
        /// Gets whether the connection is being disconnected.
        /// </summary>
        public bool IsDisconnecting
        {
            get{ return _isDisconnecting; }
        }

        internal void SetIsDisconnecting(bool value)
        {
            _isDisconnecting = value;
        }

        /// <summary>
        /// Gets the MessageClient subtopic.
        /// </summary>
        /// <value>The MessageClient subtopic.</value>
		public Subtopic Subtopic
		{
			get{ return _subtopic; }
			set{ _subtopic = value; }
		}

        /// <summary>
        /// Adds a MessageClient created listener.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public static void AddMessageClientCreatedListener(IMessageClientListener listener)
        {
            lock(typeof(MessageClient))
            {
                if (_messageClientCreatedListeners == null)
                    _messageClientCreatedListeners = new Hashtable(1);
                _messageClientCreatedListeners[listener] = null;
            }
        }
        /// <summary>
        /// Removes a MessageClient created listener.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public static void RemoveMessageClientCreatedListener(IMessageClientListener listener)
        {
            lock (typeof(MessageClient))
            {
                if (_messageClientCreatedListeners != null)
                {
                    if (_messageClientCreatedListeners.Contains(listener))
                        _messageClientCreatedListeners.Remove(listener);
                }
            }
        }
        /// <summary>
        /// Adds a MessageClient destroy listener.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public void AddMessageClientDestroyedListener(IMessageClientListener listener)
        {
            if (_messageClientDestroyedListeners == null)
                _messageClientDestroyedListeners = new Hashtable(1);
            _messageClientDestroyedListeners[listener] = null;
        }
        /// <summary>
        /// Removes a MessageClient destroyed listener.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveMessageClientDestroyedListener(IMessageClientListener listener)
        {
            if (_messageClientDestroyedListeners != null)
            {
                if (_messageClientDestroyedListeners.Contains(listener))
                    _messageClientDestroyedListeners.Remove(listener);
            }
        }

        //Rtmpconnection.Close -> Disconnect -> Unsubscribe
        internal void Disconnect()
		{
            this.SetIsDisconnecting(true);
            Unsubscribe(false);
		}

		/// <summary>
        /// Timeout -> Unsubscribe
        /// Client -> Unsubscribe
		/// </summary>
        internal void Unsubscribe()
		{
            if (_messageClientDestroyedListeners != null)
            {
                foreach (IMessageClientListener listener in _messageClientDestroyedListeners.Keys)
                    listener.MessageClientDestroyed(this);
            }

            _client.UnregisterMessageClient(this);
        }

		internal void Timeout()
		{
			try
			{
                if (this.IsDisconnecting)
					return;

				//Timeout
				CommandMessage commandMessage = new CommandMessage();
                commandMessage.destination = Config.DestinationSettings.AMFDestination;
                commandMessage.clientId = this.ClientId;
				//Indicate that the client's session with a remote destination has timed out
				commandMessage.operation = CommandMessage.SessionInvalidateOperation;
                commandMessage.headers[MessageBase.FlexClientIdHeader] = _client.Id;

				object[] subscribers = new object[]{commandMessage.clientId};
                Unsubscribe(true);
			}
			catch (Exception)
			{
			}
		}

        private void Unsubscribe(bool timeout)
        {
            CommandMessage commandMessageUnsubscribe = new CommandMessage();
            commandMessageUnsubscribe.destination = Config.DestinationSettings.AMFDestination;
            commandMessageUnsubscribe.operation = CommandMessage.UnsubscribeOperation;
            commandMessageUnsubscribe.clientId = this.ClientId;
            if (timeout)
            {
                commandMessageUnsubscribe.headers[CommandMessage.SessionInvalidatedHeader] = true;
                commandMessageUnsubscribe.headers[CommandMessage.AMFMessageClientTimeoutHeader] = true;
                commandMessageUnsubscribe.headers[MessageBase.FlexClientIdHeader] = _client.Id;
            }
        }
	}
}
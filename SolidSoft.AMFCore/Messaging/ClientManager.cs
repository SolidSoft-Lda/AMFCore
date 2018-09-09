using System;
using System.Collections;
using SolidSoft.AMFCore.Messaging.Api;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.Messaging
{
    /// <summary>
    /// ClientManager manages clients connected to the AMFCore server.
    /// </summary>
    /// <example>
    /// 	<code lang="CS">
    /// classChatAdapter : MessagingAdapter, ISessionListener
    /// {
    ///     private Hashtable _clients;
    ///  
    ///     public ChatAdapter()
    ///     {
    ///         _clients = new Hashtable();
    ///         ClientManager.AddSessionCreatedListener(this);
    ///     }
    ///  
    ///     public void SessionCreated(IClient client)
    ///     {
    ///         lock (_clients.SyncRoot)
    ///         {
    ///             _clients.Add(client.Id, client);
    ///         }
    ///         client.AddSessionDestroyedListener(this);
    ///     }
    ///  
    ///     public void SessionDestroyed(IClient client)
    ///     {
    ///         lock (_clients.SyncRoot)
    ///         {
    ///             _clients.Remove(client.Id);
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    public class ClientManager : IClientRegistry
    {
        static object _objLock = new object();
        private static Hashtable _sessionCreatedListeners = new Hashtable();

        MessageBroker _messageBroker;
        Hashtable _clients;

        private ClientManager()
        {
        }

        internal ClientManager(MessageBroker messageBroker)
		{
            _messageBroker = messageBroker;
            _clients = new Hashtable();
		}

        internal string GetNextId()
        {
            return Guid.NewGuid().ToString("N");
        }

        #region IClientRegistry Members

        /// <summary>
        /// Returns an existing client from the message header transporting the global FlexClient Id value or creates a new one if not found.
        /// </summary>
        /// <param name="message">Message sent from client.</param>
        /// <returns>The client object.</returns>
        public IClient GetClient(IMessage message)
        {
            if (message.HeaderExists(MessageBase.FlexClientIdHeader))
            {
                string clientId = message.GetHeader(MessageBase.FlexClientIdHeader) as string;
                return GetClient(clientId);
            }
            return null;
        }
        /// <summary>
        /// Returns an existing client from a client id or creates a new one if not found.
        /// </summary>
        /// <param name="id">The identity of the client to return.</param>
        /// <returns>The client object.</returns>
        public IClient GetClient(string id)
        {
            lock (_objLock)
            {
                if (_clients.ContainsKey(id))
                {
                    return _clients[id] as Client;
                }
                if (id == null || id == "nil" || id == string.Empty)
                    id = Guid.NewGuid().ToString("N");
                Client client = new Client(this, id);
                int clientLeaseTime = 1;
                Renew(client, clientLeaseTime);
                return client;
            }
        }
        /// <summary>
        /// Check if a client with a given id exists.
        /// </summary>
        /// <param name="id">The identity of the client to check for.</param>
        /// <returns><c>true</c> if the client exists, <c>false</c> otherwise.</returns>
        public bool HasClient(string id)
        {
            if (id == null)
                return false;
            lock (_objLock)
            {
                return _clients.ContainsKey(id);
            }
        }
        /// <summary>
        /// Returns an existing client from a client id.
        /// </summary>
        /// <param name="clientId">The identity of the client to return.</param>
        /// <returns>The client object if exists, null otherwise.</returns>
        public IClient LookupClient(string clientId)
        {
            if (clientId == null)
                return null;

            lock (_objLock)
            {
                Client client = null;
                if (_clients.Contains(clientId))
                {
                    client = _clients[clientId] as Client;
                }
                return client;
            }
        }


        #endregion

        internal void Renew(Client client, int clientLeaseTime)
        {
            lock (_objLock)
            {
                _clients[client.Id] = client;
                if (client.ClientLeaseTime < clientLeaseTime)
                    client.SetClientLeaseTime(clientLeaseTime);
                if (clientLeaseTime == 0)
                    client.SetClientLeaseTime(0);
            }
        }

        internal Client RemoveSubscriber(Client client)
        {
            lock (_objLock)
            {
                RemoveSubscriber(client.Id);
                return client;
            }
        }

        internal Client RemoveSubscriber(string clientId)
        {
            lock (_objLock)
            {
                Client client = _clients[clientId] as Client;
                _clients.Remove(clientId);
                return client;
            }
        }
    }
}
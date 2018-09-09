using System.Collections;
using SolidSoft.AMFCore.Collections;
using SolidSoft.AMFCore.Messaging.Messages;
using SolidSoft.AMFCore.Messaging.Api;

namespace SolidSoft.AMFCore.Messaging
{
    public class Client : AttributeStore, IClient
    {
        private static object _syncLock = new object();

        private string _id;
        private int _clientLeaseTime;
        ClientManager _clientManager;
        private CopyOnWriteArray _messageClients;
        protected CopyOnWriteDictionary _connectionToScope = new CopyOnWriteDictionary();
        private bool _polling;

        internal Client(ClientManager clientManager, string id)
        {
            _clientManager = clientManager;
            _id = id;
            _clientLeaseTime = 1;
            _polling = false;
        }

        internal IList MessageClients
        {
            get
            {
                if (_messageClients == null)
                {
                    lock (this.SyncRoot)
                    {
                        if (_messageClients == null)
                            _messageClients = new CopyOnWriteArray();
                    }
                }
                return _messageClients;
            }
        }

        public void Register(IConnection connection)
        {
            _connectionToScope.Add(connection, connection.Scope);
        }

        public void Unregister(IConnection connection)
        {
            _connectionToScope.Remove(connection);
            if (_connectionToScope.Count == 0)
            {
                // This client is not connected to any scopes, remove from registry.
                Disconnect();
            }
        }

        internal void SetClientLeaseTime(int value)
        {
            _clientLeaseTime = value;
        }

        #region IClient Members

        public string Id
        {
            get { return _id; }
        }

        public int ClientLeaseTime 
        {
            get { return _clientLeaseTime; }
        }

        public object SyncRoot { get { return _syncLock; } }

        public ICollection Scopes
        {
            get { return _connectionToScope.Values; }
        }

        public ICollection Connections
        {
            get { return _connectionToScope.Keys; }
        }

        public void RegisterMessageClient(IMessageClient messageClient)
        {
            if (!this.MessageClients.Contains(messageClient))
            {
                this.MessageClients.Add(messageClient);
            }
        }

        public void UnregisterMessageClient(IMessageClient messageClient)
        {
            //This operation was possibly initiated by this client
            if (messageClient.IsDisconnecting)
                return;
            if (this.MessageClients.Contains(messageClient))
            {
                this.MessageClients.Remove(messageClient);
            }
            if (this.MessageClients.Count == 0)
            {
                Disconnect();
            }
        }

        public void Disconnect(bool timeout)
        {
            lock (this.SyncRoot)
            {
                //restore context
                IConnection currentConnection = null;
                if (this.Connections != null && this.Connections.Count > 0)
                {
                    IEnumerator enumerator = this.Connections.GetEnumerator();
                    enumerator.MoveNext();
                    currentConnection = enumerator.Current as IConnection;
                }
                _clientManager.RemoveSubscriber(this);
                if (_messageClients != null)
                {
                    foreach (MessageClient messageClient in _messageClients)
                    {
                        if (timeout)
                            messageClient.Timeout();
                        else
                            messageClient.Disconnect();
                    }
                    _messageClients.Clear();
                }
                foreach (IConnection connection in this.Connections)
                {
                    if (timeout)
                        connection.Timeout();
                    connection.Close();
                }
            }
        }

        public void Disconnect()
        {
            Disconnect(false);
        }

        public void Timeout()
        {
            Disconnect(true);
        }

        public IMessage[] GetPendingMessages(int waitIntervalMillis)
        {
            ArrayList messages = new ArrayList();
            _polling = true;
            do
            {
                _clientManager.LookupClient(this._id);//renew

                if (waitIntervalMillis == 0)
                {
                    _polling = false;
                    return messages.ToArray(typeof(IMessage)) as IMessage[];
                }
                if (messages.Count > 0)
                {
                    _polling = false;
                    return messages.ToArray(typeof(IMessage)) as IMessage[];
                }
                System.Threading.Thread.Sleep(500);
                waitIntervalMillis -= 500;
                if (waitIntervalMillis <= 0)
                    _polling = false;
            }
            while(_polling);
            return messages.ToArray(typeof(IMessage)) as IMessage[];
        }

        /// <summary>
        /// Renews a lease.
        /// </summary>
        public void Renew()
        {
            _clientManager.LookupClient(_id);
        }
        /// <summary>
        /// Renews a lease.
        /// </summary>
        /// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
        public void Renew(int clientLeaseTime)
        {
            _clientManager.Renew(this, clientLeaseTime);
        }

        #endregion

        public override string ToString()
        {
            return "Client " + _id.ToString();
        }
    }
}
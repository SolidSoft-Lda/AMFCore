namespace SolidSoft.AMFCore.Messaging.Messages
{
	/// <summary>
	/// A message that represents an infrastructure command passed between client and server. 
	/// Subscribe/unsubscribe operations result in CommandMessage transmissions, as do polling operations.
	/// </summary>
    
    public class CommandMessage : AsyncMessage
	{
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public const string AuthenticationMessageRefType = "flex.messaging.messages.AuthenticationMessage";
		/// <summary>
		/// This operation is used to test connectivity over the current channel to the remote endpoint (Flex client).
		/// </summary>
		public const int FlexPingOperation = 5;
		/// <summary>
		/// This operation is used to test connectivity over the current channel to the remote endpoint (Royale client).
		/// </summary>
		public const int RoyalePingOperation = 13;
		/// <summary>
		/// This operation is used to subscribe to a remote destination.
		/// </summary>
		public const int SubscribeOperation = 0;
		/// <summary>
		/// This operation is used to unsubscribe from a remote destination.
		/// </summary>
		public const int UnsubscribeOperation = 1;
		/// <summary>
		/// This is the default operation for new CommandMessage instances. 
		/// </summary>
		public const int UnknownOperation = 10000;
		/// <summary>
		/// This operation is used to poll a remote destination for pending, undelivered messages.
		/// </summary>
		public const int PollOperation = 2;
		/// <summary>
		/// This operation is used by a remote destination to sync missed or cached messages back to a client as a result of a client issued poll command.
		/// </summary>
		public const int ClientSyncOperation = 4;
		/// <summary>
		/// This operation is used to request a list of failover endpoint URIs for the remote destination based on cluster membership.
		/// </summary>
		public const int ClusterRequestOperation = 7;
		/// <summary>
		/// This operation is used to indicate that the client's session with a remote destination has timed out.
		/// </summary>
		public const int SessionInvalidateOperation = 10;

		/// <summary>
		/// The name for the selector header in subscribe messages.
		/// </summary>
		public static string SelectorHeader = "DSSelector";
		/// <summary>
		/// The name for the header used internaly on the server to indicate that an 
		///	unsubscribe message is due to a client session being invalidated. 
		/// </summary>
		public static string SessionInvalidatedHeader = "DSSessionInvalidated";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public static string AMFMessageClientTimeoutHeader = "AMFMessageClientTimeout";
        /// <summary>
        /// Poll wait must be suppressed.
        /// </summary>
        internal static string AMFSuppressPollWaitHeader = "AMFSuppressPollWait";


		string _messageRefType;
		int _operation;


		/// <summary>
		/// Initializes a new instance of the CommandMessage class.
		/// The message id is set to a universally unique 
		/// value, and the timestamp for the message is set to the current system timestamp. 
		/// The operation is set to a default value of UnknownOperation.
		/// </summary>
		public CommandMessage()
		{
			_operation = CommandMessage.UnknownOperation;
		}
		/// <summary>
		/// Initializes a new instance of the CommandMessage class. The message id is set to a 
		/// universally unique value, and the timestamp for the message is set 
		/// to the current system timestamp.
		/// </summary>
        /// <param name="operation">Operation for the new CommandMessage instance.</param>
		public CommandMessage(int operation)
		{
			_operation = operation;
		}
		/// <summary>
		/// Gets or sets the message reference type for the CommandMessage.
		/// </summary>
		public string messageRefType
		{
			get{ return _messageRefType; }
			set{ _messageRefType = value; }
		}
		/// <summary>
		/// Gets or sets the operation for this CommandMessage.
		/// </summary>
		public int operation
		{
			get{ return _operation; }
			set{ _operation = value; }
		}
	}
}
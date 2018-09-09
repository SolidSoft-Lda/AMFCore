namespace SolidSoft.AMFCore.Messaging.Messages
{
	/// <summary>
	/// RemotingMessages are used to send RPC requests to a remote endpoint. These messages use the operation property to specify which method to call on the remote object. The destination property indicates what object/service should be used.
	/// </summary>
    
    public class RemotingMessage : MessageBase
	{
		string _source;
		string _operation;
		/// <summary>
		/// Initializes a new instance of the RemotingMessage class.
		/// </summary>
		public RemotingMessage()
		{
		}
		/// <summary>
		/// Gets or sets the underlying source of a RemoteObject destination.
		/// </summary>
		/// <remarks>
		/// This property is provided for backwards compatibility. The best practice, however, is 
		/// to not expose the underlying source of a RemoteObject destination on the client 
		/// and only one source to a destination. Some types of Remoting Services may even ignore 
		/// this property for security reasons.
		/// </remarks>
		public string source
		{
			get{ return _source; }
			set{ _source = value; }
		}
		/// <summary>
		/// Gets or sets the name of the remote method/operation that should be called.
		/// </summary>
		public string operation
		{
			get{ return _operation; }
			set{ _operation = value; }
		}
	}
}
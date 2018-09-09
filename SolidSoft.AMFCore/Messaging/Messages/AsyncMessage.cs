namespace SolidSoft.AMFCore.Messaging.Messages
{
	/// <summary>
	/// AsyncMessage contains information necessary to perform point-to-point or publish-subscribe messaging.
	/// </summary>
    
    public class AsyncMessage : MessageBase
	{
		/// <summary>
		/// Messages sent by a MessageAgent with a defined subtopic property indicate their target subtopic in this header.
		/// </summary>
		public const string SubtopicHeader = "DSSubtopic";
        /// <summary>
        /// Correlation id for the AsyncMessage.
        /// </summary>
		protected string _correlationId;
		/// <summary>
		/// Initializes a new instance of the AsyncMessage class.
		/// </summary>
		public AsyncMessage()
		{
		}
		/// <summary>
		/// Gets or sets the correlation id of the message.
		/// </summary>
		/// <remarks>
		/// Used for acknowledgement and for segmentation of messages. The correlationId contains the messageId of the previous message that this message refers to.
		/// </remarks>
		public string correlationId
		{
			get{ return _correlationId; }
			set{ _correlationId = value; }
		}
	}
}
using System;

namespace SolidSoft.AMFCore.Messaging.Messages
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
    public class AcknowledgeMessage : AsyncMessage
	{
        /// <summary>
        /// Initializes a new instance of the AcknowledgeMessage class.
        /// </summary>
        public AcknowledgeMessage()
		{
			_messageId = Guid.NewGuid().ToString("D");
			_timestamp = System.Environment.TickCount;
		}
	}
}
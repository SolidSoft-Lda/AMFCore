using System;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.Messaging.Messages
{
	/// <summary>
    /// Represents a Flex message object.
	/// </summary>
    public interface IMessage : ICloneable
	{
        /// <summary>
        /// Gets or sets the client identity indicating which client sent the message.
        /// </summary>
		object clientId { get; set; }
        /// <summary>
        /// Gets or sets the message destination.
        /// </summary>
		string destination { get; set; }
        /// <summary>
        /// Gets or sets the identity of the message.
        /// </summary>
        /// <remarks>This field is unique and can be used to correlate a response to the original request message.</remarks>
		string messageId { get; set; }
        /// <summary>
        /// Gets or sets the time stamp for the message.
        /// </summary>
        /// <remarks>The time stamp is the date and time that the message was sent.</remarks>
		long timestamp { get; set; }
        /// <summary>
        /// Gets or sets the validity for the message.
        /// </summary>
        /// <remarks>Time to live is the number of milliseconds that this message remains valid starting from the specified timestamp value.</remarks>
		long timeToLive { get; set; }
        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        /// <remarks>The body is the data that is delivered to the remote destination.</remarks>
		object body { get; set; }
        /// <summary>
        /// Gets or sets the headers of the message.
        /// </summary>
        /// <remarks>
        /// The headers of a message are an associative array where the key is the header name and the value is the header value.
        /// This property provides access to the specialized meta information for the specific message instance. 
        /// Flex core header names begin with a 'DS' prefix. Custom header names should start with a unique prefix to avoid name collisions.
        /// </remarks>
        Dictionary<string, object> headers { get; set; }
        /// <summary>
        /// Retrieves the specified header value.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <returns>The value associated with the specified header name.</returns>
		object GetHeader(string name);
        /// <summary>
        /// Sets a header value.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <param name="value">Value associated with the header name.</param>
		void SetHeader(string name, object value);
        /// <summary>
        /// Retrieves whether for the specified header name an associated value exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		bool HeaderExists(string name);
	}
}
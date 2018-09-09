using System;

namespace SolidSoft.AMFCore.Messaging.Api.Service
{
	/// <summary>
    /// Container for a Service Call.
	/// </summary>
    public interface IServiceCall
    {
        /// <summary>
        /// Gets a value indicating if the call was successful or not.
        /// </summary>
        bool IsSuccess { get;}
        /// <summary>
        /// Gets service method name.
        /// </summary>
        string ServiceMethodName { get;}
        /// <summary>
        /// Gets service name.
        /// </summary>
        string ServiceName { get;}
        /// <summary>
        /// Gets array of service method arguments.
        /// </summary>
        object[] Arguments { get;}
        /// <summary>
        /// Gets or sets service call status.
        /// </summary>
        byte Status { get;set;}
        /// <summary>
        /// Get or sets service call exception.
        /// </summary>
        Exception Exception { get;set;}
    }
}
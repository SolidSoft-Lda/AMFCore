﻿using System;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// Event object corresponds to the connect/disconnect events among providers/consumers and pipes.
    /// </summary>
    
    public class PipeConnectionEvent
    {
        /// <summary>
        /// A provider connects as pull mode.
        /// </summary>
	    public const int PROVIDER_CONNECT_PULL = 0;
        /// <summary>
        /// A provider connects as push mode.
        /// </summary>
	    public const int PROVIDER_CONNECT_PUSH = 1;
        /// <summary>
        /// A provider disconnects.
        /// </summary>
	    public const int PROVIDER_DISCONNECT = 2;
        /// <summary>
        /// A consumer connects as pull mode.
        /// </summary>
	    public const int CONSUMER_CONNECT_PULL = 3;
        /// <summary>
        /// A consumer connects as push mode.
        /// </summary>
	    public const int CONSUMER_CONNECT_PUSH = 4;
        /// <summary>
        /// A consumer disconnects.
        /// </summary>
	    public const int CONSUMER_DISCONNECT = 5;

        /// <summary>
        /// Provider.
        /// </summary>
        private IProvider _provider;
        /// <summary>
        /// Gets or sets pipe connection provider.
        /// </summary>
        public IProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        /// <summary>
        /// Consumer.
        /// </summary>
        private IConsumer _consumer;
        /// <summary>
        /// Gets or sets pipe connection consumer.
        /// </summary>
        public IConsumer Consumer
        {
            get { return _consumer; }
            set { _consumer = value; }
        }
        /// <summary>
        /// Event type.
        /// </summary>
        private int _type;
        /// <summary>
        /// Gets or sets event type.
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Params map.
        /// </summary>
        Dictionary<string, object> _parameterMap;
        /// <summary>
        /// Gets or sets event parameters.
        /// </summary>
        public Dictionary<string, object> ParameterMap
        {
            get { return _parameterMap; }
            set { _parameterMap = value; }
        }

        object _source;
        /// <summary>
        /// Gets or sets the vent source.
        /// </summary>
        public object Source
        {
            get { return _source; }
            set { _source = value; }
        }
        /// <summary>
        /// Construct an object with the specific pipe as the source.
        /// </summary>
        /// <param name="source">A pipe that triggers this event.</param>
        public PipeConnectionEvent(Object source)
        {
            _source = source;
        }
    }
}
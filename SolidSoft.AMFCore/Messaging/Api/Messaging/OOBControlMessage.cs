using System.Collections.Generic;

namespace SolidSoft.AMFCore.Messaging.Api.Messaging
{
    /// <summary>
    /// Out-of-band control message used by inter-components communication
    /// which are connected with pipes.
    /// Out-of-band data is a separate data stream used for specific purposes (in TCP it's referenced as "urgent data"), like lifecycle control.
    /// </summary>
    /// <remarks>
    /// 'Target' is used to represent the receiver who may be interested for receiving. It's a string of any form.
    /// </remarks>
    public class OOBControlMessage
    {
        /// <summary>
        /// Target.
        /// </summary>
        private string _target;
        /// <summary>
        /// Service name.
        /// </summary>
        private string _serviceName;
        /// <summary>
        /// Service parameters.
        /// </summary>
        private Dictionary<string, object> _serviceParameterMap;
        /// <summary>
        /// Result.
        /// </summary>
        private object _result;
        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }
        /// <summary>
        /// Gets or sets service parameters.
        /// </summary>
        public Dictionary<string, object> ServiceParameterMap
        {
            get 
            {
                if (_serviceParameterMap == null)
                    _serviceParameterMap = new Dictionary<string, object>();
                return _serviceParameterMap; 
            }
            set { _serviceParameterMap = value; }
        }
        /// <summary>
        /// Gets or sets target.
        /// </summary>
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }
        /// <summary>
        /// Gets or sets result.
        /// </summary>
        public object Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
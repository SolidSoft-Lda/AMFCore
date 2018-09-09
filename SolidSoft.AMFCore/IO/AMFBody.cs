using System.Collections;
using System.Text;
using System.Collections.Generic;
using SolidSoft.AMFCore.Messaging.Messages;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
    public class AMFBody
	{
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string Recordset = "rs://";
        /// <summary>
        /// Suffix to denote a success.
        /// </summary>
        public const string OnResult = "/onResult";
        /// <summary>
        /// Suffix to denote a failure.
        /// </summary>
        public const string OnStatus = "/onStatus";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string OnDebugEvents = "/onDebugEvents";
        
        /// <summary>
        /// The actual data associated with the operation.
        /// </summary>
        protected object _content;
        /// <summary>
        /// Response URI which specifies a unique operation name that will be used to match the response to the client invocation.
        /// </summary>
		protected string	_response;
        /// <summary>
        /// Target URI describes which operation, function, or method is to be remotely invoked.
        /// </summary>
		protected string	_target;
		/// <summary>
		/// IgnoreResults is a flag to tell the serializer to ignore the results of the body message.
		/// </summary>
		protected bool	_ignoreResults;
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        protected bool _isAuthenticationAction;
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        protected bool _isDebug;
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        protected bool _isDescribeService;

		/// <summary>
		/// Initializes a new instance of the AMFBody class.
		/// </summary>
		public AMFBody()
		{
		}
		/// <summary>
		/// Initializes a new instance of the AMFBody class.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="response"></param>
		/// <param name="content"></param>
		public AMFBody(string target, string response, object content)
		{
			this._target = target;
			this._response = response;
			this._content = content;
		}
        /// <summary>
        /// Gets or set the target URI.
        /// The target URI describes which operation, function, or method is to be remotely invoked.
        /// </summary>
		public string Target
		{
			get{ return _target; }
			set
			{ 
				_target = value;
			}
		}
        /// <summary>
        /// Indicates an empty target.
        /// </summary>
		public bool IsEmptyTarget
		{
			get
			{
				return _target == null || _target == string.Empty || _target == "null";
			}
		}
        /// <summary>
        /// Gets or sets the response URI.
        /// Response URI which specifies a unique operation name that will be used to match the response to the client invocation.
        /// </summary>
		public string Response
		{
			get{ return _response; }
			set{ _response = value; }
		}
        /// <summary>
        /// Gets or sets the actual data associated with the operation.
        /// </summary>
		public object Content
		{
			get{ return _content; }
			set{ _content = value; }
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public bool IsAuthenticationAction
		{
			get{ return _isAuthenticationAction; }
			set{ _isAuthenticationAction = value; }
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public bool IgnoreResults
		{
			get{ return _ignoreResults; }
			set{ _ignoreResults = value; }
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public bool IsRecordsetDelivery
		{
			get
			{
				if( _target.StartsWith(AMFBody.Recordset) )
					return true;
				else
					return false;
				
			}
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public string GetRecordsetArgs()
		{
			if( _target != null )
			{
				if( this.IsRecordsetDelivery )
				{
					string args = _target.Substring( AMFBody.Recordset.Length );
					args = args.Substring( 0, args.IndexOf("/") );
					return args;
				}
			}
			return null;
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public string TypeName
		{
			get
			{
				if( _target != "null" && _target != null && _target != string.Empty )
				{
					if( _target.LastIndexOf('.') != -1 )
					{
						string target = _target.Substring(0, _target.LastIndexOf('.'));
						if( this.IsRecordsetDelivery )
						{
							target = target.Substring( AMFBody.Recordset.Length );
							target = target.Substring( target.IndexOf("/") + 1 );
							target = target.Substring(0, target.LastIndexOf('.'));
						}
						return target;
					}
				}
				return null;
			}
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public string Method
		{
			get
			{
				if( _target != "null" && _target != null && _target != string.Empty )
				{
					if( _target != null && _target.LastIndexOf('.') != -1 )
					{
						string target = _target;
						if( this.IsRecordsetDelivery )
						{
							target = target.Substring( AMFBody.Recordset.Length );
							target = target.Substring( target.IndexOf("/") + 1 );
						}

						if( this.IsRecordsetDelivery )
							target = target.Substring(0, target.LastIndexOf('.'));
						string method = target.Substring(target.LastIndexOf('.')+1);

						return method;
					}
				}
				return null;
			}
		}
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public string Call
		{
			get{ return this.TypeName + "." + this.Method; }
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public string GetSignature()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append( this.Target );
			IList parameterList = GetParameterList();
			for(int i = 0; i < parameterList.Count; i++)
			{
				object parameter = parameterList[i];
				sb.Append( parameter.GetType().FullName );
			}
			return sb.ToString();
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public virtual IList GetParameterList()
		{
			IList list = null;
			if( !this.IsEmptyTarget )//Flash RPC parameters
			{
				if(!(_content is IList))
				{
                    list = new List<object>();
					list.Add(_content );
				}
				else 
					list = _content as IList;
			}
			else
			{
				object content = this.Content;
				if( content is IList )
					content = (content as IList)[0];
				IMessage message = content as IMessage;
				if( message != null )
				{
					//for RemotingMessages only now
					if( message is RemotingMessage )
					{
						list = message.body as IList;
					}
				}
			}

			if( list == null )
				list = new List<object>();
            return list;
		}

        internal void WriteBody(ObjectEncoding objectEncoding, AMFWriter writer)
        {
            writer.Reset();
            if (this.Target == null)
                writer.WriteUTF("null");
            else
                writer.WriteUTF(this.Target);

            if (this.Response == null)
                writer.WriteUTF("null");
            else
                writer.WriteUTF(this.Response);
            writer.WriteInt32(-1);

            WriteBodyData(objectEncoding, writer);
        }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        protected virtual void WriteBodyData(ObjectEncoding objectEncoding, AMFWriter writer)
        {
            object content = this.Content;
            writer.WriteData(objectEncoding, content);
        }
	}
}
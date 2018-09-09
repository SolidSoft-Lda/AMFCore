using System.Collections;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.Context
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class AMFWebContext : AMFContext
	{
        public static Dictionary<string, object> ItemsContext = new Dictionary<string, object>();

		internal AMFWebContext() : base()
		{
		}

        internal static void Initialize()
        {
            ItemsContext[AMFContext.AMFContextKey] = new AMFWebContext();
        }

		/// <summary>
		/// Gets a key-value collection that can be used to organize and share data between an IHttpModule and an IHttpHandler during an HTTP request.
		/// </summary>
		public override IDictionary Items
		{ 
			get{ return ItemsContext; }
		}

        public override SolidSoft.AMFCore.Messaging.Api.IConnection Connection
        {
            get
            {
                return this.Items[AMFContext.AMFConnectionKey] as SolidSoft.AMFCore.Messaging.Api.IConnection;
            }
        }

        internal void SetConnection(SolidSoft.AMFCore.Messaging.Api.IConnection connection)
        {
            this.Items[AMFContext.AMFConnectionKey] = connection;
        }

        internal override void SetCurrentClient(SolidSoft.AMFCore.Messaging.Api.IClient client)
        {
            this.Items[AMFContext.AMFClientKey] = client;
        }

        public override SolidSoft.AMFCore.Messaging.Api.IClient Client
        {
            get 
            { 
                return this.Items[AMFContext.AMFClientKey] as SolidSoft.AMFCore.Messaging.Api.IClient; 
            }
        }
	}
}
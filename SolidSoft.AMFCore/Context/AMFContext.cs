using System;
using System.IO;
using System.Collections;
using SolidSoft.AMFCore.Messaging.Api;

namespace SolidSoft.AMFCore.Context
{
    /// <summary>
    /// Similary to the ASP.NET Http Context class you can access the AMFCore context for the current request from any code inside the same application domain.
    /// The context information is accessed through the static property Current on the AMFCoreContext class.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For an AMF channel (Http request) the AMFCore context wrapps the underlying Http Context.
    /// </para>
    /// <para>
    /// The AMFCore context is available only when client requests are handled (both HTTP and RTMP) and is not avaliable in a newly started thread.
    /// </para>
    /// <para>
    /// It is recommended to use AMFCoreContext instead of Http Context if you do not want to tie your application to ASP.NET that would otherwise work without change with a RTMP channel (both APS.NET hosted or AMFCore Windows Service hosted).
    /// If you are using both AMF and RTMP channels from the same Flex application do not expect that the Session will always access the underlying HttpSession object. For RTMP calls the ASP.NET HttpSession object is not accessible and the Session in this case references the RTMP connection's attribute store.
    /// In this scenario the Client object can be used for identification and common storage (Flex only).
    /// </para>
    /// </remarks>
    /// <example>
    /// 	<code lang="CS">
    ///     string clientId = AMFCoreContext.Current.ClientId;
    /// </code>
    /// </example>
	public abstract class AMFContext
	{
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFContextKey = "__@amfcontext";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFTicket = "amfauthticket";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFSessionAttribute = "__@amfsession";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFConnectionKey = "__@amfconnection";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFClientKey = "__@amfclient";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFStreamIdKey = "__@amfstreamid";
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string AMFDataServiceTransaction = "__@amfdataservicetransaction";
        /// <summary>
		/// Global FlexClient Id value stored by AMFCore.
		/// </summary>
		public const string FlexClientIdHeader = "DSId";

		internal AMFContext()
		{
		}

        /// <summary>Gets the AMFCoreContext object for the current HTTP/RTMP request.</summary>
		static public AMFContext Current
		{
			get
			{
                if (AMFWebContext.ItemsContext.ContainsKey(AMFContext.AMFContextKey))
                    return AMFWebContext.ItemsContext[AMFContext.AMFContextKey] as AMFContext;
				return null;
			}
		}

        /// <summary>
        /// Gets a key-value collection that can be used to organize and share data between
        /// an IHttpModule and an IHttpHandler during an HTTP request.
        /// </summary>
		public abstract IDictionary Items { get; }

		/// <summary>
		/// Gets the base directory for this <see cref="AppDomain"/>
		/// </summary>
		public virtual string ApplicationBaseDirectory
		{
			get{ return AppDomain.CurrentDomain.BaseDirectory; }
		}

		/// <summary>
		/// Converts a path into a fully qualified local file path.
		/// If the path is relative it is taken as relative from the application base directory.
		/// </summary>
		/// <param name="path">The path to convert.</param>
		/// <returns>The fully qualified path.</returns>
		public virtual string GetFullPath(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			string baseDirectory = "";
			try
			{
				string applicationBaseDirectory = this.ApplicationBaseDirectory;
				if (applicationBaseDirectory != null)
				{
					//applicationBaseDirectory may be a URI not a local file path
					Uri applicationBaseDirectoryUri = new Uri(applicationBaseDirectory);
					if (applicationBaseDirectoryUri.IsFile)
					{
						baseDirectory = applicationBaseDirectoryUri.LocalPath;
					}
				}
			}
			catch
			{
				// Ignore URI exceptions & SecurityExceptions
			}

			if (baseDirectory != null && baseDirectory.Length > 0)
			{
				// Note that Path.Combine will return the second path if it is rooted
				return Path.GetFullPath(Path.Combine(baseDirectory, path));
			}
			return Path.GetFullPath(path);
		}
        
        /// <summary>
        /// Gets the current Connection object.
        /// </summary>
        public virtual SolidSoft.AMFCore.Messaging.Api.IConnection Connection
        {
            get { return null; }
        }

        internal virtual void SetCurrentClient(IClient client)
        {
        }
        /// <summary>
        /// Gets the current Client object.
        /// </summary>
        public abstract IClient Client { get; }
        /// <summary>
        /// Gets the current Client identity.
        /// </summary>
        public string ClientId 
        {
            get
            {
                if (this.Client != null)
                    return this.Client.Id;
                return null;
            }
        }
	}
}
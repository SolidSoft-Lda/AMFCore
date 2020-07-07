using System;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using SolidSoft.AMFCore.Context;
using SolidSoft.AMFCore.Messaging;

//Compressing http content based on "The open compression engine for ASP.NET"
//http://www.blowery.org/code/HttpCompressionModule.html
//http://www.ondotnet.com/pub/a/dotnet/2003/10/20/httpfilter.html
//http://aspnetresources.com/articles/HttpFilters.aspx
//
// Checks the Accept-Encoding HTTP header to determine if the
// client actually supports any notion of compression.  Currently
// the deflate (zlib) and gzip compression schemes are supported.
// Compress is not implemented because it uses lzw which requires a license from 
// Unisys.  For more information about the common compression types supported,
// see http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.11 for details.

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFGateway
	{
		internal const string AMFHttpCompressKey = "__@amfhttpcompress";
        internal const string AMFMessageServerKey = "__@amfmessageserver";

		static string _sourceName = null;
		static object _objLock = new object();
		static bool _initialized = false;

        static MessageServer messageServer;

		/// <summary>
		/// Initializes a new instance of the AMFCoreGateway class.
		/// </summary>
		public AMFGateway()
		{
		}


        private static string GetPageName(string requestPath)
        {
            if (requestPath.IndexOf('?') != -1)
                requestPath = requestPath.Substring(0, requestPath.IndexOf('?'));
            return requestPath.Remove(0, requestPath.LastIndexOf("/") + 1);
        }

		#region IHttpModule Members

		/// <summary>
		/// Initializes the module and prepares it to handle requests.
		/// </summary>
		public void Init()
		{
			//http://support.microsoft.com/kb/911816
			// Do this one time for each AppDomain.
			if (!_initialized) 
			{
				lock (_objLock) 
				{
					if (!_initialized) 
						_initialized = true;
				}
			}

            AMFWebContext.Initialize();

            if (messageServer == null)
            {
                lock (_objLock)
                {
                    if (messageServer == null)
                    {
                        messageServer = new MessageServer();
                        try
                        {
                            messageServer.Init();
                            messageServer.Start();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
		}

		/// <summary>
		/// Disposes of the resources (other than memory) used by the module that implements IHttpModule.
		/// </summary>
		public void Dispose()
		{
		}

		#endregion

        void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            try
            {
                lock (_objLock)
                {
                    if (messageServer != null)
                        messageServer.Stop();
                    messageServer = null;
                }
            }
            catch (Exception)
            { }
        }

		/// <summary>
		/// Occurs just before ASP.NET begins executing a handler such as a page or XML Web service.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

        public async Task PreRequest(object context)
        {
            if (DependencyInjection.HttpContextManager.HttpContext.GetContentType() == ContentType.AMF)
            {
                DependencyInjection.HttpContextManager.HttpContext.Clear(context);
                DependencyInjection.HttpContextManager.HttpContext.SetContentType(ContentType.AMF);

                try
                {
                    AMFWebContext.Initialize();

                    if (messageServer != null)
                        await messageServer.Service();

                    DependencyInjection.HttpContextManager.HttpContext.Finish(context);
                }
                catch (Exception)
                {
                    DependencyInjection.HttpContextManager.HttpContext.Clear(context);
                    DependencyInjection.HttpContextManager.HttpContext.Finish(context);
                }
            }
        }

		#region kb911816

		private void WireAppDomain()
		{
			string webenginePath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "webengine.dll");
			if (File.Exists(webenginePath))
			{
				//This requires .NET Framework 2.0
				FileVersionInfo ver = FileVersionInfo.GetVersionInfo(webenginePath);
				_sourceName = string.Format(CultureInfo.InvariantCulture, "ASP.NET {0}.{1}.{2}.0", ver.FileMajorPart, ver.FileMinorPart, ver.FileBuildPart);
			}

            AppDomain.CurrentDomain.DomainUnload += new EventHandler(CurrentDomain_DomainUnload);
		}

		#endregion kb911816

        public static bool ReturnsDateTimeAsDateString
        {
            get;
            set;
        }
	}
}
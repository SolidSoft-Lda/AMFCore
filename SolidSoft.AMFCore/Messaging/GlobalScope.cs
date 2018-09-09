using SolidSoft.AMFCore.Messaging.Api;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
    /// The global scope that acts as root for all applications in a host.
	/// </summary>
	public class GlobalScope : Scope, IGlobalScope
	{
        internal GlobalScope()
		{
		}

		#region IGlobalScope Members

        public SolidSoft.AMFCore.Messaging.Api.IServiceProvider ServiceProvider
        {
            get { return _serviceContainer; }
        }

		public void Register()
		{
            Init();
		}

		#endregion
	}
}
using System.Threading.Tasks;
using SolidSoft.AMFCore.Configuration;
using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ServiceMapFilter : AbstractFilter
	{
		EndpointBase _endpoint;

		/// <summary>
		/// Initializes a new instance of the ServiceMapFilter class.
		/// </summary>
		/// <param name="endpoint"></param>
		public ServiceMapFilter(EndpointBase endpoint)
		{
			_endpoint = endpoint;
		}

		#region IFilter Members

		public override Task Invoke(AMFContext context)
		{
			for(int i = 0; i < context.AMFMessage.BodyCount; i++)
			{
				AMFBody amfBody = context.AMFMessage.GetBodyAt(i);

				if( !amfBody.IsEmptyTarget )
				{//Flash
					if( AMFConfiguration.Instance.ServiceMap != null )
					{

						string typeName = amfBody.TypeName;
						string method = amfBody.Method;
						if( typeName != null && AMFConfiguration.Instance.ServiceMap.Contains(typeName) )
						{
							string serviceLocation = AMFConfiguration.Instance.ServiceMap.GetServiceLocation(typeName);
							method = AMFConfiguration.Instance.ServiceMap.GetMethod(typeName, method);
							string target = serviceLocation + "." + method;
							amfBody.Target = target;
						}
					}
				}
			}

            return Task.FromResult<object>(null);
        }

		#endregion
	}
}
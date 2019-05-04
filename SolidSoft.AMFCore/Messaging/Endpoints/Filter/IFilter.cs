using System.Threading.Tasks;

namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IFilter
	{
		/// <summary>
		/// Gets or sets the next filter.
		/// </summary>
		IFilter Next {get; set;}
		/// <summary>
		/// Invokes the filter.
		/// </summary>
		/// <param name="context"></param>
        Task Invoke(AMFContext context);
    }
}
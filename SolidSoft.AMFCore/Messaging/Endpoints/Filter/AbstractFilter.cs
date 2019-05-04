using System.Threading.Tasks;

namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal abstract class AbstractFilter : IFilter
	{
		IFilter		_next;

		/// <summary>
		/// Initializes a new instance of the AbstractFilter class.
		/// </summary>
		public AbstractFilter()
		{
		}

		#region IFilter Members

		public virtual IFilter Next
		{
			get
			{
				return _next;
			}
			set
			{
				_next = value;
			}
		}

        public virtual Task Invoke(AMFContext context)
        {
            return Task.FromResult<object>(null);
        }

		#endregion
	}
}
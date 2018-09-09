namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class FilterChain
	{
		IFilter _filter;

		/// <summary>
		/// Initializes a new instance of the FilterChain class.
		/// </summary>
		/// <param name="filter"></param>
		public FilterChain(IFilter filter)
		{
			_filter = filter;
		}

		public void InvokeFilters(AMFContext context)
		{
			IFilter filter = _filter;
			while(filter != null)
			{
				filter.Invoke(context);
				filter = filter.Next;
			}
		}
	}
}
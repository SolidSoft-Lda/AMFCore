using System.Threading.Tasks;
using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class SerializationFilter : AbstractFilter
	{
		bool _useLegacyCollection = false;
		/// <summary>
		/// Initializes a new instance of the SerializationFilter class.
		/// </summary>
		public SerializationFilter()
		{
		}

		public bool UseLegacyCollection
		{
			get{ return _useLegacyCollection; }
			set{ _useLegacyCollection = value; }
		}

		#region IFilter Members

        public override Task Invoke(AMFContext context)
        {
			AMFSerializer serializer = new AMFSerializer(context.OutputStream);
			serializer.UseLegacyCollection = _useLegacyCollection;
			serializer.WriteMessage(context.MessageOutput);
			serializer.Flush();
            return Task.FromResult<object>(null);
        }

		#endregion
	}
}
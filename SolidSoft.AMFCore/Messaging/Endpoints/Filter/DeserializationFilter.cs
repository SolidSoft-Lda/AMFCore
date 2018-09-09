using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DeserializationFilter : AbstractFilter
	{
		bool _useLegacyCollection = false;
		/// <summary>
		/// Initializes a new instance of the DeserializationFilter class.
		/// </summary>
		public DeserializationFilter()
		{
		}

		public bool UseLegacyCollection
		{
			get{ return _useLegacyCollection; }
			set{ _useLegacyCollection = value; }
		}

		#region IFilter Members

		public override void Invoke(AMFContext context)
		{
			AMFDeserializer deserializer = new AMFDeserializer(context.InputStream);
			deserializer.UseLegacyCollection = _useLegacyCollection;
			AMFMessage amfMessage = deserializer.ReadAMFMessage();
			context.AMFMessage = amfMessage;
			context.MessageOutput = new MessageOutput(amfMessage.Version);
			if( deserializer.FailedAMFBodies.Length > 0 )
			{
				AMFBody[] failedAMFBodies = deserializer.FailedAMFBodies;
				//Write out failed AMFBodies
				for(int i = 0; i < failedAMFBodies.Length; i++)
					context.MessageOutput.AddBody( failedAMFBodies[i] );
			}
		}

		#endregion
	}
}
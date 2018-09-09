namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0ObjectReader : IAMFReader
	{
		public AMF0ObjectReader()
		{
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			object amfObject = reader.ReadObject();
			return amfObject;
		}

		#endregion
	}
}
namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0DateTimeReader : IAMFReader
	{
		public AMF0DateTimeReader()
		{
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			return reader.ReadDateTime();
		}

		#endregion
	}
}
namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0LongStringReader : IAMFReader
	{
		public AMF0LongStringReader()
		{
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			int length = reader.ReadInt32();
			return reader.ReadUTF(length);
		}

		#endregion
	}
}
namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0ASObjectReader : IAMFReader
	{
		public AMF0ASObjectReader()
		{
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			return reader.ReadASObject();
		}

		#endregion
	}
}
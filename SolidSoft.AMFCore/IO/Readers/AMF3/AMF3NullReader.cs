namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3NullReader : IAMFReader
	{
		public AMF3NullReader()
		{
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			return null;
		}

		#endregion
	}
}
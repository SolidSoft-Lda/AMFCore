namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0AMF3TagWriter : IAMFWriter
	{
		public AMF0AMF3TagWriter()
		{
		}

		#region IAMFWriter Members

		public bool IsPrimitive{ get{return false;} }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF0TypeCode.AMF3Tag);
			writer.WriteAMF3Data(data);
		}

		#endregion
	}
}
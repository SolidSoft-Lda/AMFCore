namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0ASObjectWriter : IAMFWriter
	{
		public AMF0ASObjectWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{return false;} }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteASO(ObjectEncoding.AMF0, data as ASObject);
		}

		#endregion
	}
}
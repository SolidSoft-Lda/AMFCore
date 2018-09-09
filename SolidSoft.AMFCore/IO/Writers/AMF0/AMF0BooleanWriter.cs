namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0BooleanWriter : IAMFWriter
	{
		public AMF0BooleanWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{ return true; } }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF0TypeCode.Boolean);
			writer.WriteBoolean((bool)data);
		}

		#endregion
	}
}
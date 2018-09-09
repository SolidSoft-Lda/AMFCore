using System;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3DateTimeWriter : IAMFWriter
	{
		public AMF3DateTimeWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{ return true; }}

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF3TypeCode.DateTime);
			writer.WriteAMF3DateTime((DateTime)data);
		}

		#endregion
	}
}
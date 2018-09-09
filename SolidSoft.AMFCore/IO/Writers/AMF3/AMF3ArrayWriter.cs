using System;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3ArrayWriter : IAMFWriter
	{
		public AMF3ArrayWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{ return false; } }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF3TypeCode.Array);
			writer.WriteAMF3Array(data as Array);
		}

		#endregion
	}
}
using System;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0EnumWriter : IAMFWriter
	{
		public AMF0EnumWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{ return true; } }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF0TypeCode.Number);
			double dbl = (double)Convert.ToInt32(data);
			writer.WriteDouble(dbl);
		}

		#endregion
	}
}
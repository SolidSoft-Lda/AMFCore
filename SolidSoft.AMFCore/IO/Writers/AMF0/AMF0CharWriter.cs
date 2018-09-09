using System;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0CharWriter : IAMFWriter
	{
		public AMF0CharWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{ return true; } }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF0TypeCode.String);
			writer.WriteUTF( new String( (char)data, 1)  );
		}

		#endregion
	}
}
﻿namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3ASObjectWriter : IAMFWriter
	{
		public AMF3ASObjectWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{return false;} }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteByte(AMF3TypeCode.Object);
			writer.WriteAMF3Object(data);
		}

		#endregion
	}
}
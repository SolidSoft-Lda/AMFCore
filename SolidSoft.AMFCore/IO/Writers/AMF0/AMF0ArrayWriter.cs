using System;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0ArrayWriter : IAMFWriter
	{
		public AMF0ArrayWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{ return false; } }

		public void WriteData(AMFWriter writer, object data)
		{
			writer.WriteArray(ObjectEncoding.AMF0, data as Array);
		}

		#endregion
	}
}
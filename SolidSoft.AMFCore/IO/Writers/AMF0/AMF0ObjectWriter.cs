using System;
using System.Collections;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0ObjectWriter : IAMFWriter
	{
		public AMF0ObjectWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{return false;} }

		public void WriteData(AMFWriter writer, object data)
		{
			if( data is IList )
			{
				IList list = data as IList;
				object[] array = new object[list.Count];
				list.CopyTo(array, 0);
				writer.WriteArray(ObjectEncoding.AMF0, array);
				return;
			}
			if(data is IDictionary)
			{
				writer.WriteAssociativeArray(ObjectEncoding.AMF0, data as IDictionary);
				return;
			}
			if(data is Exception)
			{
				writer.WriteASO(ObjectEncoding.AMF0, new ExceptionASO(data as Exception) );
				return;
			}
			writer.WriteObject(ObjectEncoding.AMF0, data);
		}

		#endregion
	}
}
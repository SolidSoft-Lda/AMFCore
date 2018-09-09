using System;
using System.Collections;
using SolidSoft.AMFCore.AMF3;

namespace SolidSoft.AMFCore.IO.Writers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF3ObjectWriter : IAMFWriter
	{
		public AMF3ObjectWriter()
		{
		}
		#region IAMFWriter Members

		public bool IsPrimitive{ get{return false;} }

		public void WriteData(AMFWriter writer, object data)
		{
			if( data is IList )
			{
				//http://livedocs.macromedia.com/flex/2/docs/wwhelp/wwhimpl/common/html/wwhelp.htm?context=LiveDocs_Parts&file=00001104.html#270405
				//http://livedocs.macromedia.com/flex/2/docs/wwhelp/wwhimpl/common/html/wwhelp.htm?context=LiveDocs_Parts&file=00001105.html#268711

				if( writer.UseLegacyCollection )
				{
					writer.WriteByte(AMF3TypeCode.Array);
					writer.WriteAMF3Array(data as IList);
				}
				else
				{
					writer.WriteByte(AMF3TypeCode.Object);
					object value = new ArrayCollection(data as IList);
					writer.WriteAMF3Object(value);
				}
				return;
			}
			if(data is IDictionary)
			{
				writer.WriteByte(AMF3TypeCode.Object);
				writer.WriteAMF3Object(data);
				return;
			}
			if(data is Exception)
			{
				writer.WriteByte(AMF3TypeCode.Object);
				writer.WriteAMF3Object(new ExceptionASO(data as Exception) );
				return;
			}
			if( data is IExternalizable )
			{
				writer.WriteByte(AMF3TypeCode.Object);
				writer.WriteAMF3Object(data);
				return;
			}

			writer.WriteByte(AMF3TypeCode.Object);
			writer.WriteAMF3Object(data);
		}

		#endregion
	}
}
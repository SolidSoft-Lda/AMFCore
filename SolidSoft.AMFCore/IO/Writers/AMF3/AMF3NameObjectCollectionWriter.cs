using System;
using System.Collections.Specialized;
using System.Reflection;

namespace SolidSoft.AMFCore.IO.Writers
{
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class AMF3NameObjectCollectionWriter : IAMFWriter
    {
		public AMF3NameObjectCollectionWriter()
		{
		}
		
#region IAMFWriter Members

		public bool IsPrimitive{ get{return false;} }

        public void WriteData(AMFWriter writer, object data)
        {
            NameObjectCollectionBase collection = data as NameObjectCollectionBase;
            object[] attributes = collection.GetType().GetCustomAttributes(typeof(DefaultMemberAttribute), false);
            if (attributes != null  && attributes.Length > 0)
            {
                DefaultMemberAttribute defaultMemberAttribute = attributes[0] as DefaultMemberAttribute;
                PropertyInfo pi = collection.GetType().GetProperty(defaultMemberAttribute.MemberName, new Type[] { typeof(string) });
                if (pi != null)
                {
                    ASObject aso = new ASObject();
                    for (int i = 0; i < collection.Keys.Count; i++)
                    {
                        string key = collection.Keys[i];
                        object value = pi.GetValue(collection, new object[]{ key });
                        aso.Add(key, value);
                    }
                    writer.WriteByte(AMF3TypeCode.Object);
                    writer.WriteAMF3Object(aso);
                    return;
                }
            }

            //We could not access an indexer so write out as it is.
            writer.WriteByte(AMF3TypeCode.Object);
            writer.WriteAMF3Object(data);
        }

#endregion
    }
}
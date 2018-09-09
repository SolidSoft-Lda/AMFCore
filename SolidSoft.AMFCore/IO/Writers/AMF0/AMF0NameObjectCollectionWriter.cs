using System;
using System.Collections.Specialized;
using System.Reflection;

namespace SolidSoft.AMFCore.IO.Writers
{
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class AMF0NameObjectCollectionWriter : IAMFWriter
    {
        public AMF0NameObjectCollectionWriter()
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
                    writer.WriteASO(ObjectEncoding.AMF0, aso);
                    return;
                }
            }

            //We could not access an indexer so write out as it is.
            writer.WriteObject(ObjectEncoding.AMF0, data);
        }

#endregion

    }
}
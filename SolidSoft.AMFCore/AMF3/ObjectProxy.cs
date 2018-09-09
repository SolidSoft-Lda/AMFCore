using System;
using System.Collections;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.AMF3
{
	/// <summary>
	/// Flex ObjectProxy class.
	/// </summary>
    
    public class ObjectProxy : Dictionary<string, Object>
	{
		public ObjectProxy()
		{
		}

		#region IExternalizable Members

        /// <summary>
        /// Decode the ObjectProxy from a data stream.
        /// </summary>
        /// <param name="input">IDataInput interface.</param>
        public void ReadExternal(IDataInput input)
		{
			object value = input.ReadObject();
			if( value is IDictionary )
			{
                IDictionary dictionary = value as IDictionary;
                foreach (DictionaryEntry entry in dictionary)
				{
					this.Add(entry.Key as string, entry.Value);
				}
			}
		}
        /// <summary>
        /// Encode the ObjectProxy for a data stream.
        /// </summary>
        /// <param name="output">IDataOutput interface.</param>
        public void WriteExternal(IDataOutput output)
		{
			ASObject asObject = new ASObject();
			foreach(KeyValuePair<string, object> entry in this)
            {
				asObject.Add(entry.Key, entry.Value);
			}
			output.WriteObject(asObject);
		}

		#endregion
	}
}
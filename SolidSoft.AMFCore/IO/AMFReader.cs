﻿using System;
using System.Xml;
using System.Collections;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using SolidSoft.AMFCore.Exceptions;
using SolidSoft.AMFCore.AMF3;
using SolidSoft.AMFCore.Configuration;
using SolidSoft.AMFCore.IO.Readers;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFReader : BinaryReader
	{
		bool _useLegacyCollection = true;
        bool _faultTolerancy = false;
        Exception _lastError;

        List<Object> _amf0ObjectReferences;
        List<Object> _objectReferences;
        List<Object> _stringReferences;
        List<ClassDefinition> _classDefinitions;

        private static IAMFReader[][] AmfTypeTable;

		static AMFReader()
		{
			IAMFReader[] amf0Readers = new IAMFReader[]
			{
				new AMF0NumberReader(), /*0*/
				new AMF0BooleanReader(), /*1*/
				new AMF0StringReader(), /*2*/
				new AMF0ASObjectReader(), /*3*/
				new AMFUnknownTagReader(), 
				new AMF0NullReader(), /*5*/
				new AMF0NullReader(), /*6*/
				new AMF0ReferenceReader(), /*7*/
				new AMF0AssociativeArrayReader(), /*8*/
				new AMFUnknownTagReader(), 
				new AMF0ArrayReader(), /*10*/
				new AMF0DateTimeReader(), /*11*/
				new AMF0LongStringReader(), /*12*/
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMF0XmlReader(), /*15*/
                new AMF0ObjectReader(), /*16*/
				new AMF0AMF3TagReader() /*17*/
			};

			IAMFReader[] amf3Readers = new IAMFReader[]
			{
				new AMF3NullReader(), /*0*/
				new AMF3NullReader(), /*1*/
				new AMF3BooleanFalseReader(), /*2*/
				new AMF3BooleanTrueReader(), /*3*/
				new AMF3IntegerReader(), /*4*/
				new AMF3NumberReader(), /*5*/
				new AMF3StringReader(), /*6*/
				new AMF3XmlReader(), /*7*/
				new AMF3DateTimeReader(), /*8*/
				new AMF3ArrayReader(),  /*9*/
                new AMF3ObjectReader(), /*10*/
				new AMF3XmlReader(), /*11*/
				new AMF3ByteArrayReader(), /*12*/
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader()
			};

            AmfTypeTable = new IAMFReader[4][] { amf0Readers, null, null, amf3Readers };
		}

		/// <summary>
		/// Initializes a new instance of the AMFReader class based on the supplied stream and using UTF8Encoding.
		/// </summary>
		/// <param name="stream"></param>
		public AMFReader(Stream stream) : base(stream)
		{
			Reset();
		}
        /// <summary>
        /// Resets object references.
        /// </summary>
		public void Reset()
		{
            _amf0ObjectReferences = new List<Object>(5);
            _objectReferences = new List<Object>(15);
            _stringReferences = new List<Object>(15);
            _classDefinitions = new List<ClassDefinition>(2);
            _lastError = null;
		}
        /// <summary>
        /// Gets or sets whether legacy collection serialization is used for AMF3.
        /// </summary>
        public bool UseLegacyCollection
		{
			get{ return _useLegacyCollection; }
			set{ _useLegacyCollection = value; }
		}
        /// <summary>
        /// Indicates whether reflection errors should raise an exception or set the LastError property.
        /// </summary>
        public bool FaultTolerancy
        {
            get { return _faultTolerancy; }
            set { _faultTolerancy = value; }
        }
        /// <summary>
        /// Returns the last exception that ocurred while deserializing an object.
        /// </summary>
        /// <returns></returns>
        public Exception LastError
        {
            get { return _lastError; }
        }
        /// <summary>
        /// Deserializes object graphs from Action Message Format (AMF).
        /// </summary>
        /// <returns>The Object deserialized from the AMF stream.</returns>
		public object ReadData()
		{
			byte typeCode = ReadByte();
			return ReadData(typeCode);
		}
		/// <summary>
        /// Deserializes an object using the specified type marker.
		/// </summary>
        /// <param name="typeMarker">Type marker.</param>
        /// <returns>The Object deserialized from the AMF stream.</returns>
		public object ReadData(byte typeMarker)
		{
            return AmfTypeTable[0][typeMarker].ReadData(this);
		}
        /// <summary>
        /// Reads a reference type.
        /// </summary>
        /// <returns>The Object deserialized from the AMF stream.</returns>
		public object ReadReference()
		{
			int reference = ReadUInt16();
			//return _amf0ObjectReferences[reference-1];
            return _amf0ObjectReferences[reference];
		}
		/// <summary>
        /// Reads a 2-byte unsigned integer from the current AMF stream using network byte order encoding and advances the position of the stream by two bytes.
		/// </summary>
        /// <returns>The 2-byte unsigned integer.</returns>
        
        public override ushort ReadUInt16()
		{
			//Read the next 2 bytes, shift and add.
			byte[] bytes = ReadBytes(2);
			return (ushort)(((bytes[0] & 0xff) << 8) | (bytes[1] & 0xff));
		}
        /// <summary>
        /// Reads a 2-byte signed integer from the current AMF stream using network byte order encoding and advances the position of the stream by two bytes.
        /// </summary>
        /// <returns>The 2-byte signed integer.</returns>
        public override short ReadInt16()
		{
			//Read the next 2 bytes, shift and add.
			byte[] bytes = ReadBytes(2);
			return (short)((bytes[0] << 8) | bytes[1]);
		}
        /// <summary>
        /// Reads an UTF-8 encoded String from the current AMF stream.
        /// </summary>
        /// <returns>The String value.</returns>
		public override string ReadString()
		{
			//Get the length of the string (first 2 bytes).
			int length = ReadUInt16();
			return ReadUTF(length);
		}
        /// <summary>
        /// Reads a Boolean value from the current AMF stream using network byte order encoding and advances the position of the stream by one byte.
        /// </summary>
        /// <returns>The Boolean value.</returns>
        public override bool ReadBoolean()
		{
			return base.ReadBoolean();
		}
        /// <summary>
        /// Reads a 4-byte signed integer from the current AMF stream using network byte order encoding and advances the position of the stream by four bytes.
        /// </summary>
        /// <returns>The 4-byte signed integer.</returns>
		public override int ReadInt32()
		{
			// Read the next 4 bytes, shift and add
			byte[] bytes = ReadBytes(4);
			int value = (int)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
            return value;
		}
        /// <summary>
        /// Reads a 3-byte signed integer from the current AMF stream using network byte order encoding and advances the position of the stream by three bytes.
        /// </summary>
        /// <returns>The 3-byte signed integer.</returns>
        public int ReadUInt24()
        {
            byte[] bytes = this.ReadBytes(3);
            int value = bytes[0] << 16 | bytes[1] << 8 | bytes[2];
            return value;
        }
        /// <summary>
        /// Reads an 8-byte IEEE-754 double precision floating point number from the current AMF stream using network byte order encoding and advances the position of the stream by eight bytes.
        /// </summary>
        /// <returns>The 8-byte double precision floating point number.</returns>
		public override double ReadDouble()
		{			
			byte[] bytes = ReadBytes(8);
			byte[] reverse = new byte[8];
			//Grab the bytes in reverse order 
			for(int i = 7, j = 0 ; i >= 0 ; i--, j++)
			{
				reverse[j] = bytes[i];
			}
			double value = BitConverter.ToDouble(reverse, 0);
			return value;
		}
        /// <summary>
        /// Reads a single-precision floating point number from the current AMF stream using network byte order encoding and advances the position of the stream by eight bytes.
        /// </summary>
        /// <returns>The single-precision floating point number.</returns>
		public float ReadFloat()
		{			
			byte[] bytes = this.ReadBytes(4);
			byte[] invertedBytes = new byte[4];
			//Grab the bytes in reverse order from the backwards index
			for(int i = 3, j = 0 ; i >= 0 ; i--, j++)
			{
				invertedBytes[j] = bytes[i];
			}
			float value = BitConverter.ToSingle(invertedBytes, 0);
			return value;
		}
        /// <summary>
        /// Add object reference.
        /// </summary>
        /// <param name="instance">The object instance.</param>
		public void AddReference(object instance)
		{
			_amf0ObjectReferences.Add(instance);
		}
        /// <summary>
        /// Reads an AMF0 object.
        /// </summary>
        /// <returns>The Object deserialized from the AMF stream.</returns>
		public object ReadObject()
		{
			string typeIdentifier = ReadString();

            Type type = ObjectFactory.Locate(typeIdentifier);
			if( type != null )
			{
				object instance = ObjectFactory.CreateInstance(type);
                this.AddReference(instance);

				string key = ReadString();
                for (byte typeCode = ReadByte(); typeCode != AMF0TypeCode.EndOfObject; typeCode = ReadByte())
				{
					object value = ReadData(typeCode);
                    SetMember(instance, key, value);
					key = ReadString();
				}
                return instance;
			}
			else
			{
				ASObject asObject;
				//Reference added in ReadASObject
                asObject = ReadASObject();
				asObject.TypeName = typeIdentifier;
				return asObject;
			}
		}
        /// <summary>
        /// Reads an anonymous ActionScript object.
        /// </summary>
        /// <returns>The anonymous ActionScript object deserialized from the AMF stream.</returns>
		public ASObject ReadASObject()
		{
			ASObject asObject = new ASObject();
			AddReference(asObject);
			string key = this.ReadString();
			for(byte typeCode = ReadByte(); typeCode != AMF0TypeCode.EndOfObject; typeCode = ReadByte())
			{
				//asObject.Add(key, ReadData(typeCode));
                asObject[key] = ReadData(typeCode);
				key = ReadString();
			}
			return asObject;
		}
        /// <summary>
        /// Reads an UTF-8 encoded String.
        /// </summary>
        /// <param name="length">Byte-length header.</param>
        /// <returns>The String value.</returns>
		public string ReadUTF(int length)
		{
			if( length == 0 )
                return string.Empty;
			UTF8Encoding utf8 = new UTF8Encoding(false, true);
			byte[] encodedBytes = this.ReadBytes(length);
            string decodedString = utf8.GetString(encodedBytes, 0, encodedBytes.Length);
            return decodedString;
		}
		/// <summary>
        /// Reads an UTF-8 encoded AMF0 Long String type.
		/// </summary>
        /// <returns>The String value.</returns>
		public string ReadLongString()
		{
			int length = this.ReadInt32();
			return this.ReadUTF(length);
		}

        /// <summary>
        /// Reads an An ECMA or associative Array.
        /// </summary>
        /// <returns>The associative Array.</returns>
        internal Dictionary<string, Object> ReadAssociativeArray()
        {
            // Get the length property set by flash.
            int length = this.ReadInt32();
            Dictionary<string, Object> result = new Dictionary<string, Object>(length);
            AddReference(result);
            string key = ReadString();
            for (byte typeCode = ReadByte(); typeCode != AMF0TypeCode.EndOfObject; typeCode = ReadByte())
            {
                object value = ReadData(typeCode);
                result.Add(key, value);
                key = ReadString();
            }
            return result;
        }
        /// <summary>
        /// Reads an AMF0 strict Array.
        /// </summary>
        /// <returns>The Array.</returns>
		internal IList ReadArray()
		{
			//Get the length of the array.
			int length = ReadInt32();
			object[] array = new object[length];
			//ArrayList array = new ArrayList(length);
			AddReference(array);
			for(int i = 0; i < length; i++)
			{
				array[i] = ReadData();
				//array.Add( ReadData() );
			}
			return array;
		} 
        /// <summary>
        /// Reads an ActionScript Date.
        /// </summary>
        /// <returns>The DateTime.</returns>
		public DateTime ReadDateTime()
		{
			double milliseconds = this.ReadDouble();
			DateTime start = new DateTime(1970, 1, 1);

			DateTime date = start.AddMilliseconds(milliseconds);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            int tmp = ReadUInt16();
			//Note for the latter than values greater than 720 (12 hours) are 
			//represented as 2^16 - the value.
			//Thus GMT+1 is 60 while GMT-5 is 65236
			if(tmp > 720)
				tmp = (65536 - tmp);
			int tz = tmp / 60;
			switch(AMFConfiguration.Instance.TimezoneCompensation)
			{
				case TimezoneCompensation.None:
					break;
				case TimezoneCompensation.Auto:
					date = date.AddHours(tz);
                    date = DateTime.SpecifyKind(date, DateTimeKind.Unspecified);
					break;
			}

			return date;
		}
 
        /// <summary>
        /// Reads an XML Document Type.
        /// The XML document type is always encoded as a long UTF-8 string.
        /// </summary>
        /// <returns>The XmlDocument.</returns>
		public XmlDocument ReadXmlDocument()
		{
			string text = this.ReadLongString();
			XmlDocument document = new XmlDocument();
            if( text != null && text != string.Empty)
			    document.LoadXml(text);
			return document;
		}

		#region AMF3

        /// <summary>
        /// Deserializes object graphs from Action Message Format (AMF3).
        /// </summary>
        /// <returns>The Object deserialized from the AMF stream.</returns>
        public object ReadAMF3Data()
		{
			byte typeCode = this.ReadByte();
			return this.ReadAMF3Data(typeCode);
		}
        /// <summary>
        /// Deserializes an object using the specified type marker.
        /// </summary>
        /// <param name="typeMarker">Type marker.</param>
        /// <returns>The Object deserialized from the AMF stream.</returns>
        public object ReadAMF3Data(byte typeMarker)
		{
            return AmfTypeTable[3][typeMarker].ReadData(this);
		}
        /// <summary>
        /// Add object reference.
        /// </summary>
        /// <param name="instance">The object instance.</param>
        public void AddAMF3ObjectReference(object instance)
        {
            _objectReferences.Add(instance);
        }
        /// <summary>
        /// Reads a reference type.
        /// </summary>
        /// <returns>The Object deserialized from the AMF stream.</returns>
        public object ReadAMF3ObjectReference(int index)
        {
            return _objectReferences[index];
        }
		/// <summary>
		/// Handle decoding of the variable-length representation which gives seven bits of value per serialized byte by using the high-order bit 
		/// of each byte as a continuation flag.
		/// </summary>
		/// <returns></returns>
		public int ReadAMF3IntegerData()
		{
			int acc = ReadByte();
			int tmp;
			if(acc < 128)
				return acc;
			else
			{
				acc = (acc & 0x7f) << 7;
				tmp = this.ReadByte();
				if(tmp < 128)
					acc = acc | tmp;
				else
				{
					acc = (acc | tmp & 0x7f) << 7;
					tmp = this.ReadByte();
					if(tmp < 128)
						acc = acc | tmp;
					else
					{
						acc = (acc | tmp & 0x7f) << 8;
						tmp = this.ReadByte();
						acc = acc | tmp;
					}
				}
			}
			//To sign extend a value from some number of bits to a greater number of bits just copy the sign bit into all the additional bits in the new format.
			//convert/sign extend the 29bit two's complement number to 32 bit
			int mask = 1 << 28; // mask
			int r = -(acc & mask) | acc;
			return r;

			//The following variation is not portable, but on architectures that employ an 
			//arithmetic right-shift, maintaining the sign, it should be fast. 
			//s = 32 - 29;
			//r = (x << s) >> s;
		}
        /// <summary>
        /// Reads a 4-byte signed integer from the current AMF stream.
        /// </summary>
        /// <returns>The 4-byte signed integer.</returns>
		public int ReadAMF3Int()
		{
			int intData = ReadAMF3IntegerData();
			return intData;
		}
        /// <summary>
        /// Reads an ActionScript Date.
        /// </summary>
        /// <returns>The DateTime.</returns>
        public DateTime ReadAMF3Date()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1)  != 0 );
			handle = handle >> 1;
			if( inline )
			{
				double milliseconds = this.ReadDouble();
				DateTime start = new DateTime(1970, 1, 1, 1, 0, 0);

				DateTime date = start.AddMilliseconds(milliseconds);
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
                AddAMF3ObjectReference(date);
				return date;
			}
			else
			{
				return (DateTime)ReadAMF3ObjectReference(handle);
			}
		}

        internal void AddStringReference(string str)
        {
            _stringReferences.Add(str);
        }

        internal string ReadStringReference(int index)
        {
            return _stringReferences[index] as string;
        }
        /// <summary>
        /// Reads an UTF-8 encoded String from the current AMF stream.
        /// </summary>
        /// <returns>The String value.</returns>
        public string ReadAMF3String()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1) != 0 );
			handle = handle >> 1;
			if( inline )
			{
				int length = handle;
                if (length == 0)
                    return string.Empty;
				string str = ReadUTF(length);
                AddStringReference(str);
				return str;
			}
			else
			{
				return ReadStringReference(handle);
			}
		}

        /// <summary>
        /// Reads an XML Document Type.
        /// The XML document type is always encoded as a long UTF-8 string.
        /// </summary>
        /// <returns>The XmlDocument.</returns>
        public XmlDocument ReadAMF3XmlDocument()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1) != 0 );
			handle = handle >> 1;
			string xml = string.Empty;
			if( inline )
			{
                if (handle > 0)//length
				    xml = this.ReadUTF(handle);
                AddAMF3ObjectReference(xml);
			}
			else
			{
				xml = ReadAMF3ObjectReference(handle) as string;
			}
			XmlDocument xmlDocument = new XmlDocument();
            if (xml != null && xml != string.Empty)
                xmlDocument.LoadXml(xml);
			return xmlDocument;
		}

        /// <summary>
        /// Reads a ByteArray.
        /// </summary>
        /// <returns>The ByteArray instance.</returns>
        /// <remarks>
        /// 	<para>ActionScript 3.0 introduces a new type to hold an Array of bytes, namely
        ///     ByteArray. AMF 3 serializes this type using a variable length encoding 29-bit
        ///     integer for the byte-length prefix followed by the raw bytes of the ByteArray.
        ///     ByteArray instances can be sent as a reference to a previously occurring ByteArray
        ///     instance by using an index to the implicit object reference table.</para>
        /// 	<para>Note that this encoding imposes some theoretical limits on the use of
        ///     ByteArray. The maximum byte-length of each ByteArray instance is limited to 2^28 -
        ///     1 bytes (approx 256 MB).</para>
        /// </remarks>
        
		public ByteArray ReadAMF3ByteArray()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1) != 0 );
			handle = handle >> 1;
			if( inline )
			{
				int length = handle;
				byte[] buffer = ReadBytes(length);
				ByteArray ba = new ByteArray(buffer);
				AddAMF3ObjectReference(ba);
				return ba;
			}
			else
				return ReadAMF3ObjectReference(handle) as ByteArray;
		}
        /// <summary>
        /// Reads an AMF3 Array (string or associative).
        /// </summary>
        /// <returns>The Array instance.</returns>
		public object ReadAMF3Array()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1)  != 0 ); handle = handle >> 1;
			if( inline )
			{
                Dictionary<string, object> hashtable = null;
                string key = ReadAMF3String();
                while (key != null && key != string.Empty)
				{
					if( hashtable == null )
					{
                        hashtable = new Dictionary<string, object>();
						AddAMF3ObjectReference(hashtable);
					}
					object value = ReadAMF3Data();
					hashtable.Add(key, value);
					key = ReadAMF3String();
				}
				//Not an associative array
				if( hashtable == null )
				{
                    object[] array = new object[handle];
                    AddAMF3ObjectReference(array);
					for(int i = 0; i < handle; i++)
					{
						//Grab the type for each element.
						byte typeCode = this.ReadByte();
						object value = ReadAMF3Data(typeCode);
						array[i] = value;
					}
					return array;
				}
				else
				{
					for(int i = 0; i < handle; i++)
					{
						object value = ReadAMF3Data();
						hashtable.Add( i.ToString(), value);
					}
					return hashtable;
				}
			}
			else
			{
				return ReadAMF3ObjectReference(handle);
			}
		}

        internal void AddClassReference(ClassDefinition classDefinition)
        {
            _classDefinitions.Add(classDefinition);
        }

        internal ClassDefinition ReadClassReference(int index)
        {
            return _classDefinitions[index] as ClassDefinition;
        }

		internal ClassDefinition ReadClassDefinition(int handle)
		{
			ClassDefinition classDefinition = null;
			//an inline object
			bool inlineClassDef = ((handle & 1) != 0 );handle = handle >> 1;
			if( inlineClassDef )
			{
				//inline class-def
				string typeIdentifier = ReadAMF3String();
				//flags that identify the way the object is serialized/deserialized
				bool externalizable = ((handle & 1) != 0 );handle = handle >> 1;
				bool dynamic = ((handle & 1) != 0 );handle = handle >> 1;

                ClassMember[] members = new ClassMember[handle];
				for (int i = 0; i < handle; i++)
				{
                    string name = ReadAMF3String();
                    ClassMember classMember = new ClassMember(name, BindingFlags.Default, MemberTypes.Custom);
                    members[i] = classMember;
				}
				classDefinition = new ClassDefinition(typeIdentifier, members, externalizable, dynamic);
				AddClassReference(classDefinition);
			}
			else
			{
				//A reference to a previously passed class-def
				classDefinition = ReadClassReference(handle);
			}
			return classDefinition;
		}

        internal object ReadAMF3Object(ClassDefinition classDefinition)
        {
            object instance = null;
            if (classDefinition.ClassName != null && classDefinition.ClassName != string.Empty)
                instance = ObjectFactory.CreateInstance(classDefinition.ClassName);
            else
                instance = new ASObject();
            if (instance == null)
                instance = new ASObject(classDefinition.ClassName);
            AddAMF3ObjectReference(instance);
            if (classDefinition.IsExternalizable)
            {
                if (instance is IExternalizable)
                {
                    IExternalizable externalizable = instance as IExternalizable;
                    DataInput dataInput = new DataInput(this);
                    externalizable.ReadExternal(dataInput);
                }
                else
                {
                    string msg = __Res.GetString(__Res.Externalizable_CastFail, instance.GetType().FullName);
                    throw new AMFException(msg);
                }
            }
            else
            {
                for (int i = 0; i < classDefinition.MemberCount; i++)
                {
                    string key = classDefinition.Members[i].Name;
                    object value = ReadAMF3Data();
                    SetMember(instance, key, value);
                }
                if (classDefinition.IsDynamic)
                {
                    string key = ReadAMF3String();
                    while (key != null && key != string.Empty)
                    {
                        object value = ReadAMF3Data();
                        SetMember(instance, key, value);
                        key = ReadAMF3String();
                    }
                }
            }
            return instance;
        }
        /// <summary>
        /// Reads an AMF3 object.
        /// </summary>
        /// <returns>The Object deserialized from the AMF stream.</returns>
        public object ReadAMF3Object()
        {
            int handle = ReadAMF3IntegerData();
            bool inline = ((handle & 1) != 0); handle = handle >> 1;
            if (!inline)
            {
                //An object reference
                return ReadAMF3ObjectReference(handle);
            }
            else
            {
                ClassDefinition classDefinition = ReadClassDefinition(handle);
                object obj = ReadAMF3Object(classDefinition);
                return obj;
            }
        }

		#endregion AMF3

        internal void SetMember(object instance, string memberName, object value)
        {
            if (instance is ASObject)
            {
                ((ASObject)instance)[memberName] = value;
                return;
            }
            Type type = instance.GetType();
            //PropertyInfo propertyInfo = type.GetProperty(memberName);
            PropertyInfo propertyInfo = null;
            try
            {
                propertyInfo = type.GetProperty(memberName);
            }
            catch (AmbiguousMatchException)
            {
                //To resolve the ambiguity, include BindingFlags.DeclaredOnly to restrict the search to members that are not inherited.
                propertyInfo = type.GetProperty(memberName, BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            }
            if (propertyInfo != null)
            {
                try
                {
                    if (propertyInfo.PropertyType == typeof(TimeSpan) || 
                        (propertyInfo.PropertyType == typeof(TimeSpan?) && value != null))
                        value = Util.Convert.ToTimeSpan(value);
                    else
                        value = TypeHelper.ChangeType(value, propertyInfo.PropertyType);

                    if (propertyInfo.CanWrite)
                    {
                        if (propertyInfo.GetIndexParameters() == null || propertyInfo.GetIndexParameters().Length == 0)
                            propertyInfo.SetValue(instance, value, null);
                        else
                        {
                            string msg = __Res.GetString(__Res.Reflection_PropertyIndexFail, string.Format("{0}.{1}", type.FullName, memberName));

                            if ( !_faultTolerancy )
                                throw new AMFException(msg);
                            else
                                _lastError = new AMFException(msg);
                        }
                    }
                    else
                    {
                        string msg = __Res.GetString(__Res.Reflection_PropertyReadOnly, string.Format("{0}.{1}", type.FullName, memberName));
                    }
                }
                catch (Exception ex)
                {
                    string msg = __Res.GetString(__Res.Reflection_PropertySetFail, string.Format("{0}.{1}", type.FullName, memberName), ex.Message);

                    if (!_faultTolerancy)
                        throw new AMFException(msg);
                    else
                        _lastError = new AMFException(msg);
                }
            }
            else
            {
                FieldInfo fi = type.GetField(memberName, BindingFlags.Public | BindingFlags.Instance);
                try
                {
                    if (fi != null)
                    {
                        if (fi.FieldType == typeof(TimeSpan))
                            value = Util.Convert.ToTimeSpan(value);
                        else
                            value = TypeHelper.ChangeType(value, fi.FieldType);

                        fi.SetValue(instance, value);
                    }
                    else
                    {
                        string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("{0}.{1}", type.FullName, memberName));
                    }
                }
                catch (Exception ex)
                {
                    string msg = __Res.GetString(__Res.Reflection_FieldSetFail, string.Format("{0}.{1}", type.FullName, memberName), ex.Message);

                    if (!_faultTolerancy)
                        throw new AMFException(msg);
                    else
                        _lastError = new AMFException(msg);
                }
            }
        }
 	}
}
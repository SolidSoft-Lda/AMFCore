﻿using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
using System.Reflection;
using SolidSoft.AMFCore.Exceptions;
using SolidSoft.AMFCore.AMF3;
using SolidSoft.AMFCore.Configuration;
using SolidSoft.AMFCore.IO.Writers;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SolidSoft.AMFCore.IO
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFWriter : BinaryWriter
	{
		bool _useLegacyCollection = true;
        Dictionary<Object, int> _amf0ObjectReferences;
        Dictionary<Object, int> _objectReferences;
        Dictionary<Object, int> _stringReferences;
        Dictionary<ClassDefinition, int> _classDefinitionReferences;
        static Dictionary<string, ClassDefinition> classDefinitions;
        static Dictionary<Type, IAMFWriter>[] AmfWriterTable;

        static AMFWriter()
		{
            Dictionary<Type, IAMFWriter> amf0Writers = new Dictionary<Type, IAMFWriter>();
            AMF0NumberWriter amf0NumberWriter = new AMF0NumberWriter();
			amf0Writers.Add(typeof(System.SByte), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Byte), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Int16), amf0NumberWriter);
			amf0Writers.Add(typeof(System.UInt16), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Int32), amf0NumberWriter);
			amf0Writers.Add(typeof(System.UInt32), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Int64), amf0NumberWriter);
			amf0Writers.Add(typeof(System.UInt64), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Single), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Double), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Decimal), amf0NumberWriter);
			amf0Writers.Add(typeof(System.DBNull), new AMF0NullWriter());
            amf0Writers.Add(typeof(CacheableObject), new AMF0CacheableObjectWriter());
			amf0Writers.Add(typeof(XmlDocument), new AMF0XmlDocumentWriter());
            amf0Writers.Add(typeof(RawBinary), new RawBinaryWriter());
            amf0Writers.Add(typeof(System.Collections.Specialized.NameObjectCollectionBase), new AMF0NameObjectCollectionWriter());
            amf0Writers.Add(typeof(XDocument), new AMF0XDocumentWriter());
            amf0Writers.Add(typeof(XElement), new AMF0XElementWriter());
            amf0Writers.Add(typeof(Guid), new AMF0GuidWriter());
			amf0Writers.Add(typeof(string), new AMF0StringWriter());
			amf0Writers.Add(typeof(bool), new AMF0BooleanWriter());
			amf0Writers.Add(typeof(Enum), new AMF0EnumWriter());
			amf0Writers.Add(typeof(Char), new AMF0CharWriter());
            amf0Writers.Add(typeof(DateTime), new AMF0DateTimeWriter());
			amf0Writers.Add(typeof(Array), new AMF0ArrayWriter());
			amf0Writers.Add(typeof(ASObject), new AMF0ASObjectWriter());

            Dictionary<Type, IAMFWriter> amf3Writers = new Dictionary<Type, IAMFWriter>();
			AMF3IntWriter amf3IntWriter = new AMF3IntWriter();
			AMF3DoubleWriter amf3DoubleWriter = new AMF3DoubleWriter();
			amf3Writers.Add(typeof(System.SByte), amf3IntWriter);
			amf3Writers.Add(typeof(System.Byte), amf3IntWriter);
			amf3Writers.Add(typeof(System.Int16), amf3IntWriter);
			amf3Writers.Add(typeof(System.UInt16), amf3IntWriter);
			amf3Writers.Add(typeof(System.Int32), amf3IntWriter);
			amf3Writers.Add(typeof(System.UInt32), amf3IntWriter);
			amf3Writers.Add(typeof(System.Int64), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.UInt64), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.Single), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.Double), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.Decimal), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.DBNull), new AMF3DBNullWriter());
            amf3Writers.Add(typeof(CacheableObject), new AMF3CacheableObjectWriter());
			amf3Writers.Add(typeof(XmlDocument), new AMF3XmlDocumentWriter());
            amf3Writers.Add(typeof(RawBinary), new RawBinaryWriter());            
            amf3Writers.Add(typeof(System.Collections.Specialized.NameObjectCollectionBase), new AMF3NameObjectCollectionWriter());
            amf3Writers.Add(typeof(XDocument), new AMF3XDocumentWriter());
            amf3Writers.Add(typeof(XElement), new AMF3XElementWriter());
            amf3Writers.Add(typeof(Guid), new AMF3GuidWriter());
			amf3Writers.Add(typeof(string), new AMF3StringWriter());
			amf3Writers.Add(typeof(bool), new AMF3BooleanWriter());
			amf3Writers.Add(typeof(Enum), new AMF3EnumWriter());
			amf3Writers.Add(typeof(Char), new AMF3CharWriter());
            amf3Writers.Add(typeof(DateTime), new AMF3DateTimeWriter());
			amf3Writers.Add(typeof(Array), new AMF3ArrayWriter());
			amf3Writers.Add(typeof(ASObject), new AMF3ASObjectWriter());
			amf3Writers.Add(typeof(ByteArray), new AMF3ByteArrayWriter());
            AmfWriterTable = new Dictionary<Type, IAMFWriter>[4] { amf0Writers, null, null, amf3Writers };
            classDefinitions = new Dictionary<string, ClassDefinition>();
        }

		/// <summary>
		/// Initializes a new instance of the AMFReader class based on the supplied stream and using UTF8Encoding.
		/// </summary>
		/// <param name="stream"></param>
		public AMFWriter(Stream stream) : base(stream)
		{
			Reset();
		}

        internal AMFWriter(AMFWriter writer, Stream stream)
            : base(stream)
        {
            _amf0ObjectReferences = writer._amf0ObjectReferences;
            _objectReferences = writer._objectReferences;
            _stringReferences = writer._stringReferences;
            _classDefinitionReferences = writer._classDefinitionReferences;
            _useLegacyCollection = writer._useLegacyCollection;
        }
        /// <summary>
        /// Resets object references.
        /// </summary>
		public void Reset()
		{
            _amf0ObjectReferences = new Dictionary<Object, int>(5);
            _objectReferences = new Dictionary<Object, int>(5);
            _stringReferences = new Dictionary<Object, int>(5);
            _classDefinitionReferences = new Dictionary<ClassDefinition, int>();
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
        /// Writes a byte to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A byte to write to the stream.</param>
		public void WriteByte(byte value)
		{
			this.BaseStream.WriteByte(value);
		}
        /// <summary>
        /// Writes a stream of bytes to the current position in the AMF stream.
        /// </summary>
        /// <param name="buffer">The memory buffer containing the bytes to write to the AMF stream</param>
		public void WriteBytes(byte[] buffer)
		{
			for(int i = 0; buffer != null && i < buffer.Length; i++)
				this.BaseStream.WriteByte(buffer[i]);
		}
        /// <summary>
        /// Writes a 16-bit unsigned integer to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        public void WriteShort(int value)
		{
            byte[] bytes = BitConverter.GetBytes((ushort)value);
			WriteBigEndian(bytes);
		}
        /// <summary>
        /// Writes an UTF-8 string to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">The UTF-8 string.</param>
        /// <remarks>Standard or long string header is written depending on the string length.</remarks>
		public void WriteString(string value)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding(true, true);
            int byteCount = utf8Encoding.GetByteCount(value);
			if( byteCount < 65536 )
			{
				WriteByte(AMF0TypeCode.String);
                WriteUTF(value);
			}
			else
			{
				WriteByte(AMF0TypeCode.LongString);
                WriteLongUTF(value);
			}
		}
        /// <summary>
        /// Writes a UTF-8 string to the current position in the AMF stream.
        /// The length of the UTF-8 string in bytes is written first, as a 16-bit integer, followed by the bytes representing the characters of the string.
        /// </summary>
        /// <param name="value">The UTF-8 string.</param>
        /// <remarks>Standard or long string header is not written.</remarks>
        public void WriteUTF(string value)
		{
			//null string is not accepted
			//in case of custom serialization leads to TypeError: Error #2007: Parameter value must be non-null.  at flash.utils::ObjectOutput/writeUTF()

			//Length - max 65536.
			UTF8Encoding utf8Encoding = new UTF8Encoding();
            int byteCount = utf8Encoding.GetByteCount(value);
            byte[] buffer = utf8Encoding.GetBytes(value);
			this.WriteShort(byteCount);
			if (buffer.Length > 0)
				base.Write(buffer);
		}
        /// <summary>
        /// Writes a UTF-8 string to the current position in the AMF stream.
        /// Similar to WriteUTF, but does not prefix the string with a 16-bit length word.
        /// </summary>
        /// <param name="value">The UTF-8 string.</param>
        /// <remarks>Standard or long string header is not written.</remarks>
        public void WriteUTFBytes(string value)
		{
			//Length - max 65536.
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			byte[] buffer = utf8Encoding.GetBytes(value);
			if (buffer.Length > 0)
				base.Write(buffer);
		}

        private void WriteLongUTF(string value)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding(true, true);
            uint byteCount = (uint)utf8Encoding.GetByteCount(value);
			byte[] buffer = new Byte[byteCount+4];
			//unsigned long (always 32 bit, big endian byte order)
			buffer[0] = (byte)((byteCount >> 0x18) & 0xff);
			buffer[1] = (byte)((byteCount >> 0x10) & 0xff);
			buffer[2] = (byte)((byteCount >> 8) & 0xff);
			buffer[3] = (byte)((byteCount & 0xff));
            int bytesEncodedCount = utf8Encoding.GetBytes(value, 0, value.Length, buffer, 4);
            if (buffer.Length > 0)
                base.BaseStream.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
        /// Serializes object graphs in Action Message Format (AMF).
		/// </summary>
        /// <param name="objectEncoding">AMF version to use.</param>
        /// <param name="data">The Object to serialize in the AMF stream.</param>
		public void WriteData(ObjectEncoding objectEncoding, object data)
		{
			//If we have ObjectEncoding.AMF3 anything that serializes to String, Number, Boolean, Date will use AMF0 encoding
			//For other types we have to switch the encoding to AMF3
			if( data == null )
			{
				WriteNull();
				return;
			}
			Type type = data.GetType();
            if (AMFConfiguration.Instance.AcceptNullValueTypes && AMFConfiguration.Instance.NullableValues != null)
			{
				if( AMFConfiguration.Instance.NullableValues.ContainsKey(type) && data.Equals(AMFConfiguration.Instance.NullableValues[type]) )
				{
					WriteNull();
					return;
				}
			}
			if( _amf0ObjectReferences.ContainsKey( data ) )
			{
				WriteReference( data );
				return;
			}

            IAMFWriter amfWriter = null;
            if( AmfWriterTable[0].ContainsKey(type) )
                amfWriter = AmfWriterTable[0][type] as IAMFWriter;
			//Second try with basetype (enums and arrays for example)
            if (amfWriter == null && AmfWriterTable[0].ContainsKey(type.BaseType))
                amfWriter = AmfWriterTable[0][type.BaseType] as IAMFWriter;

			if( amfWriter == null )
			{
				lock(AmfWriterTable)
				{
                    if (!AmfWriterTable[0].ContainsKey(type))
					{
						amfWriter = new AMF0ObjectWriter();
						AmfWriterTable[0].Add(type, amfWriter);
					}
					else
						amfWriter = AmfWriterTable[0][type] as IAMFWriter;
				}
			}

			if( amfWriter != null )
			{
				if( objectEncoding == ObjectEncoding.AMF0 )
					amfWriter.WriteData(this, data);
				else
				{
					if( amfWriter.IsPrimitive )
						amfWriter.WriteData(this, data);
					else
					{
						WriteByte(AMF0TypeCode.AMF3Tag);
						WriteAMF3Data(data);
					}
				}
			}
			else
			{
                string msg = __Res.GetString(__Res.TypeSerializer_NotFound, type.FullName);
				throw new AMFException(msg);
			}
		}

		internal void AddReference(object value)
		{
			_amf0ObjectReferences.Add( value, _amf0ObjectReferences.Count);
		}

		internal void WriteReference(object value)
		{
			//Circular references
			WriteByte(AMF0TypeCode.Reference);
			WriteShort((int)_amf0ObjectReferences[value]);
		}
        /// <summary>
        /// Writes a null type marker to the current position in the AMF stream.
        /// </summary>
		public void WriteNull()
		{
			WriteByte(AMF0TypeCode.Null);
		}
        /// <summary>
        /// Writes a double-precision floating point number to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
		public void WriteDouble(double value)
		{
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBigEndian(bytes);
		}
        /// <summary>
        /// Writes a single-precision floating point number to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteFloat(float value)
		{
			byte[] bytes = BitConverter.GetBytes(value);			
			WriteBigEndian(bytes);
		}
        /// <summary>
        /// Writes a 32-bit signed integer to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteInt32(int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			WriteBigEndian(bytes);
		}
        /// <summary>
        /// Writes a 32-bit signed integer to the current position in the AMF stream using variable length unsigned 29-bit integer encoding.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteUInt24(int value)
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0xFF & (value >> 16));
            bytes[1] = (byte)(0xFF & (value >> 8));
            bytes[2] = (byte)(0xFF & (value >> 0));
            this.BaseStream.Write(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// Writes a Boolean value to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteBoolean(bool value)
		{
            this.BaseStream.WriteByte(value ? ((byte)1) : ((byte)0));
		}
        /// <summary>
        /// Writes a 64-bit signed integer to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteLong(long value)
		{
            byte[] bytes = BitConverter.GetBytes(value);
			WriteBigEndian(bytes);
		}

		private void WriteBigEndian(byte[] bytes)
		{
			if( bytes == null )
				return;
			for(int i = bytes.Length-1; i >= 0; i--)
			{
				base.BaseStream.WriteByte( bytes[i] );
			}
		}
        /// <summary>
        /// Writes a DateTime value to the current position in the AMF stream.
        /// An ActionScript Date is serialized as the number of milliseconds elapsed since the epoch of midnight on 1st Jan 1970 in the UTC time zone.
        /// </summary>
        /// <param name="value">A DateTime value.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteDateTime(DateTime value)
		{
            value = value.ToUniversalTime();

            // Write date (milliseconds from 1970).
			DateTime timeStart = new DateTime(1970, 1, 1);
            TimeSpan span = value.Subtract(timeStart);
			long milliSeconds = (long)span.TotalMilliseconds;
            WriteDouble((double)milliSeconds);
            span = TimeZoneInfo.Local.GetUtcOffset(value);
			//whatever we write back, it is ignored
			//this.WriteLong(span.TotalMinutes);
			//this.WriteShort((int)span.TotalHours);
			//this.WriteShort(65236);
			if( AMFConfiguration.Instance.TimezoneCompensation == TimezoneCompensation.None )
				this.WriteShort(0);
			else
				this.WriteShort((int)(span.TotalMilliseconds/60000));
        }

        /// <summary>
        /// Writes an XmlDocument object to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">An XmlDocument object.</param>
        /// <remarks>Xml type marker is written in the AMF stream.</remarks>
        public void WriteXmlDocument(XmlDocument value)
		{
            if (value != null)
			{
                AddReference(value);
				this.BaseStream.WriteByte(AMF0TypeCode.Xml);
                string xml = value.DocumentElement.OuterXml;
				this.WriteLongUTF(xml);
			}
			else
				this.WriteNull();
		}

        public void WriteXDocument(XDocument xDocument)
        {
            if (xDocument != null)
            {
                AddReference(xDocument);
                this.BaseStream.WriteByte((byte)15);//xml code (0x0F)
                string xml = xDocument.ToString();
                this.WriteLongUTF(xml);
            }
            else
                this.WriteNull();
        }

        public void WriteXElement(XElement xElement)
        {
            if (xElement != null)
            {
                AddReference(xElement);
                this.BaseStream.WriteByte((byte)15);//xml code (0x0F)
                string xml = xElement.ToString();
                this.WriteLongUTF(xml);
            }
            else
                this.WriteNull();
        }

        /// <summary>
        /// Writes an Array value to the current position in the AMF stream.
        /// </summary>
        /// <param name="objectEcoding">Object encoding used.</param>
        /// <param name="value">An Array object.</param>
        public void WriteArray(ObjectEncoding objectEcoding, Array value)
		{
            if (value == null)
				this.WriteNull();
			else
			{
                AddReference(value);
                WriteByte(AMF0TypeCode.Array);
                WriteInt32(value.Length);
                for (int i = 0; i < value.Length; i++)
				{
                    WriteData(objectEcoding, value.GetValue(i));
				}
			}
		}
        /// <summary>
        /// Writes an associative array to the current position in the AMF stream.
        /// </summary>
        /// <param name="objectEncoding">Object encoding used.</param>
        /// <param name="value">An Dictionary object.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteAssociativeArray(ObjectEncoding objectEncoding, IDictionary value)
		{
            if (value == null)
				this.WriteNull();
			else
			{
                AddReference(value);
				WriteByte(AMF0TypeCode.AssociativeArray);
                WriteInt32(value.Count);
                foreach (DictionaryEntry entry in value)
				{
					this.WriteUTF(entry.Key.ToString());
					this.WriteData(objectEncoding, entry.Value);
				}
				this.WriteEndMarkup();
			}
		}

        /// <summary>
        /// Writes an object to the current position in the AMF stream.
        /// </summary>
        /// <param name="objectEncoding">Object encoding used.</param>
        /// <param name="obj">The object to serialize.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteObject(ObjectEncoding objectEncoding, object obj)
		{
			if( obj == null )
			{
				WriteNull();
				return;
			}
			AddReference(obj);

			Type type = obj.GetType();

			WriteByte(16);
			string customClass = type.FullName;
			customClass = AMFConfiguration.Instance.GetCustomClass(customClass);

            WriteUTF( customClass );

			PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<PropertyInfo> properties = new List<PropertyInfo>(propertyInfos);

            for (int i = properties.Count - 1; i >=0 ; i--)
			{
				PropertyInfo propertyInfo = properties[i] as PropertyInfo;

                if( propertyInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0 )
					properties.RemoveAt(i);

                if( propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0 )
					properties.RemoveAt(i);
			}
			foreach(PropertyInfo propertyInfo in properties)
			{
				WriteUTF(propertyInfo.Name);
				object value = propertyInfo.GetValue(obj, null);
				WriteData( objectEncoding, value);
			}

			FieldInfo[] fieldInfos = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

            List<FieldInfo> fields = new List<FieldInfo>(fieldInfos);

            for (int i = fields.Count - 1; i >=0 ; i--)
			{
				FieldInfo fieldInfo = fields[i] as FieldInfo;

                if( fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0 )
					fields.RemoveAt(i);
			}
			for(int i = 0; i < fields.Count; i++)
			{
                FieldInfo fieldInfo = fields[i] as FieldInfo;
				WriteUTF(fieldInfo.Name);
				WriteData( objectEncoding, fieldInfo.GetValue(obj));
			}

			WriteEndMarkup();
		}

		internal void WriteEndMarkup()
		{
			//Write the end object flag 0x00, 0x00, 0x09
			base.BaseStream.WriteByte(0);
			base.BaseStream.WriteByte(0);
			base.BaseStream.WriteByte(AMF0TypeCode.EndOfObject);
		}
        /// <summary>
        /// Writes an anonymous ActionScript object to the current position in the AMF stream.
        /// </summary>
        /// <param name="objectEncoding">Object encoding to use.</param>
        /// <param name="asObject">The ActionScript object.</param>
		public void WriteASO(ObjectEncoding objectEncoding, ASObject asObject)
		{
			if( asObject != null )
			{
				AddReference(asObject);
				if(asObject.TypeName == null)
				{
					// Object "Object"
					this.BaseStream.WriteByte(3);
				}
				else
				{
					this.BaseStream.WriteByte(16);
					this.WriteUTF(asObject.TypeName);
				}

                foreach (KeyValuePair<string, object> entry in asObject)
                {
					this.WriteUTF(entry.Key.ToString());
					this.WriteData(objectEncoding, entry.Value);
				}
				WriteEndMarkup();
			}
			else
				WriteNull();
		}

		#region AMF3


        /// <summary>
        /// Serializes object graphs in Action Message Format (AMF).
        /// </summary>
        /// <param name="data">The Object to serialize in the AMF stream.</param>
        public void WriteAMF3Data(object data)
		{
			if( data == null )
			{
				WriteAMF3Null();
				return;
			}
			if(data is DBNull )
			{
				WriteAMF3Null();
				return;
			}
            if (AMFConfiguration.Instance.AcceptNullValueTypes && AMFConfiguration.Instance.NullableValues != null)
			{
				Type type = data.GetType();
				if( AMFConfiguration.Instance.NullableValues.ContainsKey(type) && data.Equals(AMFConfiguration.Instance.NullableValues[type]) )
				{
					WriteAMF3Null();
					return;
				}
			}
            if (data is byte[])
                data = System.Convert.ToBase64String(data as byte[]);
            else if (data is DateTime || data is DateTime?)
                data = ((DateTime)data).ToString("yyyy-MM-dd");
            else if (data is TimeSpan || data is TimeSpan?)
                data = Util.Convert.ToString(data);

            IAMFWriter amfWriter = null;
            if( AmfWriterTable[3].ContainsKey(data.GetType()) )
                amfWriter = AmfWriterTable[3][data.GetType()] as IAMFWriter;
			//Second try with basetype (Enums for example)
            if (amfWriter == null && AmfWriterTable[3].ContainsKey(data.GetType().BaseType) )
				amfWriter = AmfWriterTable[3][data.GetType().BaseType] as IAMFWriter;

			if( amfWriter == null )
			{
				lock(AmfWriterTable)
				{
                    if (!AmfWriterTable[3].ContainsKey(data.GetType()))
                    {
                        amfWriter = new AMF3ObjectWriter();
                        AmfWriterTable[3].Add(data.GetType(), amfWriter);
                    }
                    else
                        amfWriter = AmfWriterTable[3][data.GetType()] as IAMFWriter;
				}
			}

			if( amfWriter != null )
			{
				amfWriter.WriteData(this, data);
			}
			else
			{
				string msg = string.Format("Could not find serializer for type {0}", data.GetType().FullName);
				throw new AMFException(msg);
			}
			//WriteByte(AMF3TypeCode.Object);
			//WriteAMF3Object(data);
		}
        /// <summary>
        /// Writes a null type marker to the current position in the AMF stream.
        /// </summary>
		public void WriteAMF3Null()
		{
			//Write the null code (0x1) to the output stream.
			WriteByte(AMF3TypeCode.Null);
		}
        /// <summary>
        /// Writes a Boolean value to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
		public void WriteAMF3Bool(bool value)
		{
			WriteByte( (byte)(value ? AMF3TypeCode.BooleanTrue : AMF3TypeCode.BooleanFalse));
		}
        /// <summary>
        /// Writes an Array value to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">An Array object.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteAMF3Array(Array value)
		{
            if (_amf0ObjectReferences.ContainsKey(value))
			{
                WriteReference(value);
				return;
			}

            if (!_objectReferences.ContainsKey(value))
			{
                _objectReferences.Add(value, _objectReferences.Count);
                int handle = value.Length;
				handle = handle << 1;
				handle = handle | 1;
				WriteAMF3IntegerData(handle);
				WriteAMF3UTF(string.Empty);//hash name
                for (int i = 0; i < value.Length; i++)
				{
                    WriteAMF3Data(value.GetValue(i));
				}
			}
			else
			{
                int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}
        /// <summary>
        /// Writes an Array value to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">An Array object.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
		public void WriteAMF3Array(IList value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);
				int handle = value.Count;
				handle = handle << 1;
				handle = handle | 1;
				WriteAMF3IntegerData(handle);
				WriteAMF3UTF(string.Empty);//hash name
				for(int i = 0; i < value.Count; i++)
				{
					WriteAMF3Data(value[i]);
				}
			}
			else
			{
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}
        /// <summary>
        /// Writes an associative array to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">An Dictionary object.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
		public void WriteAMF3AssociativeArray(IDictionary value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);
				WriteAMF3IntegerData(1);
				foreach(DictionaryEntry entry in value)
				{
					WriteAMF3UTF(entry.Key.ToString());
					WriteAMF3Data(entry.Value);
				}
				WriteAMF3UTF(string.Empty);
			}
			else
			{
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		internal void WriteByteArray(ByteArray byteArray)
		{
			_objectReferences.Add(byteArray, _objectReferences.Count);
			WriteByte(AMF3TypeCode.ByteArray);
			int handle = (int)byteArray.Length;
			handle = handle << 1;
			handle = handle | 1;
			WriteAMF3IntegerData(handle);
			WriteBytes( byteArray.MemoryStream.ToArray() );
		}
        /// <summary>
        /// Writes a UTF-8 string to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">The UTF-8 string.</param>
        /// <remarks>Standard or long string header is not written.</remarks>
		public void WriteAMF3UTF(string value)
		{
			if( value == string.Empty )
			{
				WriteAMF3IntegerData(1);
			}
			else
			{
                if (!_stringReferences.ContainsKey(value))
				{
					_stringReferences.Add(value, _stringReferences.Count);
					UTF8Encoding utf8Encoding = new UTF8Encoding();
					int byteCount = utf8Encoding.GetByteCount(value);
					int handle = byteCount;
					handle = handle << 1;
					handle = handle | 1;
					WriteAMF3IntegerData(handle);
					byte[] buffer = utf8Encoding.GetBytes(value);
					if (buffer.Length > 0)
						Write(buffer);
				}
				else
				{
					int handle = (int)_stringReferences[value];
					handle = handle << 1;
					WriteAMF3IntegerData(handle);
				}
			}
		}
        /// <summary>
        /// Writes an UTF-8 string to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">The UTF-8 string.</param>
        /// <remarks>Standard or long string header is written depending on the string length.</remarks>
        public void WriteAMF3String(string value)
		{
			WriteByte(AMF3TypeCode.String);
			WriteAMF3UTF(value);
		}
        /// <summary>
        /// Writes a DateTime value to the current position in the AMF stream.
        /// An ActionScript Date is serialized as the number of milliseconds elapsed since the epoch of midnight on 1st Jan 1970 in the UTC time zone.
        /// Local time zone information is not sent.
        /// </summary>
        /// <param name="value">A DateTime value.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteAMF3DateTime(DateTime value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);
				int handle = 1;
				WriteAMF3IntegerData(handle);

				// Write date (milliseconds from 1970).
				DateTime timeStart = new DateTime(1970, 1, 1, 0, 0, 0);
                value = value.ToUniversalTime();

                TimeSpan span = value.Subtract(timeStart);
				long milliSeconds = (long)span.TotalMilliseconds;
                WriteDouble((double)milliSeconds);
			}
			else
			{
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		private void WriteAMF3IntegerData(int value)
		{
			//Sign contraction - the high order bit of the resulting value must match every bit removed from the number
			//Clear 3 bits 
			value &= 0x1fffffff;
			if(value < 0x80)
				this.WriteByte((byte)value);
			else
				if(value < 0x4000)
			{
					this.WriteByte((byte)(value >> 7 & 0x7f | 0x80));
					this.WriteByte((byte)(value & 0x7f));
			}
			else
				if(value < 0x200000)
			{
				this.WriteByte((byte)(value >> 14 & 0x7f | 0x80));
				this.WriteByte((byte)(value >> 7 & 0x7f | 0x80));
				this.WriteByte((byte)(value & 0x7f));
			} 
			else
			{
				this.WriteByte((byte)(value >> 22 & 0x7f | 0x80));
				this.WriteByte((byte)(value >> 15 & 0x7f | 0x80));
				this.WriteByte((byte)(value >> 8 & 0x7f | 0x80));
				this.WriteByte((byte)(value & 0xff));
			}
		}
        /// <summary>
        /// Writes a 32-bit signed integer to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <remarks>Type marker is written in the AMF stream.</remarks>
		public void WriteAMF3Int(int value)
		{
			if(value >= -268435456 && value <= 268435455)//check valid range for 29bits
			{
				WriteByte(AMF3TypeCode.Integer);
				WriteAMF3IntegerData(value);
			}
			else
			{
				//overflow condition would occur upon int conversion
				WriteAMF3Double((double)value);
			}
		}
        /// <summary>
        /// Writes a double-precision floating point number to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <remarks>Type marker is written in the AMF stream.</remarks>
		public void WriteAMF3Double(double value)
		{
			WriteByte(AMF3TypeCode.Number);
			//long tmp = BitConverter.DoubleToInt64Bits( double.Parse(value.ToString()) );
            WriteDouble(value);
		}

        /// <summary>
        /// Writes an XmlDocument object to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">An XmlDocument object.</param>
        /// <remarks>Xml type marker is written in the AMF stream.</remarks>
        public void WriteAMF3XmlDocument(XmlDocument value)
		{
			WriteByte(AMF3TypeCode.Xml);
            string xml = string.Empty;
            if (value.DocumentElement != null && value.DocumentElement.OuterXml != null)
                xml = value.DocumentElement.OuterXml;
            if (xml == string.Empty)
            {
                WriteAMF3IntegerData(1);
            }
            else
            {
                if (!_objectReferences.ContainsKey(value))
                {
                    _objectReferences.Add(value, _objectReferences.Count);
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    int byteCount = utf8Encoding.GetByteCount(xml);
                    int handle = byteCount;
                    handle = handle << 1;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                    byte[] buffer = utf8Encoding.GetBytes(xml);
                    if (buffer.Length > 0)
                        Write(buffer);
                }
                else
                {
                    int handle = (int)_objectReferences[value];
                    handle = handle << 1;
                    WriteAMF3IntegerData(handle);
                }
            }
		}

        public void WriteAMF3XDocument(XDocument xDocument)
        {
            WriteByte(AMF3TypeCode.Xml);
            string value = string.Empty;
            if (xDocument != null)
                value = xDocument.ToString();
            if (value == string.Empty)
            {
                WriteAMF3IntegerData(1);
            }
            else
            {
                if (!_objectReferences.ContainsKey(value))
                {
                    _objectReferences.Add(value, _objectReferences.Count);
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    int byteCount = utf8Encoding.GetByteCount(value);
                    int handle = byteCount;
                    handle = handle << 1;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                    byte[] buffer = utf8Encoding.GetBytes(value);
                    if (buffer.Length > 0)
                        Write(buffer);
                }
                else
                {
                    int handle = (int)_objectReferences[value];
                    handle = handle << 1;
                    WriteAMF3IntegerData(handle);
                }
            }
        }

        public void WriteAMF3XElement(XElement xElement)
        {
            WriteByte(AMF3TypeCode.Xml);
            string value = string.Empty;
            if (xElement != null)
                value = xElement.ToString();
            if (value == string.Empty)
            {
                WriteAMF3IntegerData(1);
            }
            else
            {
                if (!_objectReferences.ContainsKey(value))
                {
                    _objectReferences.Add(value, _objectReferences.Count);
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    int byteCount = utf8Encoding.GetByteCount(value);
                    int handle = byteCount;
                    handle = handle << 1;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                    byte[] buffer = utf8Encoding.GetBytes(value);
                    if (buffer.Length > 0)
                        Write(buffer);
                }
                else
                {
                    int handle = (int)_objectReferences[value];
                    handle = handle << 1;
                    WriteAMF3IntegerData(handle);
                }
            }
        }

        /// <summary>
        /// Writes an object to the current position in the AMF stream.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <remarks>No type marker is written in the AMF stream.</remarks>
        public void WriteAMF3Object(object value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);

				ClassDefinition classDefinition = GetClassDefinition(value);
                if (classDefinition != null && _classDefinitionReferences.ContainsKey(classDefinition))
                {
                    //Existing class-def
                    int handle = (int)_classDefinitionReferences[classDefinition];//handle = classRef 0 1
                    handle = handle << 2;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                }
                else
				{//inline class-def
					
					classDefinition = CreateClassDefinition(value);
                    _classDefinitionReferences.Add(classDefinition, _classDefinitionReferences.Count);
					//handle = memberCount dynamic externalizable 1 1
					int handle = classDefinition.MemberCount;
					handle = handle << 1;
					handle = handle | (classDefinition.IsDynamic ? 1 : 0);
					handle = handle << 1;
					handle = handle | (classDefinition.IsExternalizable ? 1 : 0);
					handle = handle << 2;
					handle = handle | 3;
					WriteAMF3IntegerData(handle);
					WriteAMF3UTF(classDefinition.ClassName);
					for(int i = 0; i < classDefinition.MemberCount; i++)
					{
						string key = classDefinition.Members[i].Name;
						WriteAMF3UTF(key);
					}
				}
				//write inline object
				if( classDefinition.IsExternalizable )
				{
					if( value is IExternalizable )
					{
						IExternalizable externalizable = value as IExternalizable;
						DataOutput dataOutput = new DataOutput(this);
						externalizable.WriteExternal(dataOutput);
					}
					else
						throw new AMFException(__Res.GetString(__Res.Externalizable_CastFail,classDefinition.ClassName));
				}
				else
				{
					for(int i = 0; i < classDefinition.MemberCount; i++)
					{
                        object memberValue = GetMember(value, classDefinition.Members[i]);
                        WriteAMF3Data(memberValue);
					}

					if(classDefinition.IsDynamic)
					{
						IDictionary dictionary = value as IDictionary;
						foreach(DictionaryEntry entry in dictionary)
						{
							WriteAMF3UTF(entry.Key.ToString());
							WriteAMF3Data(entry.Value);
						}
						WriteAMF3UTF(string.Empty);
					}
				}
			}
			else
			{
				//handle = objectRef 0
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		private ClassDefinition GetClassDefinition(object obj)
		{
            if (obj is ASObject)
            {
                ASObject asObject = obj as ASObject;
                if (asObject.IsTypedObject && classDefinitions.ContainsKey(asObject.TypeName))
                    return classDefinitions[asObject.TypeName] as ClassDefinition;
                else
                    return null;
            }
            else
            {
                if (classDefinitions.ContainsKey(obj.GetType().FullName))
                    return classDefinitions[obj.GetType().FullName] as ClassDefinition;
                else
                    return null;
            }
		}

#if WCF
        static bool IsDataContract(Type type)
        {
            object[] attributes = type.GetCustomAttributes(typeof(System.Runtime.Serialization.DataContractAttribute), false);
            return attributes.Length == 1;
        }
#endif

		private ClassDefinition CreateClassDefinition(object obj)
		{
			ClassDefinition classDefinition = null;
            Type type = obj.GetType();
            bool externalizable = type.GetInterface(typeof(SolidSoft.AMFCore.AMF3.IExternalizable).FullName, true) != null;
			bool dynamic = false;
			string customClassName = null;
			if( obj is IDictionary )//ASObject, ObjectProxy
			{
				if( obj is ASObject && (obj as ASObject).IsTypedObject)//ASObject
				{
					ASObject asObject = obj as ASObject;
                    ClassMember[] classMemberList = new ClassMember[asObject.Count];
					int i = 0;

                    foreach (KeyValuePair<string, object> entry in asObject)
                    {
                        ClassMember classMember = new ClassMember(entry.Key as string, BindingFlags.Default, MemberTypes.Custom);
                        classMemberList[i] = classMember;
						i++;
					}
					customClassName = asObject.TypeName;
                    classDefinition = new ClassDefinition(customClassName, classMemberList, externalizable, dynamic);
                    classDefinitions[customClassName] = classDefinition;
                }
				else
				{
					dynamic = true;
					customClassName = string.Empty;
                    classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, externalizable, dynamic);
				}
			}			
			else if( obj is IExternalizable )
			{
				customClassName = type.FullName;
				customClassName = AMFConfiguration.Instance.GetCustomClass(customClassName);

				classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, true, false);
                classDefinitions[type.FullName] = classDefinition;
			}
			else
			{
                List<string> memberNames = new List<string>();
                List<ClassMember> classMemberList = new List<ClassMember>();

                PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    PropertyInfo propertyInfo = propertyInfos[i] as PropertyInfo;
                    string name = propertyInfo.Name;
                    if (propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                        continue;
                    if (propertyInfo.GetGetMethod() == null || propertyInfo.GetGetMethod().GetParameters().Length > 0)
                    {
                        //The gateway will not be able to access this property
                        string msg = __Res.GetString(__Res.Reflection_PropertyIndexFail, string.Format("{0}.{1}", type.FullName, propertyInfo.Name));
                        continue;
                    }
                    if (memberNames.Contains(name))
                        continue;
                    memberNames.Add(name);
                    BindingFlags bf = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
                    try
                    {
                        PropertyInfo propertyInfoTmp = obj.GetType().GetProperty(name);
                    }
                    catch (AmbiguousMatchException)
                    {
                        bf = BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance;
                    }
                    ClassMember classMember = new ClassMember(name, bf, propertyInfo.MemberType);
                    classMemberList.Add(classMember);
                }
                FieldInfo[] fieldInfos = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < fieldInfos.Length; i++)
                {
                    FieldInfo fieldInfo = fieldInfos[i] as FieldInfo;

                    if (fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0)
                        continue;

                    if (fieldInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                        continue;
                    string name = fieldInfo.Name;
                    ClassMember classMember = new ClassMember(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, fieldInfo.MemberType);
                    classMemberList.Add(classMember);
                }
                ClassMember[] classMembers = classMemberList.ToArray();
                customClassName = type.FullName;
				customClassName = AMFConfiguration.Instance.GetCustomClass(customClassName);
                classDefinition = new ClassDefinition(customClassName, classMembers, externalizable, dynamic);
				classDefinitions[type.FullName] = classDefinition;
			}
			return classDefinition;
		}

		#endregion AMF3

        internal object GetMember(object instance, ClassMember member)
        {
            if (instance is ASObject)
            {
                ASObject aso = instance as ASObject;
                if (aso.ContainsKey(member.Name))
                    return aso[member.Name];
            }
            Type type = instance.GetType();
            if (member.MemberType == MemberTypes.Property)
            {
                PropertyInfo propertyInfo = type.GetProperty(member.Name, member.BindingFlags);
                return propertyInfo.GetValue(instance, null);
            }
            if (member.MemberType == MemberTypes.Field)
            {
                FieldInfo fieldInfo = type.GetField(member.Name, member.BindingFlags);
                return fieldInfo.GetValue(instance);
            }
            string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("{0}.{1}", type.FullName, member.Name));
            throw new AMFException(msg);
        }
	}
}
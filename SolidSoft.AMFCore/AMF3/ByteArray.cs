using System;
using System.IO;
using System.ComponentModel;
using System.IO.Compression;
using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.AMF3
{
	/// <summary>
	/// Provides a type converter to convert ByteArray objects to and from various other representations.
	/// </summary>
	public class ByteArrayConverter : TypeConverter
	{
		/// <summary>
		/// Overloaded. Returns whether this converter can convert the object to the specified type.
		/// </summary>
		/// <param name="context">An ITypeDescriptorContext that provides a format context.</param>
		/// <param name="destinationType">A Type that represents the type you want to convert to.</param>
		/// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if( destinationType == typeof(byte[]) )
				return true;
			return base.CanConvertTo(context, destinationType);
		}
		/// <summary>
		/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="context">An ITypeDescriptorContext that provides a format context.</param>
		/// <param name="culture">A CultureInfo object. If a null reference (Nothing in Visual Basic) is passed, the current culture is assumed.</param>
		/// <param name="value">The Object to convert.</param>
		/// <param name="destinationType">The Type to convert the value parameter to.</param>
		/// <returns>An Object that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if( destinationType == typeof(byte[]) )
				return (value as ByteArray).MemoryStream.ToArray();
			return base.ConvertTo (context, culture, value, destinationType);
		}
	}

	/// <summary>
	/// Flex ByteArray. The ByteArray class provides methods and properties to optimize reading, writing, and working with binary data.
	/// </summary>
	[TypeConverter(typeof(ByteArrayConverter))]
    
    public class ByteArray : IDataInput, IDataOutput
	{
		private MemoryStream _memoryStream;
		private DataOutput _dataOutput;
		private DataInput _dataInput;
        private ObjectEncoding _objectEncoding;

        /// <summary>
        /// Initializes a new instance of the ByteArray class.
        /// </summary>
        public ByteArray()
        {
            _memoryStream = new MemoryStream();
            AMFReader amfReader = new AMFReader(_memoryStream);
            AMFWriter amfWriter = new AMFWriter(_memoryStream);
            _dataOutput = new DataOutput(amfWriter);
            _dataInput = new DataInput(amfReader);
            _objectEncoding = ObjectEncoding.AMF3;
        }

        /// <summary>
        /// Initializes a new instance of the ByteArray class.
        /// </summary>
        /// <param name="ms">The MemoryStream from which to create the current ByteArray.</param>
        public ByteArray(MemoryStream ms)
        {
            _memoryStream = ms;
            AMFReader amfReader = new AMFReader(_memoryStream);
            AMFWriter amfWriter = new AMFWriter(_memoryStream);
            _dataOutput = new DataOutput(amfWriter);
            _dataInput = new DataInput(amfReader);
            _objectEncoding = ObjectEncoding.AMF3;
        }

		/// <summary>
		/// Initializes a new instance of the ByteArray class.
		/// </summary>
        /// <param name="buffer">The array of unsigned bytes from which to create the current ByteArray.</param>
		internal ByteArray(byte[] buffer)
		{
			_memoryStream = new MemoryStream();
			_memoryStream.Write(buffer, 0, buffer.Length);
			_memoryStream.Position = 0;
			AMFReader amfReader = new AMFReader(_memoryStream);
			AMFWriter amfWriter = new AMFWriter(_memoryStream);
			_dataOutput = new DataOutput(amfWriter);
			_dataInput = new DataInput(amfReader);
            _objectEncoding = ObjectEncoding.AMF3;
		}
		/// <summary>
		/// Gets the length of the ByteArray object, in bytes.
		/// </summary>
		public uint Length
		{
			get
			{ 
				return (uint)_memoryStream.Length;
			}
		}
		/// <summary>
		/// Gets or sets the current position, in bytes, of the file pointer into the ByteArray object.
		/// </summary>
		public int Position
		{
			get{ return (int)_memoryStream.Position; }
			set{ _memoryStream.Position = value; }
		}
        /// <summary>
        /// Gets or sets the object encoding used in the ByteArray.
        /// </summary>
        public ObjectEncoding ObjectEncoding
        {
            get { return _objectEncoding; }
            set 
            { 
                _objectEncoding = value;
                _dataInput.ObjectEncoding = value;
                _dataOutput.ObjectEncoding = value;
            }
        }
        /// <summary>
        /// Returns the array of unsigned bytes from which this ByteArray was created.
        /// </summary>
        /// <returns>The byte array from which this ByteArray was created, or the underlying array if a byte array was not provided to the ByteArray constructor during construction of the current instance.</returns>
        public byte[] GetBuffer()
        {
            return _memoryStream.GetBuffer();
        }
        /// <summary>
        /// Gets the MemoryStream from which this ByteArray was created.
        /// </summary>
		internal MemoryStream MemoryStream{ get{ return _memoryStream; } }

		#region IDataInput Members

		/// <summary>
		/// Reads a Boolean from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public bool ReadBoolean()
		{
			return _dataInput.ReadBoolean();
		}
		/// <summary>
		/// Reads a signed byte from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public byte ReadByte()
		{
			return _dataInput.ReadByte();
		}
		/// <summary>
		/// Reads length bytes of data from the byte stream or byte array. 
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		public void ReadBytes(byte[] bytes, uint offset, uint length)
		{
			_dataInput.ReadBytes(bytes, offset, length);
		}
		/// <summary>
		/// Reads an IEEE 754 double-precision floating point number from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public double ReadDouble()
		{
			return _dataInput.ReadDouble();
		}
		/// <summary>
		/// Reads an IEEE 754 single-precision floating point number from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public float ReadFloat()
		{
			return _dataInput.ReadFloat();
		}
		/// <summary>
		/// Reads a signed 32-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public int ReadInt()
		{
			return _dataInput.ReadInt();
		}
		/// <summary>
		/// Reads an object from the byte stream or byte array, encoded in AMF serialized format. 
		/// </summary>
		/// <returns></returns>
		public object ReadObject()
		{
			return _dataInput.ReadObject();
		}
		/// <summary>
		/// Reads a signed 16-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public short ReadShort()
		{
			return _dataInput.ReadShort();
		}
		/// <summary>
		/// Reads an unsigned byte from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public byte ReadUnsignedByte()
		{
			return _dataInput.ReadUnsignedByte();
		}
		/// <summary>
		/// Reads an unsigned 32-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public uint ReadUnsignedInt()
		{
			return _dataInput.ReadUnsignedInt();
		}
		/// <summary>
		/// Reads an unsigned 16-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public ushort ReadUnsignedShort()
		{
			return _dataInput.ReadUnsignedShort();
		}
		/// <summary>
		/// Reads a UTF-8 string from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public string ReadUTF()
		{
			return _dataInput.ReadUTF();
		}
		/// <summary>
		/// Reads a sequence of length UTF-8 bytes from the byte stream or byte array, and returns a string. 
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public string ReadUTFBytes(uint length)
		{
			return _dataInput.ReadUTFBytes(length);
		}

		#endregion

		#region IDataOutput Members

        /// <summary>
        /// Writes a Boolean value.
        /// </summary>
        /// <param name="value"></param>
        public void WriteBoolean(bool value)
		{
			_dataOutput.WriteBoolean(value);
		}
        /// <summary>
        /// Writes a byte.
        /// </summary>
        /// <param name="value"></param>
		public void WriteByte(byte value)
		{
			_dataOutput.WriteByte(value);
		}
        /// <summary>
        /// Writes a sequence of length bytes from the specified byte array, bytes, starting offset(zero-based index) bytes into the byte stream.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
		public void WriteBytes(byte[] bytes, int offset, int length)
		{
			_dataOutput.WriteBytes(bytes, offset, length);
		}
        /// <summary>
        /// Writes an IEEE 754 double-precision (64-bit) floating point number.
        /// </summary>
        /// <param name="value"></param>
		public void WriteDouble(double value)
		{
			_dataOutput.WriteDouble(value);
		}
        /// <summary>
        /// Writes an IEEE 754 single-precision (32-bit) floating point number.
        /// </summary>
        /// <param name="value"></param>
		public void WriteFloat(float value)
		{
			_dataOutput.WriteFloat(value);
		}
        /// <summary>
        /// Writes a 32-bit signed integer.
        /// </summary>
        /// <param name="value"></param>
		public void WriteInt(int value)
		{
			_dataOutput.WriteInt(value);
		}
        /// <summary>
        /// Writes an object to the byte stream or byte array in AMF serialized format.
        /// </summary>
        /// <param name="value"></param>
		public void WriteObject(object value)
		{
			_dataOutput.WriteObject(value);
		}
        /// <summary>
        /// Writes a 16-bit integer.
        /// </summary>
        /// <param name="value"></param>
		public void WriteShort(short value)
		{
			_dataOutput.WriteShort(value);
		}
        /// <summary>
        /// Writes a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value"></param>
		public void WriteUnsignedInt(uint value)
		{
			_dataOutput.WriteUnsignedInt(value);
		}
        /// <summary>
        /// Writes a UTF-8 string to the byte stream. 
        /// The length of the UTF-8 string in bytes is written first, as a 16-bit integer, followed by 
        /// the bytes representing the characters of the string.
        /// </summary>
        /// <param name="value"></param>
		public void WriteUTF(string value)
		{
			_dataOutput.WriteUTF(value);
		}
        /// <summary>
        /// Writes a UTF-8 string. Similar to writeUTF, but does not prefix the string with a 16-bit length word.
        /// </summary>
        /// <param name="value"></param>
		public void WriteUTFBytes(string value)
		{
			_dataOutput.WriteUTFBytes(value);
		}

		#endregion

        /// <summary>
        /// Compresses the byte array using zlib compression. The entire byte array is compressed.
        /// </summary>
        public void Compress()
        {
            byte[] buffer = _memoryStream.GetBuffer();
            DeflateStream deflateStream = new DeflateStream(_memoryStream, CompressionMode.Compress, true);
            deflateStream.Write(buffer, 0, buffer.Length);
            deflateStream.Close();
            AMFReader amfReader = new AMFReader(_memoryStream);
            AMFWriter amfWriter = new AMFWriter(_memoryStream);
            _dataOutput = new DataOutput(amfWriter);
            _dataInput = new DataInput(amfReader);
        }
        /// <summary>
        /// Decompresses the byte array. The byte array must have been previously compressed with the Compress() method.
        /// </summary>
        public void Uncompress()
        {
            DeflateStream deflateStream = new DeflateStream(_memoryStream, CompressionMode.Decompress, false);
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            // Skip first two bytes
            _memoryStream.ReadByte();
            _memoryStream.ReadByte();
            while (true)
            {
                int readCount = deflateStream.Read(buffer, 0, buffer.Length);
                if (readCount > 0)
                    ms.Write(buffer, 0, readCount);
                else
                    break;
            }
            deflateStream.Close();
            _memoryStream.Close();
            _memoryStream.Dispose();
            _memoryStream = ms;
            _memoryStream.Position = 0;
            AMFReader amfReader = new AMFReader(_memoryStream);
            AMFWriter amfWriter = new AMFWriter(_memoryStream);
            _dataOutput = new DataOutput(amfWriter);
            _dataInput = new DataInput(amfReader);
        }
	}
}
using SolidSoft.AMFCore.IO;

namespace SolidSoft.AMFCore.AMF3
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DataInput : IDataInput
	{
		private AMFReader _amfReader;
        private ObjectEncoding _objectEncoding;

		public DataInput(AMFReader amfReader)
		{
			_amfReader = amfReader;
            _objectEncoding = ObjectEncoding.AMF3;
		}

        public ObjectEncoding ObjectEncoding
        {
            get { return _objectEncoding; }
            set { _objectEncoding = value; }
        }

		#region IDataInput Members

		/// <summary>
		/// Reads a Boolean from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public bool ReadBoolean()
		{
			return _amfReader.ReadBoolean();
		}
		/// <summary>
		/// Reads a signed byte from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public byte ReadByte()
		{
			return _amfReader.ReadByte();
		}
		/// <summary>
		/// Reads length bytes of data from the byte stream or byte array. 
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		public void ReadBytes(byte[] bytes, uint offset, uint length)
		{
			byte[] tmp = _amfReader.ReadBytes((int)length);
			for(int i = 0; i < tmp.Length; i++)
				bytes[i+offset] = tmp[i];
		}
		/// <summary>
		/// Reads an IEEE 754 double-precision floating point number from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public double ReadDouble()
		{
			return _amfReader.ReadDouble();
		}
		/// <summary>
		/// Reads an IEEE 754 single-precision floating point number from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public float ReadFloat()
		{
			return _amfReader.ReadFloat();
		}
		/// <summary>
		/// Reads a signed 32-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public int ReadInt()
		{
			return _amfReader.ReadInt32();
		}
		/// <summary>
		/// Reads an object from the byte stream or byte array, encoded in AMF serialized format. 
		/// </summary>
		/// <returns></returns>
		public object ReadObject()
		{
            object obj = null;
            if( _objectEncoding == ObjectEncoding.AMF0 )
                obj = _amfReader.ReadData();
            if (_objectEncoding == ObjectEncoding.AMF3)
                obj = _amfReader.ReadAMF3Data();
            return obj;
		}
		/// <summary>
		/// Reads a signed 16-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public short ReadShort()
		{
			return _amfReader.ReadInt16();
		}
		/// <summary>
		/// Reads an unsigned byte from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public byte ReadUnsignedByte()
		{
			return _amfReader.ReadByte();
		}
		/// <summary>
		/// Reads an unsigned 32-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public uint ReadUnsignedInt()
		{
			return (uint)_amfReader.ReadInt32();
		}
		/// <summary>
		/// Reads an unsigned 16-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public ushort ReadUnsignedShort()
		{
			return _amfReader.ReadUInt16();
		}
		/// <summary>
		/// Reads a UTF-8 string from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		public string ReadUTF()
		{
			return _amfReader.ReadString();
		}
		/// <summary>
		/// Reads a sequence of length UTF-8 bytes from the byte stream or byte array, and returns a string. 
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public string ReadUTFBytes(uint length)
		{
			return _amfReader.ReadUTF((int)length);
		}

		#endregion
	}
}
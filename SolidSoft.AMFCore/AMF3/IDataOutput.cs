using System;

namespace SolidSoft.AMFCore.AMF3
{
	/// <summary>
	/// The IDataOutput interface provides a set of methods for writing binary data. 
	/// </summary>
    
    public interface IDataOutput
	{
		/// <summary>
		/// Writes a Boolean value.
		/// </summary>
		/// <param name="value"></param>
		void WriteBoolean(bool value);
		/// <summary>
		/// Writes a byte.
		/// </summary>
		/// <param name="value"></param>
		void WriteByte(byte value);
		/// <summary>
		/// Writes a sequence of length bytes from the specified byte array, bytes, starting offset(zero-based index) bytes into the byte stream.
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		void WriteBytes(byte[] bytes, int offset, int length);
		/// <summary>
		/// Writes an IEEE 754 double-precision (64-bit) floating point number.
		/// </summary>
		/// <param name="value"></param>
		void WriteDouble(double value);
		/// <summary>
		/// Writes an IEEE 754 single-precision (32-bit) floating point number.
		/// </summary>
		/// <param name="value"></param>
		void WriteFloat(float value);
		/// <summary>
		/// Writes a 32-bit signed integer.
		/// </summary>
		/// <param name="value"></param>
		void WriteInt(int value);
		/// <summary>
		/// Writes an object to the byte stream or byte array in AMF serialized format.
		/// </summary>
		/// <param name="value"></param>
		void WriteObject(object value);
		/// <summary>
		/// Writes a 16-bit integer.
		/// </summary>
		/// <param name="value"></param>
		void WriteShort(short value);
		/// <summary>
		/// Writes a 32-bit unsigned integer.
		/// </summary>
		/// <param name="value"></param>
		void WriteUnsignedInt(uint value);
		/// <summary>
		/// Writes a UTF-8 string to the byte stream.
		/// </summary>
		/// <param name="value"></param>
		void WriteUTF(string value);
		/// <summary>
		/// Writes a UTF-8 string.
		/// </summary>
		/// <param name="value"></param>
		void WriteUTFBytes(string value);
	}
}
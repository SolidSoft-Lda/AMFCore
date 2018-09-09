using System;

namespace SolidSoft.AMFCore.AMF3
{
	/// <summary>
	/// The IDataInput interface provides a set of methods for reading binary data.
	/// </summary>
    
    public interface IDataInput
	{
		/// <summary>
		/// Reads a Boolean from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		bool ReadBoolean();
		/// <summary>
		/// Reads a signed byte from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		byte ReadByte();
		/// <summary>
		/// Reads length bytes of data from the byte stream or byte array. 
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		void ReadBytes(byte[] bytes, uint offset, uint length);
		/// <summary>
		/// Reads an IEEE 754 double-precision floating point number from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		double ReadDouble();
		/// <summary>
		/// Reads an IEEE 754 single-precision floating point number from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		float ReadFloat();
		/// <summary>
		/// Reads a signed 32-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		int ReadInt();
		/// <summary>
		/// Reads an object from the byte stream or byte array, encoded in AMF serialized format. 
		/// </summary>
		/// <returns></returns>
		object ReadObject();
		/// <summary>
		/// Reads a signed 16-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		short ReadShort();
		/// <summary>
		/// Reads an unsigned byte from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		byte ReadUnsignedByte();
		/// <summary>
		/// Reads an unsigned 32-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		uint ReadUnsignedInt();
		/// <summary>
		/// Reads an unsigned 16-bit integer from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		ushort ReadUnsignedShort();
		/// <summary>
		/// Reads a UTF-8 string from the byte stream or byte array. 
		/// </summary>
		/// <returns></returns>
		string ReadUTF();
		/// <summary>
		/// Reads a sequence of length UTF-8 bytes from the byte stream or byte array, and returns a string. 
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		string ReadUTFBytes(uint length);
	}
}
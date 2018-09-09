using System;

namespace SolidSoft.AMFCore.AMF3
{
	/// <summary>
	/// The IExternalizable interface provides control over serialization of a class as it is encoded into a data stream.
	/// </summary>
    
    public interface IExternalizable
	{
		/// <summary>
		/// A class implements this method to decode itself from a data stream by calling the methods of the IDataInput interface. 
		/// </summary>
		/// <param name="input">Input data stream.</param>
		void ReadExternal(IDataInput input);
		/// <summary>
		/// A class implements this method to encode itself for a data stream by calling the methods of the IDataOutput interface.
		/// </summary>
		/// <param name="output">Output data stream.</param>
		void WriteExternal(IDataOutput output);
	}
}
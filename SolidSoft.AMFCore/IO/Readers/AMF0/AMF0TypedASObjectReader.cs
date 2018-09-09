using System;
using SolidSoft.AMFCore.AMF3;
using SolidSoft.AMFCore.IO.Bytecode;

namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	/// <remarks>
	/// This reader is used only in case that a requested type is not found and the gateway choose to represent 
	/// typed objects with ActionScript typed objects.
	/// </remarks>
	class AMF0TypedASObjectReader : IReflectionOptimizer
	{
		string _typeIdentifier;

		public AMF0TypedASObjectReader(string typeIdentifier)
		{
			_typeIdentifier = typeIdentifier;
		}

        #region IReflectionOptimizer Members

        public object CreateInstance()
        {
            throw new NotImplementedException();
        }

        public object ReadData(AMFReader reader, ClassDefinition classDefinition)
        {
            ASObject asObject = reader.ReadASObject();
            asObject.TypeName = _typeIdentifier;
            return asObject;
        }

        #endregion
    }
}
using System;
using SolidSoft.AMFCore.AMF3;
using SolidSoft.AMFCore.IO.Bytecode;
using SolidSoft.AMFCore.Exceptions;

namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    class AMF3ExternalizableReader : IReflectionOptimizer
	{

        public AMF3ExternalizableReader()
		{
		}

        #region IReflectionOptimizer Members

        public object CreateInstance()
        {
            throw new NotImplementedException();
        }

        public object ReadData(AMFReader reader, ClassDefinition classDefinition)
        {
            object instance = ObjectFactory.CreateInstance(classDefinition.ClassName);
            if (instance == null)
            {
                string msg = __Res.GetString(__Res.Type_InitError, classDefinition.ClassName);
                throw new AMFException(msg);
            }
            reader.AddAMF3ObjectReference(instance);
            if (instance is IExternalizable)
            {
                IExternalizable externalizable = instance as IExternalizable;
                DataInput dataInput = new DataInput(reader);
                externalizable.ReadExternal(dataInput);
                return instance;
            }
            else
            {
                string msg = __Res.GetString(__Res.Externalizable_CastFail, instance.GetType().FullName);
                throw new AMFException(msg);
            }
        }

        #endregion
    }
}
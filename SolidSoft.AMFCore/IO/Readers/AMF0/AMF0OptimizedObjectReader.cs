using System;
using System.Collections;
using SolidSoft.AMFCore.AMF3;
using SolidSoft.AMFCore.IO.Bytecode;

namespace SolidSoft.AMFCore.IO.Readers
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0OptimizedObjectReader : IAMFReader
	{
		Hashtable _optimizedReaders;

		public AMF0OptimizedObjectReader()
		{
			_optimizedReaders = new Hashtable();
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader)
		{
			object instance = null;
			string typeIdentifier = reader.ReadString();
            IReflectionOptimizer reflectionOptimizer = _optimizedReaders[typeIdentifier] as IReflectionOptimizer;
			if( reflectionOptimizer == null )
			{
				lock(_optimizedReaders)
				{
                    if (!_optimizedReaders.Contains(typeIdentifier))
                    {
                        //Temporary reader
                        _optimizedReaders[typeIdentifier] = new AMF0TempObjectReader();
                        Type type = ObjectFactory.Locate(typeIdentifier);
						if( type != null )
						{
							instance = ObjectFactory.CreateInstance(type);
							reader.AddReference(instance);
							if (type != null)
							{
								//Fixup
								if (reflectionOptimizer != null)
									_optimizedReaders[typeIdentifier] = reflectionOptimizer;
								else
                                    _optimizedReaders[typeIdentifier] = new AMF0TempObjectReader();
							}
						}
						else
						{
                            reflectionOptimizer = new AMF0TypedASObjectReader(typeIdentifier);
                            _optimizedReaders[typeIdentifier] = reflectionOptimizer;
                            instance = reflectionOptimizer.ReadData(reader, null);
						}
                    }
                    else
                    {
                        reflectionOptimizer = _optimizedReaders[typeIdentifier] as IReflectionOptimizer;
                        instance = reflectionOptimizer.ReadData(reader, null);
                    }
				}
			}
			else
			{
				instance = reflectionOptimizer.ReadData(reader, null);
			}
			return instance;
		}

		#endregion
	}

    class AMF0TempObjectReader : IReflectionOptimizer
    {
        #region IReflectionOptimizer Members

        public object CreateInstance()
        {
            throw new NotImplementedException();
        }

        public object ReadData(AMFReader reader, ClassDefinition classDefinition)
        {
            object amfObject = reader.ReadObject();
            return amfObject;
        }

        #endregion
    }
}
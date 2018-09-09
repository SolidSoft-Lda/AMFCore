using System;
using System.Reflection;
using SolidSoft.AMFCore.Configuration;
using System.Collections.Generic;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ObjectFactory
	{
        private static Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();
        private static string[] _lacLocations;

		static ObjectFactory()
		{
			_lacLocations = TypeHelper.GetLacLocations();
		}

		static public Type Locate(string typeName)
		{
			if( typeName == null || typeName == string.Empty )
				return null;

			string mappedTypeName = typeName;
			mappedTypeName = AMFConfiguration.Instance.GetMappedTypeName(typeName);

			//Lookup first in our cache.
			lock(typeof(Type))
			{
                Type type = null;
                if( _typeCache.ContainsKey(mappedTypeName) )
                    type = _typeCache[mappedTypeName] as Type;
				if( type == null )
				{

					type = SolidSoft.AMFCore.TypeHelper.Locate(mappedTypeName);
					if(type != null)
					{
						_typeCache[mappedTypeName] = type;
						return type;
					}
					else
					{
						//Locate in LAC
						type = LocateInLac(mappedTypeName);
					}
				}
				return type;
			}
		}

		static public Type LocateInLac(string typeName)
		{
			//Locate in LAC
			if( typeName == null || typeName == string.Empty )
				return null;

			string mappedTypeName = typeName;
			mappedTypeName = AMFConfiguration.Instance.GetMappedTypeName(typeName);

			//Lookup first in our cache.
			lock(typeof(Type))
			{
                Type type = null;
                if (_typeCache.ContainsKey(mappedTypeName))
                    type = _typeCache[mappedTypeName] as Type;
				if( type == null )
				{

					//Locate in LAC
					for(int i = 0; i < _lacLocations.Length; i++)
					{
						type = SolidSoft.AMFCore.TypeHelper.LocateInLac(mappedTypeName, _lacLocations[i]);
						if(type != null)
						{
							_typeCache[mappedTypeName] = type;
							return type;
						}
					}
				}
				return type;
			}
		}

		static internal void AddTypeToCache(Type type)
		{
			if( type != null )
			{
				lock(typeof(Type))
				{
					_typeCache[type.FullName] = type;
				}
			}
		}

		static public bool ContainsType(string typeName)
		{
			if( typeName != null )
			{
				lock(typeof(Type))
				{
					return _typeCache.ContainsKey(typeName);
				}
			}
			return false;
		}

		static public object CreateInstance(Type type)
		{
			return CreateInstance(type, null);
		}

		static public object CreateInstance(Type type, object[] args)
		{
			if( type != null )
			{
				lock(typeof(Type))
				{
					if (type.IsAbstract && type.IsSealed)
					{
						return type;
					}
					else
					{
						if( args == null )
							return Activator.CreateInstance(type, BindingFlags.CreateInstance|BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static, null, new object[]{}, null);
                        return Activator.CreateInstance(type, BindingFlags.CreateInstance|BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static, null, args, null);
					}
				}
			}
			return null;
		}

		static public object CreateInstance(string typeName)
		{
			return CreateInstance(typeName, null);
		}

		static public object CreateInstance(string typeName, object[] args)
		{
			Type type = Locate(typeName);
			return CreateInstance(type, args);
		}
	}
}
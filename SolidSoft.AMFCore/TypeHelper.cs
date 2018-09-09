using System;
using System.Xml;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Security;
using System.Text;
using System.Xml.Linq;
using SolidSoft.AMFCore.Configuration;
using SolidSoft.AMFCore.Util;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class TypeHelper
	{
        static object _syncLock = new object();

        static TypeHelper()
		{
            _defaultSByteNullValue = (SByte)GetNullValue(typeof(SByte));
            _defaultInt16NullValue = (Int16)GetNullValue(typeof(Int16));
            _defaultInt32NullValue = (Int32)GetNullValue(typeof(Int32));
            _defaultInt64NullValue = (Int64)GetNullValue(typeof(Int64));
            _defaultByteNullValue = (Byte)GetNullValue(typeof(Byte));
            _defaultUInt16NullValue = (UInt16)GetNullValue(typeof(UInt16));
            _defaultUInt32NullValue = (UInt32)GetNullValue(typeof(UInt32));
            _defaultUInt64NullValue = (UInt64)GetNullValue(typeof(UInt64));
            _defaultCharNullValue = (Char)GetNullValue(typeof(Char));
            _defaultSingleNullValue = (Single)GetNullValue(typeof(Single));
            _defaultDoubleNullValue = (Double)GetNullValue(typeof(Double));
            _defaultBooleanNullValue = (Boolean)GetNullValue(typeof(Boolean));

            _defaultStringNullValue = (String)GetNullValue(typeof(String));
            _defaultDateTimeNullValue = (DateTime)GetNullValue(typeof(DateTime));
            _defaultDecimalNullValue = (Decimal)GetNullValue(typeof(Decimal));
            _defaultGuidNullValue = (Guid)GetNullValue(typeof(Guid));
            _defaultXmlReaderNullValue = (XmlReader)GetNullValue(typeof(XmlReader));
            _defaultXmlDocumentNullValue = (XmlDocument)GetNullValue(typeof(XmlDocument));
            _defaultXDocumentNullValue = (XDocument)GetNullValue(typeof(XDocument));
            _defaultXElementNullValue = (XElement)GetNullValue(typeof(XElement));

            _Init();
        }

        internal static void _Init()
        {
        }

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
        static public Assembly[] GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        static public Type Locate(string typeName)
		{
			if( typeName == null || typeName == string.Empty )
				return null;
            Assembly[] assemblies = GetAssemblies();// AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Assembly assembly = assemblies[i];
				Type type = assembly.GetType(typeName, false);
				if (type != null)
					return type;
			}
			return null;
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="lac"></param>
        /// <returns></returns>
		static public Type LocateInLac(string typeName, string lac)
		{
			if( lac == null  )
				return null;
			if( typeName == null || typeName == string.Empty )
				return null;
            foreach (string file in Directory.GetFiles(lac, "*.dll"))
			{
				try
				{
					Assembly assembly = Assembly.LoadFrom(file);
					Type type = assembly.GetType(typeName, false);
					if (type != null)
						return type;
				}
				catch (Exception)
				{
				}
			}
            foreach (string file in Directory.GetFiles(lac, "*.exe"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(file);
                    Type type = assembly.GetType(typeName, false);
                    if (type != null)
                        return type;
                }
                catch (Exception)
                {
                }
            }
            foreach (string dir in Directory.GetDirectories(lac))
            {
                Type type = LocateInLac(typeName, dir);
                if (type != null)
                    return type;
            }
            return null;
		}

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="lac"></param>
        /// <param name="excludedBaseTypes"></param>
        /// <returns></returns>
		static public Type[] SearchAllTypes(string lac, Hashtable excludedBaseTypes)
		{
			ArrayList result = new ArrayList();
			foreach (string file in Directory.GetFiles(lac, "*.dll"))
			{
				try
				{
					Assembly assembly = Assembly.LoadFrom(file);
					if (assembly == Assembly.GetExecutingAssembly())
						continue;
					foreach (Type type in assembly.GetTypes())
					{
						if (excludedBaseTypes != null)
						{
							if (excludedBaseTypes.ContainsKey(type))
								continue;
							if (type.BaseType != null && excludedBaseTypes.ContainsKey(type.BaseType))
								continue;
						}
						result.Add(type);
					}
				}
				catch (Exception)
				{
				}			
			}
			return (Type[])result.ToArray(typeof(Type));
		}

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
		public static bool SkipMethod(MethodInfo methodInfo)
		{
			if (methodInfo.ReturnType == typeof(System.IAsyncResult))
				return true;
			foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
			{
				if (parameterInfo.ParameterType == typeof(System.IAsyncResult))
					return true;
			}
			return false;
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
		public static string GetDescription(Type type)
		{
            Attribute attribute = ReflectionUtils.GetAttribute(typeof(DescriptionAttribute), type, false);
			if (attribute != null)
				return (attribute as DescriptionAttribute).Description;
			return null;
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
		public static string GetDescription(MethodInfo methodInfo)
		{
            Attribute attribute = ReflectionUtils.GetAttribute(typeof(DescriptionAttribute), methodInfo, false);
            if (attribute != null)
                return (attribute as DescriptionAttribute).Description;
            return null;
		}

		internal static void NarrowValues(object[] values, ParameterInfo[] parameterInfos)
		{
			//Narrow down convertibe types (double for example)
			for (int i = 0; values != null && i < values.Length; i++)
			{
				object value = values[i];
				values[i] = TypeHelper.ChangeType(value, parameterInfos[i].ParameterType);
			}
		}

		internal static object GetNullValue(Type type)
		{
            if (type == null) throw new ArgumentNullException("type");

			if( AMFConfiguration.Instance.NullableValues != null )
			{
                if (AMFConfiguration.Instance.NullableValues.ContainsKey(type))
                    return AMFConfiguration.Instance.NullableValues[type];
			}
            if (type.IsValueType)
            {
                /* Not supported
                if (type.IsEnum)
                    return GetEnumNullValue(type);
                */
                if (type.IsPrimitive)
                {
                    if (type == typeof(Int32)) return 0;
                    if (type == typeof(Double)) return (Double)0;
                    if (type == typeof(Int16)) return (Int16)0;
                    if (type == typeof(Boolean)) return false;
                    if (type == typeof(SByte)) return (SByte)0;
                    if (type == typeof(Int64)) return (Int64)0;
                    if (type == typeof(Byte)) return (Byte)0;
                    if (type == typeof(UInt16)) return (UInt16)0;
                    if (type == typeof(UInt32)) return (UInt32)0;
                    if (type == typeof(UInt64)) return (UInt64)0;
                    if (type == typeof(Single)) return (Single)0;
                    if (type == typeof(Char)) return new char();
                }
                else
                {
                    if (type == typeof(DateTime)) return DateTime.MinValue;
                    if (type == typeof(Decimal)) return 0m;
                    if (type == typeof(Guid)) return Guid.Empty;
                }
            }
            else
            {
                if (type == typeof(String)) return null;// string.Empty;
                if (type == typeof(DBNull)) return DBNull.Value;
            }
            return null;
        }

		internal static object CreateInstance(Type type)
		{
			//Is this a generic type definition?
			if (ReflectionUtils.IsGenericType(type))
			{
				Type genericTypeDefinition = ReflectionUtils.GetGenericTypeDefinition(type);
				// Get the generic type parameters or type arguments.
				Type[] typeParameters = ReflectionUtils.GetGenericArguments(type);

				// Construct an array of type arguments to substitute for 
				// the type parameters of the generic class.
				// The array must contain the correct number of types, in 
				// the same order that they appear in the type parameter 
				// list.
				// Construct the type Dictionary<String, Example>.
				Type constructed = ReflectionUtils.MakeGenericType(genericTypeDefinition, typeParameters);
				return Activator.CreateInstance(constructed);
			}
			else
				return Activator.CreateInstance(type);
		}

        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
		public static string[] GetLacLocations()
		{
			ArrayList lacLocations = new ArrayList();

			try
			{
                //This is the AMFCore path
                try
                {
                    string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    if (location != null)
                        lacLocations.Add(location);
                }
                catch (SecurityException)
                {
                }

				try
				{
					if (AppDomain.CurrentDomain.DynamicDirectory != null)
					{
						//Uri uri = new Uri(AppDomain.CurrentDomain.DynamicDirectory);
						string dynamicDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.DynamicDirectory);
						lacLocations.Add(dynamicDirectory);
					}
				}
				catch (SecurityException)
				{
				}
			}
			catch(Exception)
			{
			}
			return lacLocations.ToArray(typeof(string)) as string[];
		}
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool GetTypeIsAccessible(Type type)
        {
            if (type == null || type.Assembly == typeof(TypeHelper).Assembly)
                return false;
            return true;
        }

        /// <summary>
        /// Returns the underlying type argument of the specified type.
        /// </summary>
        /// <param name="type">A <see cref="System.Type"/> instance. </param>
        /// <returns><list>
        /// <item>The type argument of the type parameter,
        /// if the type parameter is a closed generic nullable type.</item>
        /// <item>The underlying Type of enumType, if the type parameter is an enum type.</item>
        /// <item>Otherwise, the type itself.</item>
        /// </list>
        /// </returns>
        public static Type GetUnderlyingType(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            if (ReflectionUtils.IsNullable(type))
				type = type.GetGenericArguments()[0];

            if (type.IsEnum)
                type = Enum.GetUnderlyingType(type);

            return type;
        }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetCSharpName(Type type)
        {
            int dimensions = 0;
            while (type.IsArray)
            {
                type = type.GetElementType();
                dimensions++;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(type.Namespace);
            sb.Append(".");

            Type[] parameters = Type.EmptyTypes;
            if (ReflectionUtils.IsGenericType(type))
            {
                if (ReflectionUtils.GetGenericArguments(type) != null)
                    parameters = ReflectionUtils.GetGenericArguments(type);
            }
            GetCSharpName(type, parameters, 0, sb);
            for (int i = 0; i < dimensions; i++)
            {
                sb.Append("[]");
            }
            return sb.ToString();
         }

        private static int GetCSharpName(Type type, Type[] parameters, int index, StringBuilder sb)
        {
            if (type.DeclaringType != null && type.DeclaringType != type)
            {
                index = GetCSharpName(type.DeclaringType, parameters, index, sb);
                sb.Append(".");
            }
            string name = type.Name;
            int length = name.IndexOf('`');
            if (length < 0)
                length = name.IndexOf('!');
            if (length > 0)
            {
                sb.Append(name.Substring(0, length));
                sb.Append("<");
                int paramCount = int.Parse(name.Substring(length + 1), System.Globalization.CultureInfo.InvariantCulture) + index;
                while (index < paramCount)
                {
                    sb.Append(GetCSharpName(parameters[index]));
                    if (index < (paramCount - 1))
                    {
                        sb.Append(",");
                    }
                    index++;
                }
                sb.Append(">");
                return index;
            }
            sb.Append(name);
            return index;
        }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool IsAssignable(object obj, Type targetType)
        {
            return IsAssignable(obj, targetType, ReflectionUtils.IsNullable(targetType));
        }

        private static bool IsAssignable(object obj, Type targetType, bool isNullable)
        {
            if (obj != null && targetType.IsAssignableFrom(obj.GetType()))
                return true;//targetType can be assigned from an instance of the obj's Type
            if (isNullable && obj == null )
                return true;//null is assignable to a nullable type
            if (targetType.IsArray)
            {
                if (null == obj)
                    return true;
                Type srcType = obj.GetType();

                if (srcType == targetType)
                    return true;

                if (srcType.IsArray)
                {
                    Type srcElementType = srcType.GetElementType();
                    Type dstElementType = targetType.GetElementType();

                    if (srcElementType.IsArray != dstElementType.IsArray
                        || (srcElementType.IsArray &&
                            srcElementType.GetArrayRank() != dstElementType.GetArrayRank()))
                    {
                        return false;
                    }

                    Array srcArray = (Array)obj;
                    int rank = srcArray.Rank;
                    if (rank == 1 && 0 == srcArray.GetLowerBound(0))
                    {
                        int arrayLength = srcArray.Length;
                        // Int32 is assignable from UInt32, SByte from Byte and so on.
                        if (dstElementType.IsAssignableFrom(srcElementType))
                            return true;
                        else
                        {
                            //This is a costly operation
                            for (int i = 0; i < arrayLength; ++i)
                                if (!IsAssignable(srcArray.GetValue(i), dstElementType))
                                    return false;
                        }
                    }
                    else
                    {
                        //This is a costly operation
                        int arrayLength = 1;
                        int[] dimensions = new int[rank];
                        int[] indices = new int[rank];
                        int[] lbounds = new int[rank];

                        for (int i = 0; i < rank; ++i)
                        {
                            arrayLength *= (dimensions[i] = srcArray.GetLength(i));
                            lbounds[i] = srcArray.GetLowerBound(i);
                        }

                        for (int i = 0; i < arrayLength; ++i)
                        {
                            int index = i;
                            for (int j = rank - 1; j >= 0; --j)
                            {
                                indices[j] = index % dimensions[j] + lbounds[j];
                                index /= dimensions[j];
                            }
                            if (!IsAssignable(srcArray.GetValue(indices), dstElementType))
                                return false;
                        }
                    }
                    return true;
                }
            }
            else if (targetType.IsEnum)
            {
                try
                {
                    Enum.Parse(targetType, obj.ToString(), true);
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }

            if (obj != null)
            {
                TypeConverter typeConverter = ReflectionUtils.GetTypeConverter(obj);//TypeDescriptor.GetConverter(obj);
                if (typeConverter != null && typeConverter.CanConvertTo(targetType))
                    return true;
                typeConverter = ReflectionUtils.GetTypeConverter(targetType);// TypeDescriptor.GetConverter(targetType);
                if (typeConverter != null && typeConverter.CanConvertFrom(obj.GetType()))
                    return true;

                //Collections
                if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.Generic.ICollection`1") && obj is IList)
                {
                    //For generic interfaces, the name parameter is the mangled name, ending with a grave accent (`) and the number of type parameters
                    Type[] typeParameters = ReflectionUtils.GetGenericArguments(targetType);
                    if (typeParameters != null && typeParameters.Length == 1)
                    {
                        //For generic interfaces, the name parameter is the mangled name, ending with a grave accent (`) and the number of type parameters
                        Type typeGenericICollection = targetType.GetInterface("System.Collections.Generic.ICollection`1", true);
                        return typeGenericICollection != null;
                    }
                    else
                        return false;
                }

                if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.IList") && obj is IList)
                {
                    return true;
                }

                if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.Generic.IDictionary`2") && obj is IDictionary)
                {
                    Type[] typeParameters = ReflectionUtils.GetGenericArguments(targetType);
                    if (typeParameters != null && typeParameters.Length == 2)
                    {
                        //For generic interfaces, the name parameter is the mangled name, ending with a grave accent (`) and the number of type parameters
                        Type typeGenericIDictionary = targetType.GetInterface("System.Collections.Generic.IDictionary`2", true);
                        return typeGenericIDictionary != null;
                    }
                    else
                        return false;
                }

                if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.IDictionary") && obj is IDictionary)
                {
                    return true;
                }
                //return false;
            }
            else
            {
                if (targetType.IsValueType)
                {
                    if (AMFConfiguration.Instance.AcceptNullValueTypes)
                    {
                        // Any value-type that is not explicitly initialized with a value will 
                        // contain the default value for that object type.
                        return true;
                    }
                    return false;
                }
                else
                    return true;
            }

            try
            {
                if (isNullable)
                {
                    switch (Type.GetTypeCode(TypeHelper.GetUnderlyingType(targetType)))
                    {
                        case TypeCode.Char: return CanConvertToNullableChar(obj);
                    }
                }

                switch (Type.GetTypeCode(targetType))
                {
                    case TypeCode.Char: return CanConvertToChar(obj);
                }
            }
            catch (InvalidCastException)
            {
            }

            if (typeof(System.Xml.Linq.XDocument) == targetType && obj is XmlDocument) return true;
            if (typeof(System.Xml.Linq.XElement) == targetType && obj is XmlDocument) return true;

            return false;
        }
        /// <summary>
        /// This method supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        static public object ChangeType(object value, Type targetType)
        {
            return ConvertChangeType(value, targetType, ReflectionUtils.IsNullable(targetType));
        }

        private static object ConvertChangeType(object value, Type targetType, bool isNullable)
        {
            if (targetType.IsArray)
            {
                if (null == value)
                    return null;

                Type srcType = value.GetType();

                if (srcType == targetType)
                    return value;

                if (srcType.IsArray)
                {
                    Type srcElementType = srcType.GetElementType();
                    Type dstElementType = targetType.GetElementType();

                    if (srcElementType.IsArray != dstElementType.IsArray
                        || (srcElementType.IsArray &&
                            srcElementType.GetArrayRank() != dstElementType.GetArrayRank()))
                    {
                        throw new InvalidCastException(string.Format("Can not convert array of type '{0}' to array of '{1}'.", srcType.FullName, targetType.FullName));
                    }

                    Array srcArray = (Array)value;
                    Array dstArray;

                    int rank = srcArray.Rank;

                    if (rank == 1 && 0 == srcArray.GetLowerBound(0))
                    {
                        int arrayLength = srcArray.Length;

                        dstArray = Array.CreateInstance(dstElementType, arrayLength);

                        // Int32 is assignable from UInt32, SByte from Byte and so on.
                        //
                        if (dstElementType.IsAssignableFrom(srcElementType))
                            Array.Copy(srcArray, dstArray, arrayLength);
                        else
                            for (int i = 0; i < arrayLength; ++i)
                                dstArray.SetValue(ConvertChangeType(srcArray.GetValue(i), dstElementType, isNullable), i);
                    }
                    else
                    {
                        int arrayLength = 1;
                        int[] dimensions = new int[rank];
                        int[] indices = new int[rank];
                        int[] lbounds = new int[rank];

                        for (int i = 0; i < rank; ++i)
                        {
                            arrayLength *= (dimensions[i] = srcArray.GetLength(i));
                            lbounds[i] = srcArray.GetLowerBound(i);
                        }

                        dstArray = Array.CreateInstance(dstElementType, dimensions, lbounds);
                        for (int i = 0; i < arrayLength; ++i)
                        {
                            int index = i;
                            for (int j = rank - 1; j >= 0; --j)
                            {
                                indices[j] = index % dimensions[j] + lbounds[j];
                                index /= dimensions[j];
                            }

                            dstArray.SetValue(ConvertChangeType(srcArray.GetValue(indices), dstElementType, isNullable), indices);
                        }
                    }

                    return dstArray;
                }
            }
            else if (targetType.IsEnum)
            {
                try
                {
                    return Enum.Parse(targetType, value.ToString(), true);
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidCastException(__Res.GetString(__Res.TypeHelper_ConversionFail), ex);
                }
            }

            if (isNullable)
            {
                switch (Type.GetTypeCode(TypeHelper.GetUnderlyingType(targetType)))
                {
                    case TypeCode.Boolean:  return ConvertToNullableBoolean (value);
                    case TypeCode.Byte:     return ConvertToNullableByte    (value);
                    case TypeCode.Char:     return ConvertToNullableChar    (value);
                    case TypeCode.DateTime: return ConvertToNullableDateTime(value);
                    case TypeCode.Decimal:  return ConvertToNullableDecimal (value);
                    case TypeCode.Double:   return ConvertToNullableDouble  (value);
                    case TypeCode.Int16:    return ConvertToNullableInt16   (value);
                    case TypeCode.Int32:    return ConvertToNullableInt32   (value);
                    case TypeCode.Int64:    return ConvertToNullableInt64   (value);
                    case TypeCode.SByte:    return ConvertToNullableSByte   (value);
                    case TypeCode.Single:   return ConvertToNullableSingle  (value);
                    case TypeCode.UInt16:   return ConvertToNullableUInt16  (value);
                    case TypeCode.UInt32:   return ConvertToNullableUInt32  (value);
                    case TypeCode.UInt64:   return ConvertToNullableUInt64  (value);
                }
                if (typeof(Guid) == targetType) return ConvertToNullableGuid(value);
            }

            switch (Type.GetTypeCode(targetType))
            {
                case TypeCode.Boolean: return ConvertToBoolean(value);
                case TypeCode.Byte: return ConvertToByte(value);
                case TypeCode.Char: return ConvertToChar(value);
                case TypeCode.DateTime: return ConvertToDateTime(value);
                case TypeCode.Decimal: return ConvertToDecimal(value);
                case TypeCode.Double: return ConvertToDouble(value);
                case TypeCode.Int16: return ConvertToInt16(value);
                case TypeCode.Int32: return ConvertToInt32(value);
                case TypeCode.Int64: return ConvertToInt64(value);
                case TypeCode.SByte: return ConvertToSByte(value);
                case TypeCode.Single: return ConvertToSingle(value);
                case TypeCode.String: return ConvertToString(value);
                case TypeCode.UInt16: return ConvertToUInt16(value);
                case TypeCode.UInt32: return ConvertToUInt32(value);
                case TypeCode.UInt64: return ConvertToUInt64(value);
            }

            if (typeof(Guid) == targetType) return ConvertToGuid(value);
            if (typeof(System.Xml.XmlDocument) == targetType) return ConvertToXmlDocument(value);
            if (typeof(System.Xml.Linq.XDocument) == targetType) return ConvertToXDocument(value);
            if (typeof(System.Xml.Linq.XElement) == targetType) return ConvertToXElement(value);
            if (typeof(byte[]) == targetType) return ConvertToByteArray(value);
            if (typeof(char[]) == targetType) return ConvertToCharArray(value);

            if (value == null)
                return null;
            //Check whether the target Type can be assigned from the value's Type
            if (targetType.IsAssignableFrom(value.GetType()))
                return value;//Skip further adapting

            //Try to convert using a type converter
            TypeConverter typeConverter = ReflectionUtils.GetTypeConverter(targetType);// TypeDescriptor.GetConverter(targetType);
            if (typeConverter != null && typeConverter.CanConvertFrom(value.GetType()))
                return typeConverter.ConvertFrom(value);
            //Custom type converters handled here (for example ByteArray)
            typeConverter = ReflectionUtils.GetTypeConverter(value);// TypeDescriptor.GetConverter(value);
            if (typeConverter != null && typeConverter.CanConvertTo(targetType))
                return typeConverter.ConvertTo(value, targetType);

            if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.Generic.ICollection`1") && value is IList)
            {
                object obj = CreateInstance(targetType);
                if (obj != null)
                {
                    //For generic interfaces, the name parameter is the mangled name, ending with a grave accent (`) and the number of type parameters
                    Type[] typeParameters = ReflectionUtils.GetGenericArguments(targetType);
                    if (typeParameters != null && typeParameters.Length == 1)
                    {
                        //For generic interfaces, the name parameter is the mangled name, ending with a grave accent (`) and the number of type parameters
                        Type typeGenericICollection = targetType.GetInterface("System.Collections.Generic.ICollection`1", true);
                        MethodInfo miAddCollection = targetType.GetMethod("Add");
                        IList source = value as IList;
                        for (int i = 0; i < (value as IList).Count; i++)
                            miAddCollection.Invoke(obj, new object[] { ChangeType(source[i], typeParameters[0]) });
                    }
                    return obj;
                }
            }

            if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.IList") && value is IList)
            {
                object obj = CreateInstance(targetType);
                if (obj != null)
                {
                    IList source = value as IList;
                    IList destination = obj as IList;
                    for (int i = 0; i < source.Count; i++)
                        destination.Add(source[i]);
                    return obj;
                }
            }

            if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.Generic.IDictionary`2") && value is IDictionary)
            {
                object obj = CreateInstance(targetType);
                if (obj != null)
                {
                    IDictionary source = value as IDictionary;
                    Type[] typeParameters = ReflectionUtils.GetGenericArguments(targetType);
                    if (typeParameters != null && typeParameters.Length == 2)
                    {
                        //For generic interfaces, the name parameter is the mangled name, ending with a grave accent (`) and the number of type parameters
                        Type typeGenericIDictionary = targetType.GetInterface("System.Collections.Generic.IDictionary`2", true);
                        MethodInfo miAddCollection = targetType.GetMethod("Add");
                        IDictionary dictionary = value as IDictionary;
                        foreach (DictionaryEntry entry in dictionary)
                        {
                            miAddCollection.Invoke(obj, new object[] {
                                ChangeType(entry.Key, typeParameters[0]),
                                ChangeType(entry.Value, typeParameters[1]) 
                            });
                        }
                    }
                    return obj;
                }
            }

            if (ReflectionUtils.ImplementsInterface(targetType, "System.Collections.IDictionary") && value is IDictionary)
            {
                object obj = CreateInstance(targetType);
                if (obj != null)
                {
                    IDictionary source = value as IDictionary;
                    IDictionary destination = obj as IDictionary;
                    foreach (DictionaryEntry entry in source)
                        destination.Add(entry.Key, entry.Value);
                    return obj;
                }
            }

            return System.Convert.ChangeType(value, targetType, null);
        }

        #region Nullable Types

        
        public static SByte? ConvertToNullableSByte(object value)
        {
            if (value is SByte) return (SByte?)value;
            if (value == null)  return null;
            return SolidSoft.AMFCore.Util.Convert.ToNullableSByte(value);
        }

        public static Int16? ConvertToNullableInt16(object value)
        {
            if (value is Int16) return (Int16?)value;
            if (value == null)  return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableInt16(value);
        }

        public static Int32? ConvertToNullableInt32(object value)
        {
            if (value is Int32) return (Int32?)value;
            if (value == null)  return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableInt32(value);
        }

        public static Int64? ConvertToNullableInt64(object value)
        {
            if (value is Int64) return (Int64?)value;
            if (value == null)  return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableInt64(value);
        }

        public static Byte? ConvertToNullableByte(object value)
        {
            if (value is Byte) return (Byte?)value;
            if (value == null) return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableByte(value);
        }

        
        public static UInt16? ConvertToNullableUInt16(object value)
        {
            if (value is UInt16) return (UInt16?)value;
            if (value == null)   return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableUInt16(value);
        }

        
        public static UInt32? ConvertToNullableUInt32(object value)
        {
            if (value is UInt32) return (UInt32?)value;
            if (value == null)   return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableUInt32(value);
        }

        
        public static UInt64? ConvertToNullableUInt64(object value)
        {
            if (value is UInt64) return (UInt64?)value;
            if (value == null)   return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableUInt64(value);
        }

        public static Char? ConvertToNullableChar(object value)
        {
            if (value is Char) return (Char?)value;
            if (value == null) return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableChar(value);
        }

        public static bool CanConvertToNullableChar(object value)
        {
            if (value is Char) return true;
            if (value == null) return true;
            return SolidSoft.AMFCore.Util.Convert.CanConvertToNullableChar(value);
        }

        public static Double? ConvertToNullableDouble(object value)
        {
            if (value is Double) return (Double?)value;
            if (value == null)   return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableDouble(value);
        }

        public static Single? ConvertToNullableSingle(object value)
        {
            if (value is Single) return (Single?)value;
            if (value == null)   return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableSingle(value);
        }

        public static Boolean? ConvertToNullableBoolean(object value)
        {
            if (value is Boolean) return (Boolean?)value;
            if (value == null)    return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableBoolean(value);
        }

        public static DateTime? ConvertToNullableDateTime(object value)
        {
            if (value is DateTime) return (DateTime?)value;
            if (value == null)     return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableDateTime(value);
        }

        public static Decimal? ConvertToNullableDecimal(object value)
        {
            if (value is Decimal) return (Decimal?)value;
            if (value == null)    return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableDecimal(value);
        }

        public static Guid? ConvertToNullableGuid(object value)
        {
            if (value is Guid) return (Guid?)value;
            if (value == null) return null;

            return SolidSoft.AMFCore.Util.Convert.ToNullableGuid(value);
        }

        #endregion

        #region Primitive Types

        static SByte _defaultSByteNullValue;
        
        public static SByte ConvertToSByte(object value)
        {
            return
                value is SByte ? (SByte)value :
                value == null ? _defaultSByteNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToSByte(value);
        }
        static Int16 _defaultInt16NullValue;
        public static Int16 ConvertToInt16(object value)
        {
            return
                value is Int16 ? (Int16)value :
                value == null ? _defaultInt16NullValue :
                    SolidSoft.AMFCore.Util.Convert.ToInt16(value);
        }

        static Int32 _defaultInt32NullValue;
        public static Int32 ConvertToInt32(object value)
        {
            return
                value is Int32 ? (Int32)value :
                value == null ? _defaultInt32NullValue :
                    SolidSoft.AMFCore.Util.Convert.ToInt32(value);
        }

        static Int64 _defaultInt64NullValue;
        public static Int64 ConvertToInt64(object value)
        {
            return
                value is Int64 ? (Int64)value :
                value == null ? _defaultInt64NullValue :
                    SolidSoft.AMFCore.Util.Convert.ToInt64(value);
        }

        static Byte _defaultByteNullValue;
        public static Byte ConvertToByte(object value)
        {
            return
                value is Byte ? (Byte)value :
                value == null ? _defaultByteNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToByte(value);
        }

        static UInt16 _defaultUInt16NullValue;
        
        public static UInt16 ConvertToUInt16(object value)
        {
            return
                value is UInt16 ? (UInt16)value :
                value == null ? _defaultUInt16NullValue :
                    SolidSoft.AMFCore.Util.Convert.ToUInt16(value);
        }
        static UInt32 _defaultUInt32NullValue;
        
        public static UInt32 ConvertToUInt32(object value)
        {
            return
                value is UInt32 ? (UInt32)value :
                value == null ? _defaultUInt32NullValue :
                    SolidSoft.AMFCore.Util.Convert.ToUInt32(value);
        }

        static UInt64 _defaultUInt64NullValue;
        
        public static UInt64 ConvertToUInt64(object value)
        {
            return
                value is UInt64 ? (UInt64)value :
                value == null ? _defaultUInt64NullValue :
                    SolidSoft.AMFCore.Util.Convert.ToUInt64(value);
        }

        static Char _defaultCharNullValue;
        public static Char ConvertToChar(object value)
        {
            return
                value is Char ? (Char)value :
                value == null ? _defaultCharNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToChar(value);
        }

        public static bool CanConvertToChar(object value)
        {
            return
                value is Char ? true :
                value == null ? true :
                    SolidSoft.AMFCore.Util.Convert.CanConvertToChar(value);
        }

        static Single _defaultSingleNullValue;
        public static Single ConvertToSingle(object value)
        {
            return
                value is Single ? (Single)value :
                value == null ? _defaultSingleNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToSingle(value);
        }

        static Double _defaultDoubleNullValue;
        public static Double ConvertToDouble(object value)
        {
            return
                value is Double ? (Double)value :
                value == null ? _defaultDoubleNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToDouble(value);
        }

        static Boolean _defaultBooleanNullValue;
        public static Boolean ConvertToBoolean(object value)
        {
            return
                value is Boolean ? (Boolean)value :
                value == null ? _defaultBooleanNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToBoolean(value);
        }

        #endregion

        #region Simple Types

        static string _defaultStringNullValue;
        public static String ConvertToString(object value)
        {
            return
                value is String ? (String)value :
                value == null ? _defaultStringNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToString(value);
        }

        static DateTime _defaultDateTimeNullValue;
        public static DateTime ConvertToDateTime(object value)
        {
            return
                value is DateTime ? (DateTime)value :
                value == null ? _defaultDateTimeNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToDateTime(value);
        }

        static decimal _defaultDecimalNullValue;
        public static Decimal ConvertToDecimal(object value)
        {
            return
                value is Decimal ? (Decimal)value :
                value == null ? _defaultDecimalNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToDecimal(value);
        }

        static Guid _defaultGuidNullValue;
        public static Guid ConvertToGuid(object value)
        {
            return
                value is Guid ? (Guid)value :
                value == null ? _defaultGuidNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToGuid(value);
        }
        static XmlReader _defaultXmlReaderNullValue;
        public static XmlReader ConvertToXmlReader(object value)
        {
            return
                value is XmlReader ? (XmlReader)value :
                value == null ? _defaultXmlReaderNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToXmlReader(value);
        }
        static XmlDocument _defaultXmlDocumentNullValue;
        public static XmlDocument ConvertToXmlDocument(object value)
        {
            return
                value is XmlDocument ? (XmlDocument)value :
                value == null ? _defaultXmlDocumentNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToXmlDocument(value);
        }
        static XDocument _defaultXDocumentNullValue;
        public static XDocument ConvertToXDocument(object value)
        {
            return
                value is XDocument ? (XDocument)value :
                value == null ? _defaultXDocumentNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToXDocument(value);
        }

        static XElement _defaultXElementNullValue;
        public static XElement ConvertToXElement(object value)
        {
            return
                value is XElement ? (XElement)value :
                value == null ? _defaultXElementNullValue :
                    SolidSoft.AMFCore.Util.Convert.ToXElement(value);
        }

        public static byte[] ConvertToByteArray(object value)
        {
            return
                value is byte[] ? (byte[])value :
                value == null ? null :
                    SolidSoft.AMFCore.Util.Convert.ToByteArray(value);
        }

        public static char[] ConvertToCharArray(object value)
        {
            return
                value is char[] ? (char[])value :
                value == null ? null :
                    SolidSoft.AMFCore.Util.Convert.ToCharArray(value);
        }

        #endregion
    }
}
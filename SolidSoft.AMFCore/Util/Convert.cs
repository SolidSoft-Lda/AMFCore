using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using SolidSoft.AMFCore.AMF3;

namespace SolidSoft.AMFCore.Util
{
    /// <summary>
    /// Converts a base data type to another base data type.
    /// </summary>
    public class Convert
    {
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The String equivalent of the 8-bit signed integer value.</returns>
        
        public static String ToString(SByte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The String equivalent of the 16-bit signed integer value.</returns>
        public static String ToString(Int16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The String equivalent of the 32-bit signed integer value.</returns>
        public static String ToString(Int32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The String equivalent of the 64-bit signed integer value.</returns>
        public static String ToString(Int64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 8-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 8-bit unsigned integer value.</returns>
        public static String ToString(Byte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 16-bit unsigned integer value.</returns>
        
        public static String ToString(UInt16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 32-bit unsigned integer value.</returns>
        
        public static String ToString(UInt32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 64-bit unsigned integer value.</returns>
        
        public static String ToString(UInt64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The String equivalent of the single-precision floating point number.</returns>
        public static String ToString(Single value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The String equivalent of the double-precision floating point number.</returns>
        public static String ToString(Double value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <returns>The String equivalent of the Boolean.</returns>
        public static String ToString(Boolean value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The String equivalent of the Decimal number.</returns>
        public static String ToString(Decimal value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The String equivalent of the Unicode character.</returns>
        public static String ToString(Char value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent String representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The String equivalent of the TimeSpan.</returns>
        public static String ToString(TimeSpan value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent String representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The String equivalent of the DateTime.</returns>
        public static String ToString(DateTime value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The String equivalent of the Guid.</returns>
        public static String ToString(Guid value) { return value.ToString(); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 8-bit signed integer value.</returns>
        
        public static String ToString(SByte? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 16-bit signed integer value.</returns>
        public static String ToString(Int16? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 32-bit signed integer value.</returns>
        public static String ToString(Int32? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 64-bit signed integer value.</returns>
        public static String ToString(Int64? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer  to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 8-bit unsigned integer value.</returns>
        public static String ToString(Byte? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 16-bit unsigned integer value.</returns>
        
        public static String ToString(UInt16? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 32-bit unsigned integer value.</returns>
        
        public static String ToString(UInt32? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 64-bit unsigned integer value.</returns>
        
        public static String ToString(UInt64? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The String equivalent of the nullable single-precision floating point number.</returns>
        public static String ToString(Single? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The String equivalent of the nullable double-precision floating point number.</returns>
        public static String ToString(Double? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Boolean value.</param>
        /// <returns>The String equivalent of the nullable Boolean value.</returns>
        public static String ToString(Boolean? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The String equivalent of the nullable Decimal number.</returns>
        public static String ToString(Decimal? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The String equivalent of the nullable Unicode character.</returns>
        public static String ToString(Char? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The String equivalent of the nullable TimeSpan.</returns>
        public static String ToString(TimeSpan? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The String equivalent of the nullable DateTime.</returns>
        public static String ToString(DateTime? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The String equivalent of the nullable Guid.</returns>
        public static String ToString(Guid? value) { return value.ToString(); }

        /// <summary>
        /// Converts the value of the specified Type to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The String equivalent of the Type.</returns>
        public static String ToString(Type value) { return value == null ? null : value.FullName; }
        /// <summary>
        /// Converts the value of the specified XmlDocument to its equivalent String representation.
        /// </summary>
        /// <param name="value">An XmlDocument.</param>
        /// <returns>The String equivalent of the XmlDocument.</returns>
        public static String ToString(XmlDocument value) { return value == null ? null : value.InnerXml; }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent String representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The String equivalent of the Object.</returns>
        public static String ToString(object value)
        {
            if (value == null || value is DBNull) return String.Empty;

            if (value is String) return (String)value;

            // Scalar Types.
            //
            if (value is Char) return ToString((Char)value);
            if (value is TimeSpan) return ToString((TimeSpan)value);
            if (value is DateTime) return ToString((DateTime)value);
            if (value is Guid) return ToString((Guid)value);

            if (value is XmlDocument) return ToString((XmlDocument)value);

            if (value is Type) return ToString((Type)value);

            if (value is IConvertible) return ((IConvertible)value).ToString(null);
            if (value is IFormattable) return ((IFormattable)value).ToString(null, null);

            return value.ToString();
        }

        /// <summary>
        /// Checks whether the value of the specified Object can be converted to a Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>Returns true if the specified Object can be converted to a Unicode character.</returns>
        public static bool CanConvertToChar(object value)
        {
            if (value == null || value is DBNull) return true;

            if (value is Char) return true;
            // Scalar Types.
            if (value is String) return (value == null || (value as String).Length == 1);
            if (value is Boolean) return true;

            if (value is IConvertible)
            {
                try
                {
                    ((IConvertible)value).ToChar(null);
                    return true;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether the value of the specified Object can be converted to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>Returns true if the specified Object can be converted to a nullable Unicode character.</returns>
        public static bool CanConvertToNullableChar(object value)
        {
            if (value == null || value is DBNull) return true;

            // Scalar Types.
            //
            if (value is Char) return true;
            if (value is String) return (value == null || (value as String).Length == 1);

            if (value is Boolean) return true;

            if (value is IConvertible)
            {
                try
                {
                    ((IConvertible)value).ToChar(null);
                    return true;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(String value) { return value == null ? (SByte)0 : SByte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Int16 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Int32 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Int64 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Byte value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(UInt16 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(UInt32 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(UInt64 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Single value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Double value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Decimal value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Boolean value) { return (SByte)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Char value) { return checked((SByte)value); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(SByte? value) { return value.HasValue ? value.Value : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Int16? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Int32? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Int64? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
		
        public static SByte ToSByte(Byte? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(UInt16? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(UInt32? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(UInt64? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Single? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Double? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Decimal? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Char? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(Boolean? value) { return (value.HasValue && value.Value) ? (SByte)1 : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        
        public static SByte ToSByte(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is SByte) return (SByte)value;

            // Scalar Types.
            //
            if (value is String) return ToSByte((String)value);

            if (value is Boolean) return ToSByte((Boolean)value);
            if (value is Char) return ToSByte((Char)value);

            // SqlTypes.
            //

            if (value is IConvertible) return ((IConvertible)value).ToSByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(SByte));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(String value) { return value == null ? false : Boolean.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(SByte value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int16 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int32 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int64 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Byte value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(UInt16 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(UInt32 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(UInt64 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Single value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Double value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Decimal value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Char value)
        {
            switch (value)
            {
                case (Char)0: return false; // Allow int <=> Char <=> Boolean
                case '0': return false;
                case 'n': return false;
                case 'N': return false;
                case 'f': return false;
                case 'F': return false;

                case (Char)1: return true; // Allow int <=> Char <=> Boolean
                case '1': return true;
                case 'y': return true;
                case 'Y': return true;
                case 't': return true;
                case 'T': return true;
            }

            throw new InvalidCastException(string.Format(
                "Invalid cast from {0} to {1}", typeof(Char).FullName, typeof(Boolean).FullName));

        }

        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Boolean? value) { return value.HasValue ? value.Value : false; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
		
        public static Boolean ToBoolean(SByte? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int16? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int32? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int64? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Byte? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(UInt16? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(UInt32? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        
        public static Boolean ToBoolean(UInt64? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Single? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Double? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Decimal? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Char? value) { return value.HasValue ? ToBoolean(value.Value) : false; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(object value)
        {
            if (value == null || value is DBNull) return false;

            if (value is Boolean) return (Boolean)value;

            // Scalar Types.
            //
            if (value is String) return ToBoolean((String)value);

            if (value is Char) return ToBoolean((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToBoolean(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Boolean));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(String value) { return value == null ? (Byte)0 : Byte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(SByte value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int16 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int32 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int64 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(UInt16 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(UInt32 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(UInt64 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Single value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Double value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Decimal value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Boolean value) { return (Byte)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Char value) { return checked((Byte)value); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Byte? value) { return value.HasValue ? value.Value : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(SByte? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int16? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int32? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int64? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(UInt16? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(UInt32? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        
        public static Byte ToByte(UInt64? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Single? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Double? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Decimal? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Char? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Boolean? value) { return (value.HasValue && value.Value) ? (Byte)1 : (Byte)0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Byte) return (Byte)value;

            // Scalar Types.
            //
            if (value is String) return ToByte((String)value);

            if (value is Boolean) return ToByte((Boolean)value);
            if (value is Char) return ToByte((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Byte));
        }

        public static Byte[] ToByteArray(string p) { return p == null ? null : System.Text.Encoding.UTF8.GetBytes(p); }
        
        public static Byte[] ToByteArray(SByte p) { return new byte[] { checked((Byte)p) }; }
        public static Byte[] ToByteArray(Int16 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Int32 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Int64 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Byte p) { return new byte[] { p }; }
        
        public static Byte[] ToByteArray(UInt16 p) { return BitConverter.GetBytes(p); }
        
        public static Byte[] ToByteArray(UInt32 p) { return BitConverter.GetBytes(p); }
        
        public static Byte[] ToByteArray(UInt64 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Char p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Single p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Double p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Boolean p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(DateTime p) { return ToByteArray(p.ToBinary()); }
        public static Byte[] ToByteArray(TimeSpan p) { return ToByteArray(p.Ticks); }
        public static Byte[] ToByteArray(Guid p) { return p == Guid.Empty ? null : p.ToByteArray(); }

        public static Byte[] ToByteArray(Decimal p)
        {
            int[] bits = Decimal.GetBits(p);
            byte[] bytes = new byte[bits.Length << 2];

            for (int i = 0; i < bits.Length; ++i)
                Buffer.BlockCopy(BitConverter.GetBytes(bits[i]), 0, bytes, i * 4, 4);

            return bytes;
        }

        public static Byte[] ToByteArray(Stream p)
        {
            if (p == null) return null;
            if (p is MemoryStream) return ((MemoryStream)p).ToArray();

            long position = p.Seek(0, SeekOrigin.Begin);
            Byte[] bytes = new Byte[p.Length];
            p.Read(bytes, 0, bytes.Length);
            p.Position = position;

            return bytes;
        }
        
        public static Byte[] ToByteArray(ByteArray p)
        {
            if (p == null) return null;

            return p.GetBuffer();
        }

        public static Byte[] ToByteArray(Guid? p) { return p.HasValue ? p.Value.ToByteArray() : null; }
        
        public static Byte[] ToByteArray(SByte? p) { return p.HasValue ? new byte[] { checked((Byte)p.Value) } : null; }
        public static Byte[] ToByteArray(Int16? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Int32? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Int64? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Byte? p) { return p.HasValue ? new byte[] { p.Value } : null; }
        
        public static Byte[] ToByteArray(UInt16? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        
        public static Byte[] ToByteArray(UInt32? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        
        public static Byte[] ToByteArray(UInt64? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Char? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Single? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Double? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(Boolean? p) { return p.HasValue ? BitConverter.GetBytes(p.Value) : null; }
        public static Byte[] ToByteArray(DateTime? p) { return p.HasValue ? ToByteArray(p.Value.ToBinary()) : null; }
        public static Byte[] ToByteArray(TimeSpan? p) { return p.HasValue ? ToByteArray(p.Value.Ticks) : null; }
        public static Byte[] ToByteArray(Decimal? p) { return p.HasValue ? ToByteArray(p.Value) : null; }

        public static Byte[] ToByteArray(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is Byte[]) return (Byte[])p;

            // Scalar Types.
            //
            if (p is String) return ToByteArray((String)p);

            if (p is SByte) return ToByteArray((SByte)p);
            if (p is Int16) return ToByteArray((Int16)p);
            if (p is Int32) return ToByteArray((Int32)p);
            if (p is Int64) return ToByteArray((Int64)p);

            if (p is Byte) return ToByteArray((Byte)p);
            if (p is UInt16) return ToByteArray((UInt16)p);
            if (p is UInt32) return ToByteArray((UInt32)p);
            if (p is UInt64) return ToByteArray((UInt64)p);

            if (p is Char) return ToByteArray((Char)p);
            if (p is Single) return ToByteArray((Single)p);
            if (p is Double) return ToByteArray((Double)p);
            if (p is Boolean) return ToByteArray((Boolean)p);
            if (p is Decimal) return ToByteArray((Decimal)p);

            if (p is DateTime) return ToByteArray((DateTime)p);
            if (p is TimeSpan) return ToByteArray((TimeSpan)p);

            if (p is Stream) return ToByteArray((Stream)p);
            if (p is Guid) return ToByteArray((Guid)p);

            if (p is ByteArray) return ToByteArray((ByteArray)p);

            throw CreateInvalidCastException(p.GetType(), typeof(Byte[]));
        }

        /// <summary>
        /// Converts the first character of the specified String to a Unicode character.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Unicode character.</returns>
        public static Char ToChar(String value)
        {
            Char result;
            if (Char.TryParse(value, out result))
                return result;
            return (Char)0;
        }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        
        public static Char ToChar(SByte value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int16 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int32 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int64 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Byte value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character.</returns>
        
        public static Char ToChar(UInt16 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        
        public static Char ToChar(UInt32 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        
        public static Char ToChar(UInt64 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Single value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Double value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Decimal value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to a Unicode character.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Boolean value) { return (Char)(value ? 1 : 0); }

        /// <summary>
        /// Converts the specified nullable character to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable Char.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Char? value) { return value.HasValue ? value.Value : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent Unicode character.</returns>
		
        public static Char ToChar(SByte? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int16? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int32? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int64? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Byte? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        
        public static Char ToChar(UInt16? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        
        public static Char ToChar(UInt32? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        
        public static Char ToChar(UInt64? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Single? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Double? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Decimal? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Boolean? value) { return (value.HasValue && value.Value) ? (Char)1 : (Char)0; }
        
        /// <summary>
        /// Converts the value of the specified Object to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(object value)
        {
            if (value == null || value is DBNull) return '\x0';

            if (value is Char) return (Char)value;

            // Scalar Types.
            //
            if (value is String) return ToChar((String)value);
            if (value is Boolean) return ToChar((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToChar(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Char));
        }

        public static Char[] ToCharArray(String p) { return p == null ? null : p.ToCharArray(); }

        public static Char[] ToCharArray(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is Char[]) return (Char[])p;

            // Scalar Types.
            //
            if (p is String) return ToCharArray((String)p);

            return ToString(p).ToCharArray();
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(String value) { return value == null ? DateTime.MinValue : DateTime.Parse(value); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(TimeSpan value) { return DateTime.MinValue + value; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Int64 value) { return DateTime.MinValue + TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Double value) { return DateTime.MinValue + TimeSpan.FromDays(value); }

        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(DateTime? value) { return value.HasValue ? value.Value : DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(TimeSpan? value) { return value.HasValue ? DateTime.MinValue + value.Value : DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Int64? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromTicks(value.Value) : DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Double? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromDays(value.Value) : DateTime.MinValue; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent DateTime.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(object value)
        {
            if (value == null || value is DBNull) return DateTime.MinValue;

            if (value is DateTime) return (DateTime)value;

            // Scalar Types.
            //
            if (value is String) return ToDateTime((String)value);
            if (value is TimeSpan) return ToDateTime((TimeSpan)value);
            if (value is Int64) return ToDateTime((Int64)value);
            if (value is Double) return ToDateTime((Double)value);

            if (value is IConvertible) return ((IConvertible)value).ToDateTime(null);

            throw CreateInvalidCastException(value.GetType(), typeof(DateTime));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(String value) { return value == null ? 0.0m : Decimal.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(SByte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Byte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(UInt16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(UInt32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(UInt64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Single value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Double value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Boolean value) { return value ? 1.0m : 0.0m; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Char value) { return checked((Decimal)value); }

        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Decimal? value) { return value.HasValue ? value.Value : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(SByte? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int16? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int32? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int64? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Byte? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(UInt16? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(UInt32? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        
        public static Decimal ToDecimal(UInt64? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Single? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Double? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Char? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Boolean? value) { return (value.HasValue && value.Value) ? 1.0m : 0.0m; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(object value)
        {
            if (value == null || value is DBNull) return 0.0m;

            if (value is Decimal) return (Decimal)value;

            // Scalar Types.
            //
            if (value is String) return ToDecimal((String)value);

            if (value is Boolean) return ToDecimal((Boolean)value);
            if (value is Char) return ToDecimal((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToDecimal(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Decimal));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(String value) { return value == null ? 0.0 : Double.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(SByte value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int16 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int32 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int64 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Byte value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(UInt16 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(UInt32 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(UInt64 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Single value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Decimal value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Boolean value) { return value ? 1.0 : 0.0; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Char value) { return checked((Double)value); }
        public static Double ToDouble(DateTime value) { return (value - DateTime.MinValue).TotalDays; }
        public static Double ToDouble(TimeSpan value) { return value.TotalDays; }

        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Double? value) { return value.HasValue ? value.Value : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
		
        public static Double ToDouble(SByte? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int16? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int32? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int64? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Byte? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(UInt16? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(UInt32? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        
        public static Double ToDouble(UInt64? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Single? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Decimal? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Char? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Boolean? value) { return (value.HasValue && value.Value) ? 1.0 : 0.0; }
        public static Double ToDouble(DateTime? value) { return value.HasValue ? (value.Value - DateTime.MinValue).TotalDays : 0.0; }
        public static Double ToDouble(TimeSpan? value) { return value.HasValue ? value.Value.TotalDays : 0.0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(object value)
        {
            if (value == null || value is DBNull) return 0.0;

            if (value is Double) return (Double)value;

            // Scalar Types.
            //
            if (value is String) return ToDouble((String)value);

            if (value is Boolean) return ToDouble((Boolean)value);
            if (value is Char) return ToDouble((Char)value);
            if (value is DateTime) return ToDouble((DateTime)value);
            if (value is TimeSpan) return ToDouble((TimeSpan)value);

            if (value is IConvertible) return ((IConvertible)value).ToDouble(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Double));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(String value) { return value == null ? (Int16)0 : Int16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(SByte value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int32 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int64 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Byte value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(UInt16 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(UInt32 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(UInt64 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Single value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Double value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Decimal value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Boolean value) { return (Int16)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Char value) { return checked((Int16)value); }

        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int16? value) { return value.HasValue ? value.Value : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(SByte? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int32? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int64? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Byte? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(UInt16? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(UInt32? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        
        public static Int16 ToInt16(UInt64? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Single? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Double? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Decimal? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Char? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Boolean? value) { return (value.HasValue && value.Value) ? (Int16)1 : (Int16)0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Int16) return (Int16)value;

            // Scalar Types.
            //
            if (value is String) return ToInt16((String)value);

            if (value is Boolean) return ToInt16((Boolean)value);
            if (value is Char) return ToInt16((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int16));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(String value) { return value == null ? 0 : Int32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(SByte value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int16 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int64 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Byte value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(UInt16 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(UInt32 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(UInt64 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Single value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Double value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Decimal value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Char value) { return checked((Int32)value); }

        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int32? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(SByte? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int16? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int64? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Byte? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(UInt16? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(UInt32? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        
        public static Int32 ToInt32(UInt64? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Single? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Double? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Decimal? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Char? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Boolean? value) { return (value.HasValue && value.Value) ? 1 : 0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Int32) return (Int32)value;

            // Scalar Types.
            //
            if (value is String) return ToInt32((String)value);

            if (value is Boolean) return ToInt32((Boolean)value);
            if (value is Char) return ToInt32((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int32));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(String value) { return value == null ? 0 : Int64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(SByte value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int16 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int32 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Byte value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(UInt16 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(UInt32 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(UInt64 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Single value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Double value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Decimal value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Char value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(DateTime value) { return (value - DateTime.MinValue).Ticks; }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(TimeSpan value) { return value.Ticks; }

        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int64? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(SByte? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int16? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int32? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Byte? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(UInt16? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(UInt32? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        
        public static Int64 ToInt64(UInt64? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Single? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Double? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Decimal? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Char? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Boolean? value) { return (value.HasValue && value.Value) ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(DateTime? value) { return value.HasValue ? (value.Value - DateTime.MinValue).Ticks : 0; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(TimeSpan? value) { return value.HasValue ? value.Value.Ticks : 0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Int64) return (Int64)value;

            // Scalar Types.
            //
            if (value is String) return ToInt64((String)value);

            if (value is Char) return ToInt64((Char)value);
            if (value is Boolean) return ToInt64((Boolean)value);
            if (value is DateTime) return ToInt64((DateTime)value);
            if (value is TimeSpan) return ToInt64((TimeSpan)value);

            if (value is IConvertible) return ((IConvertible)value).ToInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int64));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent Guid.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(String value) { return value == null ? Guid.Empty : new Guid(value); }

        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent Guid.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(Guid? value) { return value.HasValue ? value.Value : Guid.Empty; }

        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent Guid.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(Byte[] value) { return value == null ? Guid.Empty : new Guid(value); }
        /// <summary>
        /// Converts the value of the specified Type to its equivalent Guid.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(Type value) { return value == null ? Guid.Empty : value.GUID; }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent Guid.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(object value)
        {
            if (value == null || value is DBNull) return Guid.Empty;

            if (value is Guid) return (Guid)value;

            // Scalar Types.
            //
            if (value is String) return ToGuid((String)value);

            // Other Types.
            //
            if (value is Byte[]) return ToGuid((Byte[])value);
            if (value is Type) return ToGuid((Type)value);

            throw CreateInvalidCastException(value.GetType(), typeof(Guid));
        }

        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Single value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(String value) { return value == null ? null : (Single?)Single.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(SByte value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int16 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int32 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int64 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Byte value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(UInt16 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(UInt32 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(UInt64 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Double value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Decimal value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Char value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Boolean value) { return value ? 1.0f : 0.0f; }

        // Nullable Types.
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(SByte? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int16? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int32? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int64? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Byte? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(UInt16? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(UInt32? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        
        public static Single? ToNullableSingle(UInt64? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Double? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Decimal? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Char? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Boolean? value) { return value.HasValue ? (Single?)(value.Value ? 1.0f : 0.0f) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Single) return ToNullableSingle((Single)value);
            if (value is String) return ToNullableSingle((String)value);

            if (value is Char) return ToNullableSingle((Char)value);
            if (value is Boolean) return ToNullableSingle((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToSingle(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Single?));
        }

        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Double value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(String value) { return value == null ? null : (Double?)Double.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
		
        public static Double? ToNullableDouble(SByte value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int16 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int32 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int64 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Byte value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(UInt16 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(UInt32 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(UInt64 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Single value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Decimal value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Char value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Boolean value) { return value ? 1.0 : 0.0; }
        public static Double? ToNullableDouble(DateTime value) { return (value - DateTime.MinValue).TotalDays; }
        public static Double? ToNullableDouble(TimeSpan value) { return value.TotalDays; }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(SByte? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int16? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int32? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int64? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Byte? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(UInt16? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(UInt32? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        
        public static Double? ToNullableDouble(UInt64? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Single? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Decimal? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Char? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Boolean? value) { return value.HasValue ? (Double?)(value.Value ? 1.0 : 0.0) : null; }
        public static Double? ToNullableDouble(DateTime? value) { return value.HasValue ? (Double?)(value.Value - DateTime.MinValue).TotalDays : null; }
        public static Double? ToNullableDouble(TimeSpan? value) { return value.HasValue ? (Double?)value.Value.TotalDays : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Double) return ToNullableDouble((Double)value);
            if (value is String) return ToNullableDouble((String)value);

            if (value is Char) return ToNullableDouble((Char)value);
            if (value is Boolean) return ToNullableDouble((Boolean)value);
            if (value is DateTime) return ToNullableDouble((DateTime)value);
            if (value is TimeSpan) return ToNullableDouble((TimeSpan)value);

            if (value is IConvertible) return ((IConvertible)value).ToDouble(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Double?));
        }

        /// <summary>
        /// Converts the value of the specified Boolean value to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Boolean value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(String value) { return value == null ? null : (Boolean?)Boolean.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
		
        public static Boolean? ToNullableBoolean(SByte value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int16 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int32 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int64 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Byte value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(UInt16 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(UInt32 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(UInt64 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Single value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Double value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Decimal value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Char value) { return ToBoolean(value); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(SByte? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int16? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int32? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int64? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Byte? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(UInt16? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(UInt32? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        
        public static Boolean? ToNullableBoolean(UInt64? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Single? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Double? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Decimal? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Char? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Boolean) return ToNullableBoolean((Boolean)value);
            if (value is String) return ToNullableBoolean((String)value);

            if (value is Char) return ToNullableBoolean((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToBoolean(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Boolean?));
        }

        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Decimal value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(String value) { return value == null ? null : (Decimal?)Decimal.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(SByte value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int16 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int32 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int64 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Byte value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(UInt16 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(UInt32 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(UInt64 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Single value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Double value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Char value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Boolean value) { return value ? 1.0m : 0.0m; }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(SByte? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int16? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int32? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int64? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Byte? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(UInt16? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(UInt32? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        
        public static Decimal? ToNullableDecimal(UInt64? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Single? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Double? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Char? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Boolean? value) { return value.HasValue ? (Decimal?)(value.Value ? 1.0m : 0.0m) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is double && Double.IsNaN((double)value)) return null;
            if (value is Decimal) return ToNullableDecimal((Decimal)value);
            if (value is String) return ToNullableDecimal((String)value);

            if (value is Char) return ToNullableDecimal((Char)value);
            if (value is Boolean) return ToNullableDecimal((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToDecimal(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Decimal?));
        }

        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(DateTime value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(String value) { return value == null ? null : (DateTime?)DateTime.Parse(value); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(TimeSpan value) { return DateTime.MinValue + value; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Int64 value) { return DateTime.MinValue + TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Double value) { return DateTime.MinValue + TimeSpan.FromDays(value); }

        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(TimeSpan? value) { return value.HasValue ? DateTime.MinValue + value.Value : (DateTime?)null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Int64? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromTicks(value.Value) : (DateTime?)null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Double? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromDays(value.Value) : (DateTime?)null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is DateTime) return ToNullableDateTime((DateTime)value);
            if (value is String) return ToNullableDateTime((String)value);

            if (value is TimeSpan) return ToNullableDateTime((TimeSpan)value);
            if (value is Int64) return ToNullableDateTime((Int64)value);
            if (value is Double) return ToNullableDateTime((Double)value);

            if (value is IConvertible) return ((IConvertible)value).ToDateTime(null);

            throw CreateInvalidCastException(value.GetType(), typeof(DateTime?));
        }

        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Byte value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(String value) { return value == null ? null : (Byte?)Byte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
		
        public static Byte? ToNullableByte(SByte value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int16 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int32 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int64 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        
        public static Byte? ToNullableByte(UInt16 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        
        public static Byte? ToNullableByte(UInt32 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        
        public static Byte? ToNullableByte(UInt64 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Single value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Double value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Decimal value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Char value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Boolean value) { return (Byte?)(value ? 1 : 0); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        
        public static Byte? ToNullableByte(SByte? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int16? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int32? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int64? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
		
        public static Byte? ToNullableByte(UInt16? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        
        public static Byte? ToNullableByte(UInt32? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        
        public static Byte? ToNullableByte(UInt64? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Single? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Double? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Decimal? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Char? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Boolean? value) { return value.HasValue ? (Byte?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Byte) return ToNullableByte((Byte)value);
            if (value is String) return ToNullableByte((String)value);

            if (value is Char) return ToNullableByte((Char)value);
            if (value is Boolean) return ToNullableByte((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Byte?));
        }

        // Scalar Types.
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(UInt16 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(String value) { return value == null ? null : (UInt16?)UInt16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(SByte value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Int16 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Int32 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Int64 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Byte value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(UInt32 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(UInt64 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Single value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Double value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Decimal value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Char value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Boolean value) { return (UInt16?)(value ? 1 : 0); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(SByte? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Int16? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Int32? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Int64? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Byte? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(UInt32? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(UInt64? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
		
        public static UInt16? ToNullableUInt16(Single? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Double? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
		
        public static UInt16? ToNullableUInt16(Decimal? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Char? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(Boolean? value) { return value.HasValue ? (UInt16?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        
        public static UInt16? ToNullableUInt16(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is UInt16) return ToNullableUInt16((UInt16)value);
            if (value is String) return ToNullableUInt16((String)value);

            if (value is Char) return ToNullableUInt16((Char)value);
            if (value is Boolean) return ToNullableUInt16((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt16?));
        }

        // Scalar Types.
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(UInt32 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(String value) { return value == null ? null : (UInt32?)UInt32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(SByte value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Int16 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Int32 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Int64 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Byte value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(UInt16 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(UInt64 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Single value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Double value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Decimal value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Char value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Boolean value) { return (UInt32?)(value ? 1 : 0); }

        // Nullable Types.
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(SByte? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Int16? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Int32? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Int64? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
		
        public static UInt32? ToNullableUInt32(Byte? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(UInt16? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(UInt64? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Single? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Double? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Decimal? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Char? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(Boolean? value) { return value.HasValue ? (UInt32?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        
        public static UInt32? ToNullableUInt32(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is UInt32) return ToNullableUInt32((UInt32)value);
            if (value is String) return ToNullableUInt32((String)value);

            if (value is Char) return ToNullableUInt32((Char)value);
            if (value is Boolean) return ToNullableUInt32((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt32?));
        }

        // Scalar Types.
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(UInt64 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(String value) { return value == null ? null : (UInt64?)UInt64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(SByte value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Int16 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Int32 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Int64 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Byte value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(UInt16 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(UInt32 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Single value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Double value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
		
        public static UInt64? ToNullableUInt64(Decimal value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Char value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Boolean value) { return (UInt64?)(value ? 1 : 0); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(SByte? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Int16? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Int32? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Int64? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Byte? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(UInt16? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(UInt32? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Single? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Double? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Decimal? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Char? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(Boolean? value) { return value.HasValue ? (UInt64?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        
        public static UInt64? ToNullableUInt64(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is UInt64) return ToNullableUInt64((UInt64)value);
            if (value is String) return ToNullableUInt64((String)value);

            if (value is Char) return ToNullableUInt64((Char)value);
            if (value is Boolean) return ToNullableUInt64((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt64?));
        }

        // Scalar Types.
        /// <summary>
        /// Converts a Unicode character to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        public static Char? ToNullableChar(Char value) { return value; }
        /// <summary>
        /// Converts the first character of the specified String to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        public static Char? ToNullableChar(String value)
        {
            Char result;
            if (Char.TryParse(value, out result))
                return result;
            return (Char)0;
        }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        
        public static Char? ToNullableChar(SByte value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int16 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int32 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int64 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Byte value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        
        public static Char? ToNullableChar(UInt16 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        
        public static Char? ToNullableChar(UInt32 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        
        public static Char? ToNullableChar(UInt64 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Single value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Double value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Decimal value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Boolean value) { return (Char?)(value ? 1 : 0); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        
        public static Char? ToNullableChar(SByte? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int16? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int32? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int64? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Byte? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        
        public static Char? ToNullableChar(UInt16? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        
        public static Char? ToNullableChar(UInt32? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        
        public static Char? ToNullableChar(UInt64? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Single? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Double? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Decimal? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Boolean? value) { return value.HasValue ? (Char?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Char) return ToNullableChar((Char)value);
            if (value is String) return ToNullableChar((String)value);

            if (value is Boolean) return ToNullableChar((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToChar(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Char?));
        }

        /// <summary>
        /// Converts the value of the specified Guid to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(Guid value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(String value) { return value == null ? null : (Guid?)new Guid(value); }

        /// <summary>
        /// Converts the value of the specified Type to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(Type value) { return value == null ? null : (Guid?)value.GUID; }
        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(Byte[] value) { return value == null ? null : (Guid?)new Guid(value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Guid) return ToNullableGuid((Guid)value);
            if (value is String) return ToNullableGuid((String)value);

            // Other Types.
            //
            if (value is Type) return ToNullableGuid((Type)value);
            if (value is Byte[]) return ToNullableGuid((Byte[])value);

            throw CreateInvalidCastException(value.GetType(), typeof(Guid?));
        }

        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int16 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(String value) { return value == null ? null : (Int16?)Int16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(SByte value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int32 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int64 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Byte value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(UInt16 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(UInt32 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(UInt64 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Single value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Double value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Decimal value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Char value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Boolean value) { return (Int16?)(value ? 1 : 0); }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(SByte? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int32? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int64? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Byte? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(UInt16? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(UInt32? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        
        public static Int16? ToNullableInt16(UInt64? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Single? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Double? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Decimal? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Char? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Boolean? value) { return value.HasValue ? (Int16?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Int16) return ToNullableInt16((Int16)value);
            if (value is String) return ToNullableInt16((String)value);

            if (value is Char) return ToNullableInt16((Char)value);
            if (value is Boolean) return ToNullableInt16((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int16?));
        }

        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int32 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(String value) { return value == null ? null : (Int32?)Int32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
		
        public static Int32? ToNullableInt32(SByte value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int16 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int64 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Byte value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(UInt16 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(UInt32 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(UInt64 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Single value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Double value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Decimal value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Char value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Boolean value) { return value ? 1 : 0; }

        // Nullable Types.
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(SByte? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int16? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int64? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Byte? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(UInt16? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(UInt32? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        
        public static Int32? ToNullableInt32(UInt64? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Single? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Double? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Decimal? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Char? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Boolean? value) { return value.HasValue ? (Int32?)(value.Value ? 1 : 0) : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Int32) return ToNullableInt32((Int32)value);
            if (value is String) return ToNullableInt32((String)value);

            if (value is Char) return ToNullableInt32((Char)value);
            if (value is Boolean) return ToNullableInt32((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int32?));
        }

        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int64 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(String value) { return value == null ? null : (Int64?)Int64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
		
        public static Int64? ToNullableInt64(SByte value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int16 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int32 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Byte value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(UInt16 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(UInt32 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(UInt64 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Single value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Double value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Decimal value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Char value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(DateTime value) { return (value - DateTime.MinValue).Ticks; }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(TimeSpan value) { return value.Ticks; }

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(SByte? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int16? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int32? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Byte? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(UInt16? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(UInt32? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        
        public static Int64? ToNullableInt64(UInt64? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Single? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Double? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Decimal? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Char? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Boolean? value) { return value.HasValue ? (Int64?)(value.Value ? 1 : 0) : null; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(DateTime? value) { return value.HasValue ? (Int64?)(value.Value - DateTime.MinValue).Ticks : null; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(TimeSpan? value) { return value.HasValue ? (Int64?)value.Value.Ticks : null; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            //
            if (value is Int64) return ToNullableInt64((Int64)value);
            if (value is String) return ToNullableInt64((String)value);

            if (value is Char) return ToNullableInt64((Char)value);
            if (value is Boolean) return ToNullableInt64((Boolean)value);
            if (value is DateTime) return ToNullableInt64((DateTime)value);
            if (value is TimeSpan) return ToNullableInt64((TimeSpan)value);

            if (value is IConvertible) return ((IConvertible)value).ToInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int64?));
        }

        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(SByte value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(String value) { return value == null ? null : (SByte?)SByte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Int16 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Int32 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Int64 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Byte value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(UInt16 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(UInt32 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(UInt64 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Single value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Double value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Decimal value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Char value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Boolean value) { return (SByte?)(value ? 1 : 0); }

        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Int16? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Int32? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Int64? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Byte? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(UInt16? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(UInt32? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(UInt64? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Single? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Double? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
		
        public static SByte? ToNullableSByte(Decimal? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Char? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(Boolean? value) { return value.HasValue ? (SByte?)(value.Value ? 1 : 0) : null; }
        
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        
        public static SByte? ToNullableSByte(object value)
        {
            if (value == null || value is DBNull) return null;

            // Scalar Types.
            if (value is SByte) return ToNullableSByte((SByte)value);
            if (value is String) return ToNullableSByte((String)value);

            if (value is Char) return ToNullableSByte((Char)value);
            if (value is Boolean) return ToNullableSByte((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToSByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(SByte?));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(String value) { return value == null ? 0.0f : Single.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(SByte value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int16 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int32 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int64 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Byte value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(UInt16 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(UInt32 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(UInt64 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Double value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Decimal value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Boolean value) { return value ? 1.0f : 0.0f; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Char value) { return checked((Single)value); }

        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Single? value) { return value.HasValue ? value.Value : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
		
        public static Single ToSingle(SByte? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int16? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int32? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int64? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Byte? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(UInt16? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(UInt32? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        
        public static Single ToSingle(UInt64? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Double? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Decimal? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Char? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Boolean? value) { return (value.HasValue && value.Value) ? 1.0f : 0.0f; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(object value)
        {
            if (value == null || value is DBNull) return 0.0f;

            if (value is Single) return (Single)value;

            // Scalar Types.
            //
            if (value is String) return ToSingle((String)value);

            if (value is Boolean) return ToSingle((Boolean)value);
            if (value is Char) return ToSingle((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToSingle(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Single));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(String value) { return value == null ? TimeSpan.MinValue : TimeSpan.Parse(value); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(DateTime value) { return value - DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Int64 value) { return TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Double value) { return TimeSpan.FromDays(value); }

        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(TimeSpan? value) { return value.HasValue ? value.Value : TimeSpan.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(DateTime? value) { return value.HasValue ? value.Value - DateTime.MinValue : TimeSpan.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Int64? value) { return value.HasValue ? TimeSpan.FromTicks(value.Value) : TimeSpan.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Double? value) { return value.HasValue ? TimeSpan.FromDays(value.Value) : TimeSpan.MinValue; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(object value)
        {
            if (value == null || value is DBNull) return TimeSpan.MinValue;

            if (value is TimeSpan) return (TimeSpan)value;

            // Scalar Types.
            //
            if (value is String) return ToTimeSpan((String)value);
            if (value is DateTime) return ToTimeSpan((DateTime)value);
            if (value is Int64) return ToTimeSpan((Int64)value);
            if (value is Double) return ToTimeSpan((Double)value);

            throw CreateInvalidCastException(value.GetType(), typeof(TimeSpan));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(String value) { return value == null ? (UInt16)0 : UInt16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(SByte value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Int16 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Int32 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Int64 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Byte value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(UInt32 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(UInt64 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Single value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Double value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Decimal value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Boolean value) { return (UInt16)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Char value) { return checked((UInt16)value); }

        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(UInt16? value) { return value.HasValue ? value.Value : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(SByte? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Int16? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Int32? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Int64? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Byte? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(UInt32? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(UInt64? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
		
        public static UInt16 ToUInt16(Single? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Double? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Decimal? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Char? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(Boolean? value) { return (value.HasValue && value.Value) ? (UInt16)1 : (UInt16)0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        
        public static UInt16 ToUInt16(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is UInt16) return (UInt16)value;

            // Scalar Types.
            //
            if (value is String) return ToUInt16((String)value);

            if (value is Boolean) return ToUInt16((Boolean)value);
            if (value is Char) return ToUInt16((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt16));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(String value) { return value == null ? 0 : UInt32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(SByte value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Int16 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Int32 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Int64 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Byte value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(UInt16 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(UInt64 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Single value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Double value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Decimal value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Boolean value) { return (UInt32)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Char value) { return checked((UInt32)value); }

        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(UInt32? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(SByte? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Int16? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Int32? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Int64? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Byte? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(UInt16? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(UInt64? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
		
        public static UInt32 ToUInt32(Single? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Double? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Decimal? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Char? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(Boolean? value) { return (value.HasValue && value.Value) ? (UInt32)1 : 0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        
        public static UInt32 ToUInt32(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is UInt32) return (UInt32)value;

            // Scalar Types.
            //
            if (value is String) return ToUInt32((String)value);

            if (value is Boolean) return ToUInt32((Boolean)value);
            if (value is Char) return ToUInt32((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt32));
        }

        /// <summary>
        /// Converts the value of the specified String to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(String value) { return value == null ? 0 : UInt64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(SByte value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Int16 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Int32 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Int64 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Byte value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(UInt16 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(UInt32 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Single value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Double value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Decimal value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Boolean value) { return (UInt64)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Char value) { return checked((UInt64)value); }

        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(UInt64? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
		
        public static UInt64 ToUInt64(SByte? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Int16? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Int32? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Int64? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Byte? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(UInt16? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(UInt32? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Single? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Double? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
		
        public static UInt64 ToUInt64(Decimal? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Char? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(Boolean? value) { return (value.HasValue && value.Value) ? (UInt64)1 : 0; }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        
        public static UInt64 ToUInt64(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is UInt64) return (UInt64)value;

            // Scalar Types.
            //
            if (value is String) return ToUInt64((String)value);

            if (value is Boolean) return ToUInt64((Boolean)value);
            if (value is Char) return ToUInt64((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt64));
        }

        // Scalar Types.
        public static XmlDocument ToXmlDocument(String p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(p);
            return doc;
        }

        // Other Types.
        // 
        public static XmlDocument ToXmlDocument(Stream p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p);
            return doc;
        }

        public static XmlDocument ToXmlDocument(TextReader p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p);
            return doc;
        }

        public static XmlDocument ToXmlDocument(System.Xml.Linq.XDocument p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p.ToString());
            return doc;
        }

        public static XmlDocument ToXmlDocument(System.Xml.Linq.XElement p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p.ToString());
            return doc;
        }

        public static XmlDocument ToXmlDocument(Char[] p) { return p == null ? null : ToXmlDocument(new string(p)); }
        public static XmlDocument ToXmlDocument(Byte[] p) { return p == null ? null : ToXmlDocument(new MemoryStream(p)); }

        public static XmlDocument ToXmlDocument(XmlReader p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p);
            return doc;
        }

        public static XmlDocument ToXmlDocument(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XmlDocument) return (XmlDocument)p;

            // Scalar Types.
            //
            if (p is String) return ToXmlDocument((String)p);

            // Other Types.
            //
            if (p is Stream) return ToXmlDocument((Stream)p);
            if (p is TextReader) return ToXmlDocument((TextReader)p);
            if (p is XmlReader) return ToXmlDocument((XmlReader)p);

            if (p is Char[]) return ToXmlDocument((Char[])p);
            if (p is Byte[]) return ToXmlDocument((Byte[])p);

            if (p is System.Xml.Linq.XDocument) return ToXmlDocument((System.Xml.Linq.XDocument)p);
            if (p is System.Xml.Linq.XElement) return ToXmlDocument((System.Xml.Linq.XElement)p);

            throw CreateInvalidCastException(p.GetType(), typeof(XmlDocument));
        }

        // Scalar Types.
        public static XDocument ToXDocument(String p)
        {
            if (p == null) return null;

            XDocument doc = XDocument.Parse(p);
            return doc;
        }

        public static XDocument ToXDocument(XmlDocument p)
        {
            if (p == null) return null;

            XDocument doc = XDocument.Parse(p.OuterXml);
            return doc;
        }

        public static XDocument ToXDocument(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XDocument) return (XDocument)p;

            // Scalar Types.
            //
            if (p is String) return ToXDocument((String)p);

            if (p is XmlDocument) return ToXDocument((XmlDocument)p);

            throw CreateInvalidCastException(p.GetType(), typeof(XDocument));
        }

        // Scalar Types.
        public static XElement ToXElement(String p)
        {
            if (p == null) return null;

            XElement element = XElement.Parse(p);
            return element;
        }

        public static XElement ToXElement(XmlDocument p)
        {
            if (p == null) return null;

            XElement element = XElement.Parse(p.OuterXml);
            return element;
        }

        public static XElement ToXElement(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XElement) return (XElement)p;

            // Scalar Types.
            //
            if (p is String) return ToXElement((String)p);

            if (p is XmlDocument) return ToXElement((XmlDocument)p);

            throw CreateInvalidCastException(p.GetType(), typeof(XElement));
        }

        // Scalar Types.
        // 
        public static XmlReader ToXmlReader(String p) { return p == null ? null : new XmlTextReader(new StringReader(p)); }

        // Other Types.
        // 
        public static XmlReader ToXmlReader(Stream p) { return p == null ? null : new XmlTextReader(p); }
        public static XmlReader ToXmlReader(TextReader p) { return p == null ? null : new XmlTextReader(p); }

        public static XmlReader ToXmlReader(XmlDocument p) { return p == null ? null : new XmlTextReader(new StringReader(p.InnerXml)); }

        public static XmlReader ToXmlReader(Char[] p) { return p == null ? null : new XmlTextReader(new StringReader(new string(p))); }
        public static XmlReader ToXmlReader(Byte[] p) { return p == null ? null : new XmlTextReader(new MemoryStream(p)); }

        public static XmlReader ToXmlReader(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XmlReader) return (XmlReader)p;

            // Scalar Types.
            //
            if (p is String) return ToXmlReader((String)p);

            // Other Types.
            //
            if (p is Stream) return ToXmlReader((Stream)p);
            if (p is TextReader) return ToXmlReader((TextReader)p);
            if (p is XmlDocument) return ToXmlReader((XmlDocument)p);

            if (p is Char[]) return ToXmlReader((Char[])p);
            if (p is Byte[]) return ToXmlReader((Byte[])p);

            throw CreateInvalidCastException(p.GetType(), typeof(XmlReader));
        }

        private static InvalidCastException CreateInvalidCastException(Type originalType, Type conversionType)
        {
            return new InvalidCastException(string.Format("Invalid cast from {0} to {1}", originalType.FullName, conversionType.FullName));
        }
    }
}
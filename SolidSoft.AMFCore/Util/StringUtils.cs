﻿using System;
using System.IO;
using System.Globalization;
using System.Text;

namespace SolidSoft.AMFCore.Util
{
	internal abstract class StringUtils
	{
        protected StringUtils() { }

		public const string CarriageReturnLineFeed = "\r\n";
		public const string Empty = "";
		public const char CarriageReturn = '\r';
		public const char LineFeed = '\n';
		public const char Tab = '\t';

		/// <summary>
		/// Determines whether the string contains white space.
		/// </summary>
		/// <param name="s">The string to test for white space.</param>
		/// <returns>
		/// 	<c>true</c> if the string contains white space; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsWhiteSpace(string s)
		{
			if (s == null)
				throw new ArgumentNullException("s");

			for (int i = 0; i < s.Length; i++)
			{
				if (char.IsWhiteSpace(s[i]))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether the string is all white space. Empty string will return false.
		/// </summary>
		/// <param name="s">The string to test whether it is all white space.</param>
		/// <returns>
		/// 	<c>true</c> if the string is all white space; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsWhiteSpace(string s)
		{
			if (s == null)
				throw new ArgumentNullException("s");

			if (s.Length == 0)
				return false;

			for (int i = 0; i < s.Length; i++)
			{
				if (!char.IsWhiteSpace(s[i]))
					return false;
			}

			return true;
		}

		/// <summary>
		/// Ensures the target string ends with the specified string.
		/// </summary>
		/// <param name="target">The target.</param>
		/// <param name="value">The value.</param>
		/// <returns>The target string with the value string at the end.</returns>
		public static string EnsureEndsWith(string target, string value)
		{
			if (target == null)
				throw new ArgumentNullException("target");

			if (value == null)
				throw new ArgumentNullException("value");

			if (target.Length >= value.Length)
			{
                if (string.Compare(target, target.Length - value.Length, value, 0, value.Length, StringComparison.OrdinalIgnoreCase) == 0)
					return target;

                string trimmedString = target.TrimEnd(null);

				if (string.Compare(trimmedString, trimmedString.Length - value.Length, value, 0, value.Length, StringComparison.OrdinalIgnoreCase) == 0)
					return target;
			}

			return target + value;
		}

		public static bool IsNullOrEmptyOrWhiteSpace(string s)
		{
			if (IsNullOrEmpty(s))
				return true;
			else if (IsWhiteSpace(s))
				return true;
			else
				return false;
		}

		public static bool IsNullOrEmpty(string s)
		{
			return (s == null || s == string.Empty);
		}

		/// <summary>
		/// Nulls an empty string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns>Null if the string was null, otherwise the string unchanged.</returns>
		public static string NullEmptyString(string s)
		{
			return IsNullOrEmpty(s) ? null : s;
		}

        public static string MaskNullString(string actual)
        {
            return actual == null ? string.Empty : actual;
        }

        public static string MaskNullString(string actual, string mask)
        {
            return actual == null ? mask : actual;
        }

        public static string MaskEmptyString(string actual, string emptyValue)
        {
            return MaskNullString(actual).Length == 0 ? emptyValue : actual;
        }

		public static string ReplaceNewLines(string s, string replacement)
		{
			StringReader sr = new StringReader(s);
			StringBuilder sb = new StringBuilder();

			bool first = true;

			string line;
			while ((line = sr.ReadLine()) != null)
			{
				if (first)
					first = false;
				else
					sb.Append(replacement);

				sb.Append(line);
			}

			return sb.ToString();
		}

		public static string Truncate(string s, int maximumLength)
		{
			return Truncate(s, maximumLength, "...");
		}

		public static string Truncate(string s, int maximumLength, string suffix)
		{
			if (suffix == null)
				throw new ArgumentNullException("suffix");

			if (maximumLength <= 0)
				throw new ArgumentException("Maximum length must be greater than zero.", "maximumLength");

			int subStringLength = maximumLength - suffix.Length;

			if (subStringLength <= 0)
				throw new ArgumentException("Length of suffix string is greater or equal to maximumLength");

			if (s != null && s.Length > maximumLength)
			{
				string truncatedString = s.Substring(0, subStringLength);
				// incase the last character is a space
				truncatedString = truncatedString.Trim();
				truncatedString += suffix;

				return truncatedString;
			}
			else
			{
				return s;
			}
		}

		public static StringWriter CreateStringWriter(int capacity)
		{
			StringBuilder sb = new StringBuilder(capacity);
			StringWriter sw = new StringWriter(sb);
			return sw;
		}

		public static int GetLength(string value)
		{
			if (value == null)
				return 0;
			else
				return value.Length;
		}

		public static string ToCharAsUnicode(char c)
		{
			using (StringWriter w = new StringWriter())
			{
				WriteCharAsUnicode(w, c);
				return w.ToString();
			}
		}

		public static void WriteCharAsUnicode(TextWriter writer, char c)
		{
			ValidationUtils.ArgumentNotNull(writer, "writer");

			char h1 = NumberUtils.IntToHex((c >> 12) & '\x000f');
			char h2 = NumberUtils.IntToHex((c >> 8) & '\x000f');
			char h3 = NumberUtils.IntToHex((c >> 4) & '\x000f');
			char h4 = NumberUtils.IntToHex(c & '\x000f');

			writer.Write('\\');
			writer.Write('u');
			writer.Write(h1);
			writer.Write(h2);
			writer.Write(h3);
			writer.Write(h4);
		}

	    /// <summary>
	    /// Checks if a <see cref="System.String"/> has text.
	    /// </summary>
	    /// <remarks>
	    /// <p>
	    /// More specifically, returns <see langword="true"/> if the string is
	    /// not <see langword="null"/>, it's <see cref="String.Length"/> is >
	    /// zero <c>(0)</c>, and it has at least one non-whitespace character.
	    /// </p>
	    /// </remarks>
	    /// <param name="target">
	    /// The string to check, may be <see langword="null"/>.
	    /// </param>
	    /// <returns>
	    /// <see langword="true"/> if the <paramref name="target"/> is not
	    /// <see langword="null"/>,
	    /// <see cref="String.Length"/> > zero <c>(0)</c>, and does not consist
	    /// solely of whitespace.
	    /// </returns>
	    /// <example>
	    /// <code language="C#">
	    /// StringUtils.HasText(null) = false
	    /// StringUtils.HasText("") = false
	    /// StringUtils.HasText(" ") = false
	    /// StringUtils.HasText("12345") = true
	    /// StringUtils.HasText(" 12345 ") = true
	    /// </code>
	    /// </example>
        public static bool HasText(string target)
        {
            if (target == null)
            {
                return false;
            }
            else
            {
                return HasLength(target.Trim());
            }
        }
        /// <summary>Checks if a string has length.</summary>
        /// <param name="target">
        /// The string to check, may be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the string has length and is not
        /// <see langword="null"/>.
        /// </returns>
        /// <example>
        /// <code lang="C#">
        /// StringUtils.HasLength(null) = false
        /// StringUtils.HasLength("") = false
        /// StringUtils.HasLength(" ") = true
        /// StringUtils.HasLength("Hello") = true
        /// </code>
        /// </example>
        public static bool HasLength(string target)
        {
            return (target != null && target.Length > 0);
        }

        public static bool CaselessEquals(string a, string b)
        {
            return string.Compare(a, b, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) == 0;
        }
	}
}
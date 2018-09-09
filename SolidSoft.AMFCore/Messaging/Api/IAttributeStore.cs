using System;
using System.Collections;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.Messaging.Api
{
	/// <summary>
	/// Base interface for all API objects with attributes.
	/// </summary>
    public interface IAttributeStore
	{
		/// <summary>
		/// Returns the attribute names.
		/// </summary>
		/// <returns>Collection of attribute names.</returns>
		ICollection GetAttributeNames();
		/// <summary>
		/// Sets an attribute on this object.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <param name="value">The attribute value.</param>
        /// <returns>true if the attribute value changed otherwise false</returns>
		bool SetAttribute(string name, object value);
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Dictionary of attributes.</param>
        void SetAttributes(IDictionary<string, object> values);
        /// <summary>
		/// Sets multiple attributes on this object.
		/// </summary>
		/// <param name="values">Attribute store.</param>
		void SetAttributes(IAttributeStore values);
		/// <summary>
		/// Returns the value for a given attribute.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <returns>The attribute value.</returns>
		object GetAttribute(string name);
		/// <summary>
		/// Returns the value for a given attribute and sets it if it doesn't exist.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <param name="defaultValue">Attribute's default value.</param>
		/// <returns>The attribute value.</returns>
		object GetAttribute(string name, object defaultValue);
		/// <summary>
		/// Checks whetner the object has an attribute.
		/// </summary>
		/// <param name="name">The attribute name.</param>
        /// <returns>true if a child scope exists, otherwise false.</returns>
		bool HasAttribute(string name);
		/// <summary>
		/// Removes an attribute.
		/// </summary>
		/// <param name="name">The attribute name.</param>
        /// <returns>true if the attribute was found and removed otherwise false.</returns>
		bool RemoveAttribute(string name);
		/// <summary>
		/// Removes all attributes.
		/// </summary>
		void RemoveAttributes();
        /// <summary>
        /// Gets whether the attribute store is empty;
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Gets or sets a value by name.
        /// </summary>
        /// <param name="name">The key name of the value.</param>
        /// <returns>The value with the specified name.</returns>
        Object this[string name] { get; set; }
        /// <summary>
        /// Gets the number of attributes in the collection.
        /// </summary>
        int AttributesCount { get; }
        /// <summary>
        /// Copies the collection of attribute values to a one-dimensional array, starting at the specified index in the array.
        /// </summary>
        /// <param name="array">The Array that receives the values.</param>
        /// <param name="index">The zero-based index in array from which copying starts.</param>
        void CopyTo(object[] array, int index);
	}
}
﻿using System;
using System.Collections;
using System.Collections.Generic;
using SolidSoft.AMFCore.Util;
using SolidSoft.AMFCore.Messaging.Api;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
    
	public class AttributeStore : DisposableBase, IAttributeStore
	{
        /// <summary>
        /// Attribute dictionary.
        /// </summary>
        protected Dictionary<string, object> _attributes = new Dictionary<string,object>();
        /// <summary>
        /// Initializes a new instance of the AttributeStore class.
        /// </summary>
        public AttributeStore()
		{
		}

		#region IAttributeStore Members

        /// <summary>
        /// Returns the attribute names.
        /// </summary>
        /// <returns>Collection of attribute names.</returns>
        public virtual ICollection GetAttributeNames()
		{
            lock (((ICollection)_attributes).SyncRoot)
            {
                return _attributes.Keys;
            }
        }
        /// <summary>
        /// Sets an attribute on this object.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The attribute value.</param>
        /// <returns>true if the attribute value changed otherwise false</returns>
		public virtual bool SetAttribute(string name, object value)
		{
			if(name == null )
				return false;
            lock (((ICollection)_attributes).SyncRoot)
            {
                // Update with new value
                object previous = null;
                if( _attributes.ContainsKey(name) )
                    previous = _attributes[name];
                _attributes[name] = value;
                return (previous == null || value == previous || !value.Equals(previous));
            }
        }
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Dictionary of attributes.</param>
        public virtual void SetAttributes(IDictionary<string, object> values)
        {
            lock (((ICollection)_attributes).SyncRoot)
            {
                foreach (KeyValuePair<string, object> entry in values)
                {
                    SetAttribute(entry.Key, entry.Value);
                }
            }
        }
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Attribute store.</param>
		public virtual void SetAttributes(IAttributeStore values)
		{
            lock (((ICollection)_attributes).SyncRoot)
            {
                foreach (string name in values.GetAttributeNames())
                {
                    object value = values.GetAttribute(name);
                    SetAttribute(name, value);
                }
            }
		}
        /// <summary>
        /// Returns the value for a given attribute.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>The attribute value.</returns>
		public virtual object GetAttribute(string name)
		{
            if (name == null)
                return null;
            lock (((ICollection)_attributes).SyncRoot)
            {
                if( _attributes.ContainsKey(name) )
                    return _attributes[name];
            }
            return null;
		}
        /// <summary>
        /// Returns the value for a given attribute and sets it if it doesn't exist.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="defaultValue">Attribute's default value.</param>
        /// <returns>The attribute value.</returns>
		public virtual object GetAttribute(string name, object defaultValue)
		{
            if (name == null)
                return null;
    	    if (defaultValue == null)
    		    throw new NullReferenceException("The default value may not be null.");
            lock (((ICollection)_attributes).SyncRoot)
            {
                if (_attributes.ContainsKey(name))
                    return _attributes[name];
                else
                {
                    _attributes[name] = defaultValue;
                    return null;
                }
            }
		}
        /// <summary>
        /// Checks whetner the object has an attribute.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>true if a child scope exists, otherwise false.</returns>
		public virtual bool HasAttribute(string name)
		{
            if (name == null)
                return false;
            lock (((ICollection)_attributes).SyncRoot)
            {
                return _attributes.ContainsKey(name);
            }
		}
        /// <summary>
        /// Removes an attribute.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>true if the attribute was found and removed otherwise false.</returns>
		public virtual bool RemoveAttribute(string name)
		{
            lock (((ICollection)_attributes).SyncRoot)
            {
                if (HasAttribute(name))
                {
                    _attributes.Remove(name);
                    return true;
                }
                return false;
            }
		}
        /// <summary>
        /// Removes all attributes.
        /// </summary>
		public virtual void RemoveAttributes()
		{
            lock (((ICollection)_attributes).SyncRoot)
            {
                _attributes.Clear();
            }
		}
        /// <summary>
        /// Gets whether the attribute store is empty;
        /// </summary>
        public bool IsEmpty 
        {
            get
            {
                lock (((ICollection)_attributes).SyncRoot)
                {
                    return _attributes.Count == 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value by name.
        /// </summary>
        /// <param name="name">The key name of the value.</param>
        /// <returns>The value with the specified name.</returns>
        public Object this[string name] 
        {
            get
            {
                return GetAttribute(name);
            }
            set
            {
                SetAttribute(name, value);
            }
        }
        /// <summary>
        /// Gets the number of attributes in the collection.
        /// </summary>
        public int AttributesCount 
        {
            get 
            {
                lock (((ICollection)_attributes).SyncRoot)
                {
                    return _attributes.Count;
                }
            }
        }
        /// <summary>
        /// Copies the collection of attribute values to a one-dimensional array, starting at the specified index in the array.
        /// </summary>
        /// <param name="array">The Array that receives the values.</param>
        /// <param name="index">The zero-based index in array from which copying starts.</param>
        public void CopyTo(object[] array, int index)
        {
            lock (((ICollection)_attributes).SyncRoot)
            {
                _attributes.Values.CopyTo(array, index);
            }
        }
		#endregion
    }
}
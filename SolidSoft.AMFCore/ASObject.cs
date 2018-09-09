using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// The ASObject class represents a Flash object.
	/// </summary>
    [Serializable]
    public class ASObject : Dictionary<string, Object>
    {
        private string _typeName;

        /// <summary>
        /// Initializes a new instance of the ASObject class.
        /// </summary>
        public ASObject()
        {
        }
        /// <summary>
        /// Initializes a new instance of the ASObject class.
        /// </summary>
        /// <param name="typeName">Typed object type name.</param>
        public ASObject(string typeName)
        {
            _typeName = typeName;
        }
        /// <summary>
        /// Initializes a new instance of the ASObject class by copying the elements from the specified dictionary to the new ASObject object.
        /// </summary>
        /// <param name="dictionary">The IDictionary object to copy to a new ASObject object.</param>
        public ASObject(IDictionary<string, object> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>
        /// Initializes a new instance of an ASObject object during deserialization.
        /// </summary>
        /// <param name="info">The information needed to serialize an object.</param>
        /// <param name="context">The source or destination for the serialization stream.</param>
        public ASObject(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets or sets the type name for a typed object.
        /// </summary>
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        /// <summary>
        /// Gets the Boolean value indicating whether the ASObject is typed.
        /// </summary>
        public bool IsTypedObject
        {
            get { return _typeName != null && _typeName != string.Empty; }
        }
    }
}
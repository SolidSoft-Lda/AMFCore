using System.Reflection;

namespace SolidSoft.AMFCore.AMF3
{
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
	public sealed class ClassDefinition
	{
        private string _className;
        private ClassMember[] _members;
        private bool _externalizable;
        private bool _dynamic;

        internal static ClassMember[] EmptyClassMembers = new ClassMember[0];

        internal ClassDefinition(string className, ClassMember[] members, bool externalizable, bool dynamic)
		{
			_className = className;
            _members = members;
			_externalizable = externalizable;
			_dynamic = dynamic;
		}

        /// <summary>
        /// Gets the class name.
        /// </summary>
		public string ClassName{ get{ return _className; } }
        /// <summary>
        /// Gets the class member count.
        /// </summary>
		public int MemberCount
        { 
            get
            {
                if (_members == null)
                    return 0;
                return _members.Length; 
            } 
        }
        /// <summary>
        /// Gets the array of class members.
        /// </summary>
        public ClassMember[] Members { get { return _members; } }
        /// <summary>
        /// Indicates whether the class is externalizable.
        /// </summary>
		public bool IsExternalizable{ get{ return _externalizable; } }
        /// <summary>
        /// Indicates whether the class is dynamic.
        /// </summary>
		public bool IsDynamic{ get{ return _dynamic; } }
        /// <summary>
        /// Indicates whether the class is typed (not anonymous).
        /// </summary>
		public bool IsTypedObject{ get{ return (_className != null && _className != string.Empty); } }
 	}

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class ClassMember
    {
        string _name;
        BindingFlags _bindingFlags;
        MemberTypes _memberType;

        internal ClassMember(string name, BindingFlags bindingFlags, MemberTypes memberType)
        {
            _name = name;
            _bindingFlags = bindingFlags;
            _memberType = memberType;
        }
        /// <summary>
        /// Gets the member name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Gets the member binding flags.
        /// </summary>
        public BindingFlags BindingFlags
        {
            get { return _bindingFlags; }
        }
        /// <summary>
        /// Gets the member type.
        /// </summary>
        public MemberTypes MemberType
        {
            get { return _memberType; }
        }
    }
}
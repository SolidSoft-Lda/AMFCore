using System.Collections.Generic;

namespace SolidSoft.AMFCore.Invocation
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class InvocationManager : IInvocationManager
	{
        Stack<object> _context;
        Dictionary<object, object> _properties;
        object		_result;

        public InvocationManager()
        {
            _context = new Stack<object>();
            _properties = new Dictionary<object, object>();
        }

        #region IInvocationManager Members

        public Stack<object> Context
        {
            get
            {
                return _context;
            }
        }

        public Dictionary<object, object> Properties
        {
            get
            {
                return _properties;
            }
        }

        public object Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        #endregion
	}
}
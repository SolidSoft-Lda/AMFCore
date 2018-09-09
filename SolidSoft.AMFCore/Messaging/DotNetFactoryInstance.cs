using System;
using System.Collections;
using System.Reflection;

namespace SolidSoft.AMFCore.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class DotNetFactoryInstance : FactoryInstance
	{
		Type _cachedType;
		object _applicationInstance;

        /// <summary>
        /// Initializes a new instance of the DotNetFactoryInstance class.
        /// </summary>
        /// <param name="flexFactory"></param>
        /// <param name="id"></param>
        /// <param name="properties"></param>
        public DotNetFactoryInstance(IFlexFactory flexFactory, string id, Hashtable properties)
            : base(flexFactory, id, properties)
		{
		}

		public object CreateInstance()
		{
			Type type = GetInstanceClass();
			object instance = null;
            if (type == null)
            {
                string msg = __Res.GetString(__Res.Type_InitError, this.Source);
                throw new MessageException(msg, new TypeLoadException(msg));
            }

			if (type.IsAbstract && type.IsSealed)
			{
				instance = type;
			}
			else
			{
				instance = Activator.CreateInstance(type, BindingFlags.CreateInstance|BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static, null, new object[]{}, null);
			}
			return instance;
		}

		public override string Source
		{
			get
			{
				return base.Source;
			}
			set
			{
				if(base.Source != value)
				{
					base.Source = value;
					_cachedType = null;
				}
			}
		}


		public override Type GetInstanceClass()
		{
			if( _cachedType == null )
				_cachedType = ObjectFactory.LocateInLac(this.Source);
			return _cachedType;
		}

		public object ApplicationInstance
		{
			get
			{
				if( _applicationInstance == null )
				{
					lock(typeof(DotNetFactoryInstance))
					{
						if( _applicationInstance == null )
							_applicationInstance = CreateInstance();
					}
				}
				return _applicationInstance;
			}
		}
	}
}
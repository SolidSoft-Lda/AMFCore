using System.Xml.Serialization;

namespace SolidSoft.AMFCore.Configuration
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum RemotingServiceAttributeConstraint
	{
		[XmlEnum(Name = "browse")]
        Browse = 1,
		[XmlEnum(Name = "access")]
        Access = 2
	}

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
	public enum TimezoneCompensation
	{
		[XmlEnum(Name = "none")]
		None = 0,
		[XmlEnum(Name = "auto")]
        Auto = 1
	}

	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class AMFConfiguration
	{
		static object _objLock = new object();
		static AMFConfiguration _instance;

		static AMFSettings		_amfSettings;

        private AMFConfiguration()
		{
		}

		static public AMFConfiguration Instance
		{
			get
			{
				if( _instance == null )
				{
					lock (_objLock) 
					{
						if( _instance == null )
						{
                            AMFConfiguration instance = new AMFConfiguration();
                            _amfSettings = new AMFSettings();

                            System.Threading.Thread.MemoryBarrier();
                            _instance = instance;
						}
					}
				}
				return _instance;
			}
		}

		public AMFSettings AMFSettings
		{ 
			get
			{
				return _amfSettings;
			}
        }
        internal ServiceCollection ServiceMap
		{ 
			get
			{
				if(_amfSettings != null )
					return _amfSettings.Services;
				return null;
			}
		}
        internal ClassMappingCollection ClassMappings
		{
			get
			{
				return _amfSettings.ClassMappings;
			}
        }

        internal string GetServiceName(string serviceLocation)
		{
			if( this.ServiceMap != null )
				return this.ServiceMap.GetServiceName(serviceLocation);
			return serviceLocation;
		}

		internal string GetServiceLocation(string serviceName)
		{
			if( this.ServiceMap != null )
				return this.ServiceMap.GetServiceLocation(serviceName);
			return serviceName;
		}

		internal string GetMethodName(string serviceLocation, string method)
		{
			if( this.ServiceMap != null )
				return this.ServiceMap.GetMethodName(serviceLocation, method);
			return method;
		}

        internal string GetMappedTypeName(string customClass)
		{
			if( this.ClassMappings != null )
				return this.ClassMappings.GetType(customClass);
			else
				return customClass;
		}

		internal string GetCustomClass(string type)
		{
			if( this.ClassMappings != null )
				return this.ClassMappings.GetCustomClass(type);
			else
				return type;
        }

        public NullableTypeCollection NullableValues
		{ 
			get
			{ 
				if(_amfSettings != null )
					return _amfSettings.Nullables;
				return null;
			}
		}

		public bool AcceptNullValueTypes
		{ 
			get
			{
				if(_amfSettings != null )
					return _amfSettings.AcceptNullValueTypes;
				return false;
			}
        }

        public RemotingServiceAttributeConstraint RemotingServiceAttributeConstraint
		{
			get
			{
				if(_amfSettings != null )
					return _amfSettings.RemotingServiceAttribute;
				return RemotingServiceAttributeConstraint.Access;
			}
		}

        public TimezoneCompensation TimezoneCompensation
        {
            get 
            {
				if(_amfSettings != null )
					return _amfSettings.TimezoneCompensation;
				return TimezoneCompensation.None;
            }
        }

        public HttpCompressSettings HttpCompressSettings
        {
            get
            {
				if(_amfSettings != null && _amfSettings.HttpCompressSettings != null )				
					return _amfSettings.HttpCompressSettings;
				else
					return HttpCompressSettings.Default;
            }
        }

        internal OptimizerSettings OptimizerSettings
		{
			get
			{
				if(_amfSettings != null )
					return _amfSettings.Optimizer;
				return null;
			}
        }
	}
}
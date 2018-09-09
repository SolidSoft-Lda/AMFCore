using System;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections.Generic;
using SolidSoft.AMFCore.Collections.Generic;

namespace SolidSoft.AMFCore.Configuration
{
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    [XmlType(TypeName = "settings")]
    public sealed class AMFSettings
    {
        private ClassMappingCollection _classMappings;
        private NullableTypeCollection _nullables;
        private ServiceCollection _services;
        private ImportNamespaceCollection _importedNamespaces;
        private HttpCompressSettings _httpCompressSettings;
        private CacheCollection _cache;
        private SchedulingServiceSettings _schedulingServiceSettings;
        private bool _acceptNullValueTypes;
        private RemotingServiceAttributeConstraint _remotingServiceAttributeConstraint;
        private TimezoneCompensation _timezoneCompensation;
        private OptimizerSettings _optimizerSettings;
        private RuntimeSettings _runtimeSettings;

        /// <summary>
        /// Initializes a new instance of the AMFCoreSettings class.
        /// </summary>
        public AMFSettings()
        {
            _timezoneCompensation = TimezoneCompensation.None;
            _remotingServiceAttributeConstraint = RemotingServiceAttributeConstraint.Access;
            _acceptNullValueTypes = false;
            _runtimeSettings = new RuntimeSettings();
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlArray("classMappings")]
        [XmlArrayItem("classMapping", typeof(ClassMapping))]
        public ClassMappingCollection ClassMappings
        {
            get
            {
                if (_classMappings == null)
                    _classMappings = new ClassMappingCollection();
                return _classMappings;
            }
            //set{ _classMappings = value; }
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlArray("nullable")]
        [XmlArrayItem("type", typeof(NullableType))]
        public NullableTypeCollection Nullables
        {
            get
            {
                if (_nullables == null)
                    _nullables = new NullableTypeCollection();
                return _nullables;
            }
            //set{ _nullables = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlArray("services")]
        [XmlArrayItem("service", typeof(ServiceConfiguration))]
        public ServiceCollection Services
        {
            get
            {
                if (_services == null)
                    _services = new ServiceCollection();
                return _services;
            }
            //set{ _services = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "httpCompress")]
        public HttpCompressSettings HttpCompressSettings
        {
            get { return _httpCompressSettings; }
            set { _httpCompressSettings = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlArray("cache")]
        [XmlArrayItem("cachedService", typeof(CachedService))]
        public CacheCollection Cache
        {
            get
            {
                if (_cache == null)
                    _cache = new CacheCollection();
                return _cache;
            }
            //set{ _cache = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlArray("importNamespaces")]
        [XmlArrayItem("add", typeof(ImportNamespace))]
        public ImportNamespaceCollection ImportNamespaces
        {
            get
            {
                if (_importedNamespaces == null)
                    _importedNamespaces = new ImportNamespaceCollection();
                return _importedNamespaces;
            }
            //set{ _importedNamespaces = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "schedulingService")]
        public SchedulingServiceSettings SchedulingService
        {
            get
            {
                if (_schedulingServiceSettings == null)
                    _schedulingServiceSettings = new SchedulingServiceSettings();
                return _schedulingServiceSettings;
            }
            set { _schedulingServiceSettings = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "timezoneCompensation")]
        public TimezoneCompensation TimezoneCompensation
        {
            get { return _timezoneCompensation; }
            set { _timezoneCompensation = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "acceptNullValueTypes")]
        public bool AcceptNullValueTypes
        {
            get { return _acceptNullValueTypes; }
            set { _acceptNullValueTypes = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "remotingServiceAttribute")]
        public RemotingServiceAttributeConstraint RemotingServiceAttribute
        {
            get { return _remotingServiceAttributeConstraint; }
            set { _remotingServiceAttributeConstraint = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "optimizer")]
        public OptimizerSettings Optimizer
        {
            get { return _optimizerSettings; }
            set { _optimizerSettings = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "runtime")]
        public RuntimeSettings Runtime
        {
            get { return _runtimeSettings; }
            set { _runtimeSettings = value; }
        }
    }

    #region ClassMappingCollection

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>

    public sealed class ClassMappingCollection : CollectionBase<ClassMapping>
    {
        private Dictionary<string, string> _typeToCustomClass = new Dictionary<string, string>();
        private Dictionary<string, string> _customClassToType = new Dictionary<string, string>();

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public ClassMappingCollection()
        {
            Add("SolidSoft.AMFCore.AMF3.ArrayCollection", "flex.messaging.io.ArrayCollection");
            Add("SolidSoft.AMFCore.AMF3.ByteArray", "flex.messaging.io.ByteArray");
            Add("SolidSoft.AMFCore.AMF3.ObjectProxy", "flex.messaging.io.ObjectProxy");

            //FDS
            Add("SolidSoft.AMFCore.Messaging.Messages.CommandMessage", "flex.messaging.messages.CommandMessage");
            Add("SolidSoft.AMFCore.Messaging.Messages.RemotingMessage", "flex.messaging.messages.RemotingMessage");
            Add("SolidSoft.AMFCore.Messaging.Messages.AsyncMessage", "flex.messaging.messages.AsyncMessage");
            Add("SolidSoft.AMFCore.Messaging.Messages.AcknowledgeMessage", "flex.messaging.messages.AcknowledgeMessage");
            Add("SolidSoft.AMFCore.Data.Messages.DataMessage", "flex.data.messages.DataMessage");
            Add("SolidSoft.AMFCore.Data.Messages.PagedMessage", "flex.data.messages.PagedMessage");
            Add("SolidSoft.AMFCore.Data.Messages.UpdateCollectionMessage", "flex.data.messages.UpdateCollectionMessage");
            Add("SolidSoft.AMFCore.Data.Messages.SequencedMessage", "flex.data.messages.SequencedMessage");
            Add("SolidSoft.AMFCore.Data.Messages.DataErrorMessage", "flex.data.messages.DataErrorMessage");
            Add("SolidSoft.AMFCore.Messaging.Messages.ErrorMessage", "flex.messaging.messages.ErrorMessage");
            Add("SolidSoft.AMFCore.Messaging.Messages.RemotingMessage", "flex.messaging.messages.RemotingMessage");
            Add("SolidSoft.AMFCore.Messaging.Messages.RPCMessage", "flex.messaging.messages.RPCMessage");

            Add("SolidSoft.AMFCore.Data.UpdateCollectionRange", "flex.data.UpdateCollectionRange");

            Add("SolidSoft.AMFCore.Messaging.Services.RemotingService", "flex.messaging.services.RemotingService");
            Add("SolidSoft.AMFCore.Messaging.Services.MessageService", "flex.messaging.services.MessageService");
            Add("SolidSoft.AMFCore.Data.DataService", "flex.data.DataService");
            Add("SolidSoft.AMFCore.Messaging.Endpoints.RtmpEndpoint", "flex.messaging.endpoints.RTMPEndpoint");
            Add("SolidSoft.AMFCore.Messaging.Endpoints.AMFEndpoint", "flex.messaging.endpoints.AMFEndpoint");

            Add("SolidSoft.AMFCore.Messaging.Services.Remoting.DotNetAdapter", "flex.messaging.services.remoting.adapters.JavaAdapter");
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="customClass"></param>
        public void Add(string type, string customClass)
        {
            ClassMapping classMapping = new ClassMapping();
            classMapping.Type = type;
            classMapping.CustomClass = customClass;
            this.Add(classMapping);
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void Add(ClassMapping value)
        {
            _typeToCustomClass[value.Type] = value.CustomClass;
            _customClassToType[value.CustomClass] = value.Type;
            base.Add(value);
        }
        public override void Insert(int index, ClassMapping value)
        {
            _typeToCustomClass[value.Type] = value.CustomClass;
            _customClassToType[value.CustomClass] = value.Type;
            base.Insert(index, value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        public override bool Remove(ClassMapping value)
        {
            _typeToCustomClass.Remove(value.Type);
            _customClassToType.Remove(value.CustomClass);
            return base.Remove(value);
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetCustomClass(string type)
        {
            if (_typeToCustomClass.ContainsKey(type))
                return _typeToCustomClass[type] as string;
            else
                return type;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="customClass"></param>
        /// <returns></returns>
        public string GetType(string customClass)
        {
            if (customClass == null)
                return null;
            if (_customClassToType.ContainsKey(customClass))
                return _customClassToType[customClass] as string;
            else
                return customClass;
        }
    }

    #endregion ClassMappingCollection

    #region ClassMapping

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    [XmlType(TypeName = "classMapping")]
    public sealed class ClassMapping
    {
        private string _type;
        private string _customClass;
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public ClassMapping()
        {
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(DataType = "string", ElementName = "type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(DataType = "string", ElementName = "customClass")]
        public string CustomClass
        {
            get { return _customClass; }
            set { _customClass = value; }
        }
    }

    #endregion ClassMapping

    #region ServiceCollection
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class ServiceCollection : CollectionBase<ServiceConfiguration>
    {
        private Dictionary<string, ServiceConfiguration> _serviceNames = new Dictionary<string, ServiceConfiguration>(5);
        private Dictionary<string, ServiceConfiguration> _serviceLocations = new Dictionary<string, ServiceConfiguration>(5);

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public ServiceCollection()
        {
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void Add(ServiceConfiguration value)
        {
            _serviceNames[value.Name] = value;
            _serviceLocations[value.ServiceLocation] = value;
            base.Add(value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public override void Insert(int index, ServiceConfiguration value)
        {
            _serviceNames[value.Name] = value;
            _serviceLocations[value.ServiceLocation] = value;
            base.Insert(index, value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        public override bool Remove(ServiceConfiguration value)
        {
            _serviceNames.Remove(value.Name);
            _serviceLocations.Remove(value.ServiceLocation);
            return base.Remove(value);
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public bool Contains(string serviceName)
        {
            return _serviceNames.ContainsKey(serviceName);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetServiceLocation(string serviceName)
        {
            if (_serviceNames.ContainsKey(serviceName))
                return (_serviceNames[serviceName] as ServiceConfiguration).ServiceLocation;
            else
                return serviceName;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="serviceLocation"></param>
        /// <returns></returns>
        public string GetServiceName(string serviceLocation)
        {
            if (_serviceLocations.ContainsKey(serviceLocation))
                return (_serviceLocations[serviceLocation] as ServiceConfiguration).Name;
            else
                return serviceLocation;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetMethod(string serviceName, string name)
        {
            ServiceConfiguration serviceConfiguration = null;
            if (_serviceNames.ContainsKey(serviceName))
                serviceConfiguration = _serviceNames[serviceName] as ServiceConfiguration;
            if (serviceConfiguration != null)
                return serviceConfiguration.Methods.GetMethod(name);
            return name;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="serviceLocation"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public string GetMethodName(string serviceLocation, string method)
        {
            ServiceConfiguration serviceConfiguration = null;
            if (_serviceLocations.ContainsKey(serviceLocation))
                serviceConfiguration = _serviceLocations[serviceLocation] as ServiceConfiguration;
            if (serviceConfiguration != null)
                return serviceConfiguration.Methods.GetMethodName(method);
            return method;
        }
    }
    #endregion ServiceCollection

    #region ServiceConfiguration
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    [XmlType(TypeName = "service")]
    public sealed class ServiceConfiguration
    {
        private string _name;
        private string _serviceLocation;
        private RemoteMethodCollection _remoteMethodCollection;
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public ServiceConfiguration()
        {
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(DataType = "string", ElementName = "name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(DataType = "string", ElementName = "service-location")]
        public string ServiceLocation
        {
            get { return _serviceLocation; }
            set { _serviceLocation = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlArray("methods")]
        [XmlArrayItem("remote-method", typeof(RemoteMethod))]
        public RemoteMethodCollection Methods
        {
            get
            {
                if (_remoteMethodCollection == null)
                    _remoteMethodCollection = new RemoteMethodCollection();
                return _remoteMethodCollection;
            }
            //set{ _remoteMethodCollection = value; }
        }
    }
    #endregion ServiceConfiguration

    #region RemoteMethodCollection
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RemoteMethodCollection : CollectionBase<RemoteMethod>
    {
        Dictionary<string, string> _methods = new Dictionary<string, string>(3);
        Dictionary<string, string> _methodsNames = new Dictionary<string, string>(3);

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public RemoteMethodCollection()
        {
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void Add(RemoteMethod value)
        {
            _methods[value.Name] = value.Method;
            _methodsNames[value.Method] = value.Name;
            base.Add(value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public override void Insert(int index, RemoteMethod value)
        {
            _methods[value.Name] = value.Method;
            _methodsNames[value.Method] = value.Name;
            base.Insert(index, value);
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetMethod(string name)
        {
            if (_methods.ContainsKey(name))
                return _methods[name] as string;
            return name;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public string GetMethodName(string method)
        {
            if (_methodsNames.ContainsKey(method))
                return _methodsNames[method] as string;
            return method;
        }
    }
    #endregion RemoteMethodCollection

    #region RemoteMethod
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RemoteMethod
    {
        private string _name;
        private string _method;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(DataType = "string", ElementName = "name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(DataType = "string", ElementName = "method")]
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }
    }
    #endregion RemoteMethod

    #region NullableTypeCollection

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class NullableTypeCollection : CollectionBase<NullableType>
    {
        Dictionary<string, NullableType> _nullableDictionary = new Dictionary<string, NullableType>(5);

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public NullableTypeCollection()
        {
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void Add(NullableType value)
        {
            _nullableDictionary[value.TypeName] = value;
            base.Add(value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public override void Insert(int index, NullableType value)
        {
            _nullableDictionary[value.TypeName] = value;
            base.Insert(index, value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        public override bool Remove(NullableType value)
        {
            _nullableDictionary.Remove(value.TypeName);
            return base.Remove(value);
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ContainsKey(Type type)
        {
            return _nullableDictionary.ContainsKey(type.FullName);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object this[Type type]
        {
            get
            {
                if (_nullableDictionary.ContainsKey(type.FullName))
                    return (_nullableDictionary[type.FullName] as NullableType).NullValue;
                return null;
            }
        }
    }

    #endregion NullableTypeCollection

    #region NullableType

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    [XmlType(TypeName = "type")]
    public sealed class NullableType
    {
        private string _typeName;
        private string _value;
        private object _nullValue;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "name")]
        public string TypeName
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                Init();
            }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "value")]
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Init();
            }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlIgnore]
        public object NullValue
        {
            get { return _nullValue; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        private void Init()
        {
            if (_typeName == null || _value == null)
                return;

            Type type = Type.GetType(_typeName);
            // Check if this is a static field of the type
            FieldInfo fi = type.GetField(_value, BindingFlags.Public | BindingFlags.Static);
            if (fi != null)
                _nullValue = fi.GetValue(null);
            else
                _nullValue = System.Convert.ChangeType(_value, type, null);
        }
    }

    #endregion NullableType

    #region CacheCollection
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class CacheCollection : CollectionBase<CachedService>
    {
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public CacheCollection()
        {
        }
    }
    #endregion CacheCollection

    #region CachedService
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    [XmlType(TypeName = "cachedService")]
    public sealed class CachedService
    {
        private int _timeout;
        private bool _slidingExpiration;
        private string _type;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public CachedService()
        {
            _timeout = 30;
            _slidingExpiration = false;
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "timeout")]
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "slidingExpiration")]
        public bool SlidingExpiration
        {
            get { return _slidingExpiration; }
            set { _slidingExpiration = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
    #endregion CachedService

    #region ImportNamespaceCollection
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class ImportNamespaceCollection : CollectionBase<ImportNamespace>
    {
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public ImportNamespaceCollection()
        {
        }
    }
    #endregion ImportNamespaceCollection

    #region ImportNamespace
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class ImportNamespace
    {
        private string _namespace;
        private string _assembly;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public ImportNamespace()
        {
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "namespace")]
        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "assembly")]
        public string Assembly
        {
            get { return _assembly; }
            set { _assembly = value; }
        }
    }
    #endregion ImportNamespace

    #region StreamableFileFactorySettings
    /// <summary>
    /// StreamableFileFactory settings.
    /// </summary>
    public class StreamableFileFactorySettings
    {
        private string _type;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
    #endregion StreamableFileFactorySettings

    #region BWControlServiceSettings

    /// <summary>
    /// BWControlServiceSettings settings.
    /// </summary>
    public class BWControlServiceSettings
    {
        private string _type;
        private int _interval;
        private int _defaultCapacity;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public BWControlServiceSettings()
        {
            _interval = 100;
            _defaultCapacity = 104857600;
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "interval")]
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "defaultCapacity")]
        public int DefaultCapacity
        {
            get { return _defaultCapacity; }
            set { _defaultCapacity = value; }
        }
    }
    #endregion BWControlServiceSettings

    #region SchedulingServiceSettings
    /// <summary>
    /// SchedulingServiceSettings settings.
    /// </summary>
    public class SchedulingServiceSettings
    {
        private string _type;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
    #endregion SchedulingServiceSettings

    #region PlaylistSubscriberStreamSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class PlaylistSubscriberStreamSettings
    {
        private int _underrunTrigger;
        private int _bufferCheckInterval;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public PlaylistSubscriberStreamSettings()
        {
            _underrunTrigger = 5000;
            _bufferCheckInterval = 60000;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "underrunTrigger")]
        public int UnderrunTrigger
        {
            get { return _underrunTrigger; }
            set { _underrunTrigger = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "bufferCheckInterval")]
        public int BufferCheckInterval
        {
            get { return _bufferCheckInterval; }
            set { _bufferCheckInterval = value; }
        }
    }
    #endregion PlaylistSubscriberStreamSettings

    #region HttpCompressSettings

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class HttpCompressSettings
    {
        private MimeTypeEntryCollection _excludedTypes;
        private PathEntryCollection _excludedPaths;
        int _threshold;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public HttpCompressSettings()
        {
            _excludedTypes = new MimeTypeEntryCollection();
            _excludedPaths = new PathEntryCollection();
            _threshold = 20480;
        }

        /// <summary>
        /// The default settings.  Deflate + normal.
        /// </summary>
        public static HttpCompressSettings Default
        {
            get { return new HttpCompressSettings(); }
        }

        /// <summary>
        /// Compress responses larger then threshold bytes.
        /// </summary>
        [XmlElement(ElementName = "threshold")]
        public int Threshold
        {
            get { return _threshold; }
            set { _threshold = value; }
        }

        [XmlArray("excludedMimeTypes")]
        [XmlArrayItem("add", typeof(MimeTypeEntry))]
        //[XmlArrayItem("remove",typeof(MimeTypeEntry))]
        public MimeTypeEntryCollection ExcludedMimeTypes
        {
            get
            {
                if (_excludedTypes == null)
                    _excludedTypes = new MimeTypeEntryCollection();
                return _excludedTypes;
            }
            //set { _excludedTypes = value; }
        }

        [XmlArray("excludedPaths")]
        [XmlArrayItem("add", typeof(PathEntry))]
        //[XmlArrayItem("remove",typeof(PathEntry))]
        public PathEntryCollection ExcludedPaths
        {
            get
            {
                if (_excludedPaths == null)
                    _excludedPaths = new PathEntryCollection();
                return _excludedPaths;
            }
            //set { _excludedPaths = value; }
        }

        /// <summary>
        /// Checks a given mime type to determine if it has been excluded from compression
        /// </summary>
        /// <param name="mimetype">The MimeType to check.  Can include wildcards like image/* or */xml.</param>
        /// <returns>true if the mime type passed in is excluded from compression, false otherwise</returns>
        public bool IsExcludedMimeType(string mimetype)
        {
            return _excludedTypes.Contains(mimetype.ToLower());
        }

        /// <summary>
        /// Looks for a given path in the list of paths excluded from compression.
        /// </summary>
        /// <param name="relUrl">the relative url to check</param>
        /// <returns>true if excluded, false if not</returns>
        public bool IsExcludedPath(string relUrl)
        {
            return _excludedPaths.Contains(relUrl.ToLower());
        }
    }
    #endregion HttpCompressSettings

    #region MimeTypeEntryCollection

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class MimeTypeEntryCollection : CollectionBase<MimeTypeEntry>
    {
        Dictionary<string, MimeTypeEntry> _excludedTypes = new Dictionary<string, MimeTypeEntry>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public MimeTypeEntryCollection()
        {
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void Add(MimeTypeEntry value)
        {
            _excludedTypes.Add(value.Type, value);
            base.Add(value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public override void Insert(int index, MimeTypeEntry value)
        {
            _excludedTypes.Add(value.Type, value);
            base.Insert(index, value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        public override bool Remove(MimeTypeEntry value)
        {
            _excludedTypes.Remove(value.Type);
            return base.Remove(value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Contains(string type)
        {
            return _excludedTypes.ContainsKey(type);
        }
    }
    #endregion MimeTypeEntryCollection

    #region PathEntryCollection

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class PathEntryCollection : CollectionBase<PathEntry>
    {
        Dictionary<string, PathEntry> _excludedPaths = new Dictionary<string, PathEntry>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public PathEntryCollection()
        {
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void Add(PathEntry value)
        {
            _excludedPaths.Add(value.Path, value);
            base.Add(value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public override void Insert(int index, PathEntry value)
        {
            _excludedPaths.Add(value.Path, value);
            base.Insert(index, value);
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="value"></param>
        public override bool Remove(PathEntry value)
        {
            _excludedPaths.Remove(value.Path);
            return base.Remove(value);
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Contains(string path)
        {
            return _excludedPaths.ContainsKey(path);
        }
    }
    #endregion PathEntryCollection

    #region MimeTypeEntry

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class MimeTypeEntry
    {
        private string _type;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
    #endregion MimeTypeEntry

    #region PathEntry
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class PathEntry
    {
        private string _path;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(AttributeName = "path")]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
    #endregion PathEntry

    #region RtmpServerSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RtmpServerSettings
    {
        private ThreadPoolSettings _threadPoolSettings;
        private RtmpConnectionSettings _rtmpConnectionSettings;
        private RtmptConnectionSettings _rtmptConnectionSettings;
        private RtmpTransportSettings _rtmpTransportSettings;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public RtmpServerSettings()
        {
            _threadPoolSettings = new ThreadPoolSettings();
            _rtmpConnectionSettings = new RtmpConnectionSettings();
            _rtmptConnectionSettings = new RtmptConnectionSettings();
            _rtmpTransportSettings = new RtmpTransportSettings();
        }

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "threadpool")]
        public ThreadPoolSettings ThreadPoolSettings
        {
            get { return _threadPoolSettings; }
            set { _threadPoolSettings = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "rtmpConnection")]
        public RtmpConnectionSettings RtmpConnectionSettings
        {
            get { return _rtmpConnectionSettings; }
            set { _rtmpConnectionSettings = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "rtmptConnection")]
        public RtmptConnectionSettings RtmptConnectionSettings
        {
            get { return _rtmptConnectionSettings; }
            set { _rtmptConnectionSettings = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlElement(ElementName = "rtmpTransport")]
        public RtmpTransportSettings RtmpTransportSettings
        {
            get { return _rtmpTransportSettings; }
            set { _rtmpTransportSettings = value; }
        }
    }
    #endregion RtmpServerSettings

    #region ThreadPoolSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class ThreadPoolSettings
    {
        private int _minWorkerThreads;
        private int _maxWorkerThreads;
        private int _idleTimeout;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "minWorkerThreads")]
        public int MinWorkerThreads
        {
            get { return _minWorkerThreads; }
            set { _minWorkerThreads = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "maxWorkerThreads")]
        public int MaxWorkerThreads
        {
            get { return _maxWorkerThreads; }
            set { _maxWorkerThreads = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "idleTimeout")]
        public int IdleTimeout
        {
            get { return _idleTimeout; }
            set { _idleTimeout = value; }
        }
    }
    #endregion ThreadPoolSettings

    #region RtmpConnectionSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RtmpConnectionSettings
    {
        private int _pingInterval;
        private int _maxInactivity;
        private int _maxHandshakeTimeout;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public RtmpConnectionSettings()
        {
            _pingInterval = 5000;
            _maxInactivity = 60000;
            _maxHandshakeTimeout = 5000;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "pingInterval")]
        public int PingInterval
        {
            get { return _pingInterval; }
            set { _pingInterval = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "maxInactivity")]
        public int MaxInactivity
        {
            get { return _maxInactivity; }
            set { _maxInactivity = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "maxHandshakeTimeout")]
        public int MaxHandshakeTimeout
        {
            get { return _maxHandshakeTimeout; }
            set { _maxHandshakeTimeout = value; }
        }
    }
    #endregion RtmpConnectionSettings

    #region RtmptConnectionSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RtmptConnectionSettings
    {
        private int _pingInterval;
        private int _maxInactivity;
        private int _maxHandshakeTimeout;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public RtmptConnectionSettings()
        {
            _pingInterval = 5000;
            _maxInactivity = 60000;
            _maxHandshakeTimeout = 5000;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "pingInterval")]
        public int PingInterval
        {
            get { return _pingInterval; }
            set { _pingInterval = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "maxInactivity")]
        public int MaxInactivity
        {
            get { return _maxInactivity; }
            set { _maxInactivity = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "maxHandshakeTimeout")]
        public int MaxHandshakeTimeout
        {
            get { return _maxHandshakeTimeout; }
            set { _maxHandshakeTimeout = value; }
        }
    }
    #endregion RtmptConnectionSettings

    #region RtmpTransportSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RtmpTransportSettings
    {
        private int _receiveBufferSize;
        private int _sendBufferSize;
        private bool _tcpNoDelay;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public RtmpTransportSettings()
        {
            _receiveBufferSize = 4096;
            _sendBufferSize = 4096;
            _tcpNoDelay = true;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "receiveBufferSize")]
        public int ReceiveBufferSize
        {
            get { return _receiveBufferSize; }
            set { _receiveBufferSize = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "sendBufferSize")]
        public int SendBufferSize
        {
            get { return _sendBufferSize; }
            set { _sendBufferSize = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "tcpNoDelay")]
        public bool TcpNoDelay
        {
            get { return _tcpNoDelay; }
            set { _tcpNoDelay = value; }
        }
    }

    #endregion RtmpTransportSettings

    #region OptimizerSettings

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class OptimizerSettings
    {
        private string _provider;
        private bool _debug;
        private bool _typeCheck;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public OptimizerSettings()
        {
            _provider = "codedom";
            _debug = true;
            _typeCheck = false;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "provider")]
        public string Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "debug")]
        public bool Debug
        {
            get { return _debug; }
            set { _debug = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "typeCheck")]
        public bool TypeCheck
        {
            get { return _typeCheck; }
            set { _typeCheck = value; }
        }
    }

    #endregion OptimizerSettings

    #region RuntimeSettings

    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class RuntimeSettings
    {
        private bool _asyncHandler;
        private int _minWorkerThreads;
        private int _maxWorkerThreads;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public RuntimeSettings()
        {
            _asyncHandler = false;
            _minWorkerThreads = 0;
            _maxWorkerThreads = 0;
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "minWorkerThreads")]
        public int MinWorkerThreads
        {
            get { return _minWorkerThreads; }
            set { _minWorkerThreads = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "int", AttributeName = "maxWorkerThreads")]
        public int MaxWorkerThreads
        {
            get { return _maxWorkerThreads; }
            set { _maxWorkerThreads = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "asyncHandler")]
        public bool AsyncHandler
        {
            get { return _asyncHandler; }
            set { _asyncHandler = value; }
        }
    }

    #endregion RuntimeSettings

    #region PolicyServerSettings
    /// <summary>
    /// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class PolicyServerSettings
    {
        private bool _enable;
        private string _policyFile;

        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public PolicyServerSettings()
        {
            _enable = false;
            _policyFile = "clientaccesspolicy.xml";
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "enable")]
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }
        /// <summary>
        /// This member supports the AMFCore infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "policyFile")]
        public string PolicyFile
        {
            get { return _policyFile; }
            set { _policyFile = value; }
        }
    }
    #endregion PolicyServerSettings
}
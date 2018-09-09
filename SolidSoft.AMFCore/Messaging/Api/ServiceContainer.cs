using System;
using System.Collections;
using SolidSoft.AMFCore.Util;
using System.Collections.Generic;

namespace SolidSoft.AMFCore.Messaging.Api
{
    public class ServiceContainer : IServiceContainer
    {
        private Dictionary<Type, object> _services = new Dictionary<Type, object>();
        private IServiceProvider _parentProvider;

        public ServiceContainer():this(null)
        {
        }

        public ServiceContainer(IServiceProvider parentProvider)
        {
            _parentProvider = parentProvider;
        }

        private IServiceContainer Container
        {
            get
            {
                IServiceContainer service = null;
                if (_parentProvider != null)
                {
                    service = (IServiceContainer)_parentProvider.GetService(typeof(IServiceContainer));
                }
                return service;
            }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access. 
        /// </summary>
        public object SyncRoot 
        { 
            get 
            {
                return ((ICollection)_services).SyncRoot;
            } 
        }

        #region IServiceContainer Members

        public void AddService(Type serviceType, object service)
        {
            AddService(serviceType, service, false);
        }

        public void AddService(Type serviceType, object service, bool promote)
        {
            ValidationUtils.ArgumentNotNull(serviceType, "serviceType");
            ValidationUtils.ArgumentNotNull(service, "service");
            lock (this.SyncRoot)
            {
                if (promote)
                {
                    IServiceContainer container = this.Container;
                    if (container != null)
                    {
                        container.AddService(serviceType, service, promote);
                        return;
                    }
                }
                if (_services.ContainsKey(serviceType))
                    throw new ArgumentException(string.Format("Service {0} already exists", serviceType.FullName));
                _services[serviceType] = service;
            }
        }

        public void RemoveService(Type serviceType)
        {
            RemoveService(serviceType, false);
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            ValidationUtils.ArgumentNotNull(serviceType, "serviceType");
            lock (this.SyncRoot)
            {
                if (promote)
                {
                    IServiceContainer container = this.Container;
                    if (container != null)
                    {
                        container.RemoveService(serviceType, promote);
                        return;
                    }
                }
                if (_services.ContainsKey(serviceType))
                {
                    IService service = _services[serviceType] as IService;
                    if (service != null)
                        service.Shutdown();
                }
                _services.Remove(serviceType);
            }
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            ValidationUtils.ArgumentNotNull(serviceType, "serviceType");
            object service = null;
            lock (this.SyncRoot)
            {
                if( _services.ContainsKey(serviceType) )
                    service = _services[serviceType];
                if (service == null && _parentProvider != null)
                {
                    service = _parentProvider.GetService(serviceType);
                }
            }
            return service;
        }

        #endregion

        internal void Shutdown()
        {
            lock (this.SyncRoot)
            {
                foreach (object serviceInstance in _services.Values)
                {
                    IService service = serviceInstance as IService;
                    if (service != null)
                        service.Shutdown();
                }
                _services.Clear();
                _services = null;
                _parentProvider = null;
            }
        }
    }
}
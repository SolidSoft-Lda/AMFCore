using System;

namespace SolidSoft.AMFCore.Messaging.Api
{
    /// <summary>
    /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type serviceType or a null reference (Nothing in Visual Basic) if there is no service object of type serviceType.</returns>
        object GetService(Type serviceType);
    }

    /// <summary>
    /// Provides a container for services.
    /// </summary>
    public interface IServiceContainer : IServiceProvider
    {
        /// <summary>
        /// Adds the specified service to the scope.
        /// </summary>
        /// <param name="serviceType">The type of service to add.</param>
        /// <param name="service">An instance of the service type to add.</param>
        void AddService(Type serviceType, object service);
        /// <summary>
        /// Adds the specified service to the scope.
        /// </summary>
        /// <param name="serviceType">The type of service to add.</param>
        /// <param name="service">An instance of the service type to add.</param>
        /// <param name="promote">true to promote this request to any parent service containers; otherwise, false.</param>
        void AddService(Type serviceType, object service, bool promote);
        /// <summary>
        /// Removes the specified service type from the service container.
        /// </summary>
        /// <param name="serviceType">The type of service to remove.</param>
        void RemoveService(Type serviceType);
        /// <summary>
        /// Removes the specified service type from the service container.
        /// </summary>
        /// <param name="serviceType">The type of service to remove.</param>
        /// <param name="promote">true to promote this request to any parent service containers; otherwise, false.</param>
        void RemoveService(Type serviceType, bool promote);
    }
}
namespace SolidSoft.AMFCore.Messaging.Api
{
    /// <summary>
    /// Base interface for all services.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Start service.
        /// </summary>
        /// <param name="configuration">Application configuration.</param>
        void Start();
        /// <summary>
        /// Shutdown service.
        /// </summary>
        void Shutdown();
    }
}
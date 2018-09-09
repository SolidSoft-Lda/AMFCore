using SolidSoft.AMFCore.Configuration;

namespace SolidSoft.AMFCore.Messaging.Config
{
    /// <summary>
    /// Represents a configuration class that contains information about the services-config.xml file.
	/// </summary>
	public sealed class ServiceConfigSettings
	{
        ChannelSettingsCollection _channelSettingsCollection;
        FactorySettingsCollection _factorySettingsCollection;
        ServiceSettingsCollection _serviceSettingsCollection;
        FlexClientSettings _flexClientSettings;

        internal ServiceConfigSettings()
		{
            _channelSettingsCollection = new ChannelSettingsCollection();
            _factorySettingsCollection = new FactorySettingsCollection();
            _serviceSettingsCollection = new ServiceSettingsCollection();
		}

        /// <summary>
        /// Gets flex client settings.
        /// </summary>
        public FlexClientSettings FlexClientSettings
        {
            get { return _flexClientSettings; }
        }
        /// <summary>
        /// Gets channel definitions.
        /// </summary>
        public ChannelSettingsCollection ChannelsSettings
		{
            get { return _channelSettingsCollection; }
		}
        /// <summary>
        /// Gets factory definitions.
        /// </summary>
        public FactorySettingsCollection FactoriesSettings
		{
            get { return _factorySettingsCollection; }
		}
        /// <summary>
        /// Gets service settings.
        /// </summary>
        public ServiceSettingsCollection ServiceSettings
		{
            get { return _serviceSettingsCollection; }
		}

        /// <summary>
        /// Loads a services-config.xml file.
        /// </summary>
        /// <param name="configPath">Path to the file.</param>
        /// <param name="configFileName">Service configuration file name.</param>
        /// <returns>A ServiceConfigSettings instance loaded from the specified file.</returns>
        public static ServiceConfigSettings Load()
        {
            ServiceConfigSettings serviceConfigSettings = new ServiceConfigSettings();

            //Create a default amf channel
            ChannelSettings channelSettings = new ChannelSettings("my-amf", "flex.messaging.endpoints.AMFEndpoint", @"http://{server.name}:{server.port}/{context.root}/gateway");
            serviceConfigSettings.ChannelsSettings.Add(channelSettings);

            ServiceSettings serviceSettings = new ServiceSettings(serviceConfigSettings, SolidSoft.AMFCore.Messaging.Services.RemotingService.RemotingServiceId, typeof(SolidSoft.AMFCore.Messaging.Services.RemotingService).FullName);
            string messageType = "flex.messaging.messages.RemotingMessage";
            string typeName = AMFConfiguration.Instance.ClassMappings.GetType(messageType);
            serviceSettings.SupportedMessageTypes[messageType] = typeName;
            serviceConfigSettings.ServiceSettings.Add(serviceSettings);

            AdapterSettings adapterSettings = new AdapterSettings("dotnet", typeof(SolidSoft.AMFCore.Remoting.RemotingAdapter).FullName, true);
            serviceSettings.DefaultAdapter = adapterSettings;

            DestinationSettings destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.AMFDestination, adapterSettings, "*");
            serviceSettings.DestinationSettings.Add(destinationSettings);

            serviceConfigSettings._flexClientSettings = new FlexClientSettings();

            return serviceConfigSettings;
        }
	}
}
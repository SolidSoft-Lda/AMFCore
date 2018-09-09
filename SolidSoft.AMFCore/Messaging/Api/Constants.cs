namespace SolidSoft.AMFCore.Messaging.Api
{
    public class Constants
    {
        public const byte TypeUnknown = 0;
        /// <summary>
        /// RTMP chunk size constant.
        /// </summary>
        public const byte TypeChunkSize = 1;
        /// <summary>
        /// Send every x bytes read by both sides.
        /// </summary>
        public const byte TypeBytesRead = 3;
        /// <summary>
        /// Ping is a stream control message, has subtypes.
        /// </summary>
        public const byte TypePing = 4;
        /// <summary>
        /// Server (downstream) bandwidth marker.
        /// </summary>
        public const byte TypeServerBandwidth = 5;
        /// <summary>
        /// Client (upstream) bandwidth marker.
        /// </summary>
        public const byte TypeClientBandwidth = 6;
        /// <summary>
        /// AMF3 stream send
        /// </summary>
        public const byte TypeFlexStreamEnd = 0x0F;
        /// <summary>
        /// AMF3 shared object.
        /// </summary>
        public const byte TypeFlexSharedObject = 0x10;
        /// <summary>
        /// AMF3 message.
        /// </summary>
        public const byte TypeFlexInvoke = 0x11;
        /// <summary>
        /// Notification is invocation without response.
        /// </summary>
        public const byte TypeNotify = 0x12;
        /// <summary>
        /// Stream metadata.
        /// </summary>
        public const byte TypeStreamMetadata = 0x12;
        /// <summary>
        /// Shared Object marker.
        /// </summary>
        public const byte TypeSharedObject = 0x13;
        /// <summary>
        /// Invoke operation (remoting call but also used for streaming) marker.
        /// </summary>
        public const byte TypeInvoke = 0x14;

        /// <summary>
        /// Prefix for attribute names that should not be made persistent. 
        /// </summary>
        public const string TransientPrefix = "_transient";

        public const string SharedObjectService = "SharedObjectService";
        public const string SharedObjectSecurityService = "SharedObjectSecurityService";
        public const string ProviderService = "ProviderService";
        public const string StreamSecurityService = "StreamSecurityService";
        public const string StreamableFileFactory = "StreamableFileFactory";
        public const string StreamFilenameGenerator = "StreamFilenameGenerator";

	    public const int AudioChannel = 0;
	    public const int VideoChannel = 1;
	    public const int DataChannel = 2;
	    public const int OverallChannel = 3;
        public const int MaxChannelConfigCount = 4;

        public const string BroadcastScopeType = "bs";
        public const string BroadcastScopeStreamAttribute = TransientPrefix + "_publishing_stream";

        public const string StreamServiceType = "streamService";

        public const string StreamAttribute = TransientPrefix + "_publishing_stream";

	    public const string ClientStreamModeRead = "read";
	    public const string ClientStreamModeRecord = "record";
	    public const string ClientStreamModeAppend = "append";
        public const string ClientStreamModeLive = "live";
    }

    /// <summary>
    /// Filename generation types.
    /// </summary>
    public enum GenerationType
    {
        PLAYBACK,
        RECORD
    };
}
using System;
using System.Resources;

namespace SolidSoft.AMFCore
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class __Res
	{
		private static ResourceManager _resMgr;

        internal const string Amf_Begin = "Amf_Begin";
        internal const string Amf_End = "Amf_End";
        internal const string Amf_Fatal = "Amf_Fatal";
        internal const string Amf_Fatal404 = "Amf_Fatal404";
        internal const string Amf_ReadBodyFail = "Amf_ReadBodyFail";
        internal const string Amf_SerializationFail = "Amf_SerializationFail";
        internal const string Amf_ResponseFail = "Amf_ResponseFail";

        internal const string Arg_Mismatch = "Arg_Mismatch";

        internal const string Cache_Hit = "Cache_Hit";
        internal const string Cache_HitKey = "Cache_HitKey";

        internal const string Compiler_Error = "Compiler_Error";

        internal const string ClassDefinition_Loaded = "ClassDefinition_Loaded";
        internal const string ClassDefinition_LoadedUntyped = "ClassDefinition_LoadedUntyped";
        internal const string Externalizable_CastFail = "Externalizable_CastFail";
        internal const string TypeIdentifier_Loaded = "TypeIdentifier_Loaded";
        internal const string TypeLoad_ASO = "TypeLoad_ASO";
        internal const string TypeMapping_Write = "TypeMapping_Write";
        internal const string TypeSerializer_NotFound = "TypeSerializer_NotFound";

        internal const string Endpoint_BindFail = "Endpoint_BindFail";
        internal const string Endpoint_Bind = "Endpoint_Bind";

        internal const string Type_InitError = "Type_InitError";
        internal const string Type_Mismatch = "Type_Mismatch";
        internal const string Type_MismatchMissingSource = "Type_MismatchMissingSource";

        internal const string Destination_NotFound = "Destination_NotFound";

        internal const string MessageBroker_NotAvailable = "MessageBroker_NotAvailable";
        internal const string MessageBroker_RegisterError = "MessageBroker_RegisterError";
        internal const string MessageBroker_RoutingError = "MessageBroker_RoutingError";

        internal const string MessageServer_LoadingConfig = "MessageServer_LoadingConfig";
        internal const string MessageServer_LoadingConfigDefault = "MessageServer_LoadingConfigDefault";
        internal const string MessageServer_LoadingServiceConfig = "MessageServer_LoadingServiceConfig";
        internal const string MessageServer_Start = "MessageServer_Start";
        internal const string MessageServer_Started = "MessageServer_Started";
        internal const string MessageServer_StartError = "MessageServer_StartError";
        internal const string MessageServer_Stop = "MessageServer_Stop";
        internal const string MessageServer_AccessFail = "MessageServer_AccessFail";
        internal const string MessageServer_Create = "MessageServer_Create";

        internal const string MessageClient_Disconnect = "MessageClient_Disconnect";
        internal const string MessageClient_Unsubscribe = "MessageClient_Unsubscribe";
        internal const string MessageClient_Timeout = "MessageClient_Timeout";

        internal const string MessageDestination_RemoveSubscriber = "MessageDestination_RemoveSubscriber";

        internal const string MessageServiceSubscribe = "MessageServiceSubscribe";
        internal const string MessageServiceUnsubscribe = "MessageServiceUnsubscribe";
        internal const string MessageServiceUnknown = "MessageServiceUnknown";
        internal const string MessageServiceRoute = "MessageServiceRoute";
        internal const string MessageServicePush = "MessageServicePush";
        internal const string MessageServicePushBinary = "MessageServicePushBinary";

        internal const string Subtopic_Invalid = "Subtopic_Invalid";
        internal const string Selector_InvalidResult = "Selector_InvalidResult";

        internal const string SubscriptionManager_Remove = "SubscriptionManager_Remove";
        internal const string SubscriptionManager_CacheExpired = "SubscriptionManager_CacheExpired";

        internal const string Invalid_Destination = "Invalid_Destination";

        internal const string SocketServer_Start = "SocketServer_Start";
        internal const string SocketServer_Started = "SocketServer_Started";
        internal const string SocketServer_Stopping = "SocketServer_Stopping";
        internal const string SocketServer_Stopped = "SocketServer_Stopped";
        internal const string SocketServer_Failed = "SocketServer_Failed";
        internal const string SocketServer_ListenerFail = "SocketServer_ListenerFail";
        internal const string SocketServer_SocketOptionFail = "SocketServer_SocketOptionFail";

        internal const string Scope_Connect = "Scope_Connect";
        internal const string Scope_NotFound = "Scope_NotFound";
        internal const string Scope_ChildNotFound = "Scope_ChildNotFound";
        internal const string Scope_Check = "Scope_Check";
        internal const string Scope_CheckHostPath = "Scope_CheckHostPath";
        internal const string Scope_CheckWildcardHostPath = "Scope_CheckWildcardHostPath";
        internal const string Scope_CheckHostNoPath = "Scope_CheckHostNoPath";
        internal const string Scope_CheckDefaultHostPath = "Scope_CheckDefaultHostPath";
        internal const string Scope_UnregisterError = "Scope_UnregisterError";
        internal const string Scope_DisconnectError = "Scope_DisconnectError";

        internal const string SharedObject_Delete = "SharedObject_Delete";
        internal const string SharedObject_DeleteError = "SharedObject_DeleteError";
        internal const string SharedObject_StoreError = "SharedObject_StoreError";
        internal const string SharedObject_Sync = "SharedObject_Sync";
        internal const string SharedObject_SyncConnError = "SharedObject_SyncConnError";

        internal const string SharedObjectService_CreateStore = "SharedObjectService_CreateStore";
        internal const string SharedObjectService_CreateStoreError = "SharedObjectService_CreateStoreError";

        internal const string DataDestination_RemoveSubscriber = "DataDestination_RemoveSubscriber";

        internal const string DataService_Unknown = "DataService_Unknown";

        internal const string Sequence_AddSubscriber = "Sequence_AddSubscriber";
        internal const string Sequence_RemoveSubscriber = "Sequence_RemoveSubscriber";

        internal const string SequenceManager_CreateSeq = "SequenceManager_CreateSeq";
        internal const string SequenceManager_Remove = "SequenceManager_Remove";
        internal const string SequenceManager_RemoveStatus = "SequenceManager_RemoveStatus";
        internal const string SequenceManager_Unknown = "SequenceManager_Unknown";
        internal const string SequenceManager_ReleaseCollection = "SequenceManager_ReleaseCollection";
        internal const string SequenceManager_RemoveSubscriber = "SequenceManager_RemoveSubscriber";
        internal const string SequenceManager_RemoveEmptySeq = "SequenceManager_RemoveEmptySeq";
        internal const string SequenceManager_RemoveSubscriberSeq = "SequenceManager_RemoveSubscriberSeq";

        internal const string Service_NotFound = "Service_NotFound";

        internal const string Identity_Failed = "Identity_Failed";

        internal const string Invoke_Method = "Invoke_Method";

        internal const string Channel_NotFound = "Channel_NotFound";

        internal const string Service_Mapping = "Service_Mapping";

        internal const string TypeHelper_Probing = "TypeHelper_Probing";
        internal const string TypeHelper_LoadDllFail = "TypeHelper_LoadDllFail";
        internal const string TypeHelper_ConversionFail = "TypeHelper_ConversionFail";

        internal const string Invocation_NoSuitableMethod = "Invocation_NoSuitableMethod";
        internal const string Invocation_Ambiguity = "Invocation_Ambiguity";
        internal const string Invocation_ParameterType = "Invocation_ParameterType";

        internal const string Reflection_MemberNotFound = "Reflection_MemberNotFound";
        internal const string Reflection_PropertyReadOnly = "Reflection_PropertyReadOnly";
        internal const string Reflection_PropertySetFail = "Reflection_PropertySetFail";
        internal const string Reflection_PropertyIndexFail = "Reflection_PropertyIndexFail";
        internal const string Reflection_FieldSetFail = "Reflection_FieldSetFail";

        internal const string AppAdapter_AppConnect = "AppAdapter_AppConnect";
        internal const string AppAdapter_AppDisconnect = "AppAdapter_AppDisconnect";
        internal const string AppAdapter_RoomConnect = "AppAdapter_RoomConnect";
        internal const string AppAdapter_RoomDisconnect = "AppAdapter_RoomDisconnect";
        internal const string AppAdapter_AppStart = "AppAdapter_AppStart";
        internal const string AppAdapter_RoomStart = "AppAdapter_RoomStart";
        internal const string AppAdapter_AppStop = "AppAdapter_AppStop";
        internal const string AppAdapter_RoomStop = "AppAdapter_RoomStop";
        internal const string AppAdapter_AppJoin = "AppAdapter_AppJoin";
        internal const string AppAdapter_AppLeave = "AppAdapter_AppLeave";
        internal const string AppAdapter_RoomJoin = "AppAdapter_RoomJoin";
        internal const string AppAdapter_RoomLeave = "AppAdapter_RoomLeave";

        internal const string Compress_Info = "Compress_Info";

        internal const string AMFCore_InitModule = "AMFCore_InitModule";
        internal const string AMFCore_Start = "AMFCore_Start";
        internal const string AMFCore_Version = "AMFCore_Version";

        internal const string ServiceBrowser_Aquire = "ServiceBrowser_Aquire";
        internal const string ServiceBrowser_Aquired = "ServiceBrowser_Aquired";
        internal const string ServiceBrowser_AquireFail = "ServiceBrowser_AquireFail";

        internal const string ServiceAdapter_MissingSettings = "ServiceAdapter_MissingSettings";
        internal const string ServiceAdapter_Stop = "ServiceAdapter_Stop";

        internal const string Msmq_StartQueue = "Msmq_StartQueue";
        internal const string Msmq_InitFormatter = "Msmq_InitFormatter";
        internal const string Msmq_Receive = "Msmq_Receive";
        internal const string Msmq_Send = "Msmq_Send";
        internal const string Msmq_Fail = "Msmq_Fail";
        internal const string Msmq_Enable = "Msmq_Enable";
        internal const string Msmq_Poison = "Msmq_Poison";

		internal static string GetString(string key)
		{
			if (_resMgr == null)
			{
                _resMgr = new ResourceManager("SolidSoft.AMFCore.Resources.Resource", typeof(__Res).Assembly);
			}
			string text = _resMgr.GetString(key);
			if (text == null)
			{
				throw new ApplicationException("Missing resource from AMFCore library!  Key: " + key);
			}
			return text;
		}

		internal static string GetString(string key, params object[] inserts)
		{
			return string.Format(GetString(key), inserts);
		}
	}
}
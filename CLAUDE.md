# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

AMFCore is a .NET Standard 2.0 library implementing the AMF3 (Action Message Format) protocol for bidirectional communication between ActionScript/Flash clients and .NET servers. It supports ASP.NET MVC (.NET Framework), ASP.NET Core, and .NET 5+.

## Build Commands

```bash
# Restore dependencies
dotnet restore SolidSoft.AMFCore/SolidSoft.AMFCore.sln

# Build
dotnet build SolidSoft.AMFCore/SolidSoft.AMFCore.sln

# Build release
dotnet build SolidSoft.AMFCore/SolidSoft.AMFCore.sln -c Release
```

There are no test projects in this repository.

## Architecture

### Request Flow

```
HTTP Request
  → AMFGateway.PreRequest()         # Entry point; handles gzip/deflate compression
  → MessageServer.Service()          # Lifecycle management
  → MessageBroker                    # Routes to registered endpoint
  → AMFEndpoint                      # HTTP channel handler
  → Filter chain (sequential):
      DeserializationFilter          # AMFReader → IMessage objects
      ServiceMapFilter               # Resolves destination service class
      ProcessFilter                  # MethodHandler → InvocationManager → method call
      SerializationFilter            # IMessage → AMFWriter → response bytes
```

### Key Subsystems

**Serialization (`IO/`)** — `AMFReader`/`AMFWriter` are the core serializers. Type-specific readers/writers live in `IO/Readers/AMF0/`, `IO/Readers/AMF3/`, `IO/Writers/AMF0/`, `IO/Writers/AMF3/`. AMF0 and AMF3 are both supported; AMF3 is the primary format.

**Messaging (`Messaging/`)** — Modeled after Adobe BlazeDS. `MessageBroker` is the central router. `MessageServer` manages lifecycle. `Messaging/Config/` loads XML-based service/channel/adapter configuration. `Messaging/Services/Remoting/` handles RPC; `Messaging/Services/Messaging/` handles pub/sub.

**Type System** — `TypeHelper.cs` (~1200 LOC) is the central reflection utility used throughout. It handles type location, caching, conversion, and null value defaults. `ObjectFactory.cs` manages type instantiation with caching. Both are performance-critical paths.

**Method Invocation (`Invocation/`)** — `MethodHandler` resolves overloaded methods by matching parameter types. `InvocationManager` dispatches sync or async calls (auto-detected via `Task` return type).

**HTTP Abstraction (`DependencyInjection/`)** — `IHttpContext` decouples the library from ASP.NET version specifics. Consumers implement `IHttpContext` and register it via `HttpContextManager.Initialize()`.

### Important Data Types

- `ASObject` — represents an ActionScript object as `Dictionary<string, object>` with a `TypeName` property. Used when no .NET class mapping exists.
- `AMFMessage` / `AMFBody` / `AMFHeader` — the envelope structure for AMF requests/responses.
- Messages (`Messaging/Messages/`) — `RemotingMessage`, `AsyncMessage`, `CommandMessage`, `AcknowledgeMessage`, `ErrorMessage` mirror the Flex messaging model.

### Service Registration

Remote services are marked with `[RemotingService]` attribute. The client uses `"AMF"` as the RemoteObject destination. No XML configuration is required for basic remoting.

### Configuration

`AMFConfiguration` is a singleton loaded from XML. `AMFSettings` wraps service mappings and class mappings. The gateway initializes this via `AMFGateway.Init()`.

### Thread Safety

`Collections/` provides `CopyOnWriteArray` and `CopyOnWriteDictionary` used in hot paths. `Util/AtomicInteger` wraps interlocked operations. Be careful with `TypeHelper` and `ObjectFactory` caches — they use lock-based synchronization.

### .NET 5+ Notes

.NET 5+ requires `AllowSynchronousIO = true` on Kestrel/IIS server options because the serialization layer performs synchronous stream reads/writes.

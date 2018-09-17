# AMFCore
AMF protocol for .NET Standard 2.0

`AMFCore` is a fast and lightweight data-oriented AMF3 library for .NET Standard 2.0 (runs on .NET Core 2.0 and .NET Framework 4.6.1 and Mono 5.4 and any future implementation of .NET that implements .NET Standard 2.0 or higher without need to recompile or compile with conditional compiler variables) and full compatible with both ASP.NET MVC and ASP.NET Core without any library modification or conditional variants.

## Example Usage With ASP.NET MVC (ASP.NET 4) for .NET Framework

```csharp

Global.asax.cs:

public class WebApiApplication : HttpApplication
{
    private SolidSoft.AMFCore.AMFGateway amfGateway = null;

    public override void Init()
    {
        base.Init();

        amfGateway = new SolidSoft.AMFCore.AMFGateway();
        amfGateway.Init();
    }

    protected void Session_Start(object sender, EventArgs e)
    {
        SolidSoft.AMFCore.DependencyInjection.HttpContextManager.Initialize(
            HttpContext.Current.Request.ApplicationPath, 
            HttpContext.Current.Request.IsSecureConnection, 
            new MyHttpContext());
    }
    
    protected void Application_PreRequestHandlerExecute()
    {
        amfGateway.PreRequest();
    }
}

```
```csharp

MyHttpContext.cs (give the propor name or put on your project namespace):

using SolidSoft.AMFCore.DependencyInjection;

public class MyHttpContext : IHttpContext
{
    public Stream GetInputStream()
    {
        return System.Web.HttpContext.Current.Request.InputStream;
    }

    public Stream GetOutputStream()
    {
        return System.Web.HttpContext.Current.Response.OutputStream;
    }

    public void Clear()
    {
        System.Web.HttpContext.Current.Response.Clear();
    }

    public string GetContentType()
    {
        return System.Web.HttpContext.Current.Request.ContentType;
    }

    public void SetContentType(string contentType)
    {
        System.Web.HttpContext.Current.Response.ContentType = contentType;
    }

    public void Finish()
    {
        System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
}


```

```csharp

GatewayController.cs (MVC is NOT the only option for .NET Framework but it's the most modern one and the common bond with .NET Core but with a very small change and additional parameter this could be parameterizable and for the sake of simplicity, the controller must be called Gateway but with an additional parameter this could also be parameterizable)

using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Controllers
{
    public class GatewayController : ApiController
    {
        [Route("gateway")]
        [HttpGet]
        public HttpResponseMessage Gateway()
        {
           return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

```

## Example Usage With ASP.NET Core compatible with both .NET Framework and .NET Core

```csharp

Startup.cs:

public class Startup
{
    private static SolidSoft.AMFCore.AMFGateway amfGateway = null;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        amfGateway = new SolidSoft.AMFCore.AMFGateway();
        amfGateway.Init();
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.Use(async (context, next) =>
        {
            SolidSoft.AMFCore.DependencyInjection.HttpContextManager.Initialize(
                context.Request.PathBase,
                context.Request.IsHttps,
                new Framework.HttpContext());
                await next();
        });

        MyHttpContextAccessor.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

        app.Map("/gateway", handleAMFGateway);

        app.UseMvc();
    }

    private static void handleAMFGateway(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await Task.Run(() => amfGateway.PreRequest());
        });
    }
}
```

```csharp

MyHttpContextAccessor.cs: (give a propor name or put in a namespace):

public static class MyHttpContextAccessor
{
    private static Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;

    public static void Configure(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public static Microsoft.AspNetCore.Http.HttpContext Current
    {
        get
        {
            return _httpContextAccessor.HttpContext;
        }
    }
}

```

```csharp

MyHttpContext.cs (give the propor name or put on your project namespace):

using System.IO;
using SolidSoft.AMFCore.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class MyHttpContext : IHttpContext
{
    public Stream GetInputStream()
    {
        return MyHttpContextAccessor.Current.Request.Body;
    }

    public Stream GetOutputStream()
    {
        return MyHttpContextAccessor.Current.Response.Body;
    }

    public void Clear()
    {
        MyHttpContextAccessor.Current.Response.Clear();
    }

    public string GetContentType()
    {
        return MyHttpContextAccessor.Current.Request.ContentType;
    }

    public void SetContentType(string contentType)
    {
        MyHttpContextAccessor.Current.Response.ContentType = contentType;
    }

    public void Finish()
    {
    }
}

```

```csharp

GatewayController.cs (MVC is the only option for .NET Core and for the sake of simplicity, the controller must be called Gateway but with an additional parameter this could be parameterizable)

using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class GatewayController : Controller
    {
        [Route("gateway")]
        [HttpGet]
        public HttpResponseMessage Gateway()
        {
           return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

```

## Example Usage of AMF Service

```csharp

//on client side you should use "AMF" as RemoteObject destination
[RemotingService()]
public class HelloWorldService
{
    public SayHello(string name)
    {
        return "Hello " + name + " !, Hope you are doing well !!";
    }
}

```

# Performance

ASP.NET 4 for .NET Framework runs under IIS (w3wp.exe process) and it's super fast once it's loaded (the IIS loading it's a bit slow).

ASP.NET Core for .NET Framework and .NET Core runs under Kestrel embeded Web Server that could be used without an aditional Web Server however it's not recomend because it's relative new and don't supporte iet many features that a more mature Web Server (like IIS) does.

Comparing a relative big project with AMFCore + ASP.NET + .NET 4.7 + IIS versus converted version for ASP.NET Core + .NET 4.7 or .NET Core 2.1 + Kestrel, the performance it's similar however running ASP.NET Core with a reverse proxy (the recomended scenario for production) with IIS it's 4 to 5 times slower and with Apache it's even worse !

But there is good news:
https://blogs.msdn.microsoft.com/webdev/2018/02/28/asp-net-core-2-1-0-preview1-improvements-to-iis-hosting
https://github.com/aspnet/IISIntegration/issues/878

So, using AMFCore with .NET Framework it's a path for migrated to ASP.NET Core latter with the minimum impact when the version 2.2 comes out (on this time writing we are on the 2.1 version).

## License

- This library is MIT licensed
- Feel free to use it in any way you wish
- Please contribute improvements back to this repository!

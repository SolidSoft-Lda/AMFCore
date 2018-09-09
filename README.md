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

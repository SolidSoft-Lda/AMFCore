namespace SolidSoft.AMFCore.DependencyInjection
{
    public class HttpContextManager
    {
        public static void Initialize(string contextPath, bool isSecure, IHttpContext httpContext)
        {
            ContextPath = contextPath;
            IsSecure = isSecure;
            HttpContext = httpContext;
        }

        public static string ContextPath { get; private set; }
        public static bool IsSecure { get; private set; }
        public static IHttpContext HttpContext { get; private set; }
    }
}
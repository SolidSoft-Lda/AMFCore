using System.IO;

namespace SolidSoft.AMFCore.DependencyInjection
{
    public interface IHttpContext
    {
        Stream GetInputStream();
        Stream GetOutputStream();
        void Clear();
        string GetContentType();
        void SetContentType(string contentType);
        void Finish();
    }
}
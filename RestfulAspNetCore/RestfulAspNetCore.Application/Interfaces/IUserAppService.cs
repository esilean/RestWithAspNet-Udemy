using System;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IFileAppService : IDisposable
    {
        byte[] GetPDFFile();
    }
}

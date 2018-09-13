using System;
using System.IO;
using RestfulAspNetCore.Application.Interfaces;

namespace RestfulAspNetCore.Application.Services
{
    public class FileAppService : IFileAppService
    {
   

        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fulPath = path + @"/PDF/aspnet-life-cycles-events.pdf";
            return File.ReadAllBytes(fulPath);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}

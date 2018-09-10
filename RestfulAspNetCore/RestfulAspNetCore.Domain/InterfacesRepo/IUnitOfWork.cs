using System;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}

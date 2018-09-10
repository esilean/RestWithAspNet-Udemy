using System;
using System.Collections.Generic;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IRepo<T> : IDisposable where T : class
    {
        T Add(T entity);
        T FindById(int id);
        List<T> FindAll();
        T Update(T obj);
        void Remove(int id);
        int SaveChanges();
    }
}

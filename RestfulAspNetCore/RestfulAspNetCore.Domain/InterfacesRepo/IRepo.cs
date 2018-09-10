using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IRepo<T> where T : class
    {
        T Create(T entity);
        T FindById(string id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(string id);
    }
}

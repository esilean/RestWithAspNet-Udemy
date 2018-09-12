using System;
using System.Collections.Generic;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Application.Model.Pagination;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        PersonModel Add(PersonModel person);
        PersonModel FindById(int id);
        List<PersonModel> FindAll();
        List<PersonModel> FindByName(string firstName, string lastName);
        PersonModel Update(PersonModel person);
        void Remove(int id);

        //List<PersonModel> FindWithPageSearch(string sortDirection, int pageSize, int page);
        PagedList<PersonModel> FindWithPageSearch(PagingParams pagingParams);
    }
}

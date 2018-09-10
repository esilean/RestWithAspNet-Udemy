using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Data.Repositories
{
    public class PersonRepo : Repository<Person>, IPersonRepo
    {

        public PersonRepo(ContextApp context) : base(context) { }

        public Person FindByName(string firstName)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.FirstName == firstName);
        }

        //public Person Update(Person person)
        //{

        //    var result = FindById((long)person.Id);

        //    if (result == null)
        //        return new Person();

        //    try
        //    {
        //        _context.Entry(result).CurrentValues.SetValues(person);
        //        _context.SaveChanges();

        //        return person;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}

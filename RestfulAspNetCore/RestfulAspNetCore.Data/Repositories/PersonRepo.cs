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

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                return DbSet.AsNoTracking().Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return DbSet.AsNoTracking().Where(p => p.FirstName.Contains(firstName)).ToList();
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                return DbSet.AsNoTracking().Where(p => p.LastName.Contains(lastName)).ToList();
            else
                return DbSet.AsNoTracking().ToList();
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

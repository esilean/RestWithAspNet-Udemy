using System;
using System.Collections.Generic;
using System.Linq;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Data.Repositories
{
    public class PersonRepo : IPersonRepo
    {

        private ContextApp _context;

        public PersonRepo(ContextApp context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            _context.Remove(FindById(id));
            _context.SaveChanges();
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }

        public Person Update(Person person)
        {

            var result = FindById((long)person.Id);

            if (result == null)
                return new Person();

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();

                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

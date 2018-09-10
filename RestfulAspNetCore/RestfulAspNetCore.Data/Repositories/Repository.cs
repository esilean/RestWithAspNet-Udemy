using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Data.Repositories
{
    public class Repository<T> : IRepo<T> where T : class
    {

        private readonly ContextApp _context;
        private DbSet<T> DB;

        public Repository(ContextApp context)
        {
            _context = context;
            DB = _context.Set<T>();
        }

        public T Create(T entity)
        {
            try
            {
                DB.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            try
            {
                var entity = FindById(id);

                DB.Remove(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            return DB.ToList();
        }

        public T FindById(string id)
        {
            return DB.Find(id);
        }

        public T Update(T entity)
        {
            try
            {
                DB.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

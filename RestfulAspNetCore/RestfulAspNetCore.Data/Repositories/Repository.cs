using Microsoft.EntityFrameworkCore;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.InterfacesRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulAspNetCore.Data.Repositories
{
    public class Repository<T> : IRepo<T> where T : class
    {

        protected readonly ContextApp Db;
        protected readonly DbSet<T> DbSet;

        public Repository(ContextApp context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual List<T> FindAll()
        {
            return DbSet.ToList();
        }

        public virtual T FindById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}

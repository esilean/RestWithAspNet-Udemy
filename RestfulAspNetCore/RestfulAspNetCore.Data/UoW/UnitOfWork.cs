﻿using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextApp _context;

        public UnitOfWork(ContextApp context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

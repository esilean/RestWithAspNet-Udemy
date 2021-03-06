﻿using System;
using Microsoft.EntityFrameworkCore;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Data.Context
{
    public class ContextApp : DbContext
    {
        public ContextApp()
        {
        }

        public ContextApp(DbContextOptions<ContextApp> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }


    }
}

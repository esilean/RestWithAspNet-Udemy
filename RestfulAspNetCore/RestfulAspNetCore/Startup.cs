using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Services;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Data.Repositories;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;
using RestfulAspNetCore.Domain.Services;

namespace RestfulAspNetCore
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _enviroment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment enviroment, ILogger<Startup> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _enviroment = enviroment;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];

            services.AddDbContext<ContextApp>(options => options.UseMySql(connectionString));

            //if(_enviroment.IsDevelopment())
            //{
            //    try
            //    {
            //        var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            //        var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
            //        {
            //            Locations = new List<string> { "db/migrations"},
            //            IsEraseDisabled = true,
            //        };

            //        evolve.Migrate();

            //    }
            //    catch (System.Exception ex)
            //    {
            //        _logger.LogCritical("Database migration failed.", ex);
            //        throw;
            //    }
            //}

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();
            services.AddApiVersioning();

            //Application
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<IBookAppService, BookAppService>();
            //Domain
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            //Data
            services.AddScoped<IPersonRepo, PersonRepo>();
            services.AddScoped<IBookRepo, BookRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

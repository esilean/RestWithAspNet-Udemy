using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Services;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Data.Repositories;
using RestfulAspNetCore.Data.UoW;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;
using RestfulAspNetCore.Domain.Services;
using RestfulAspNetCore.Services.ErrorHandling;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx => new ValidationErrorDetailResult();
            });

            services.AddAutoMapper();
            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Restful API With ASP.NET Core 2.0", Version = "V1" });
            });

            //Application
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<IBookAppService, BookAppService>();
            //Domain
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            //Data
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPersonRepo, PersonRepo>();
            services.AddScoped<IBookRepo, BookRepo>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

#pragma warning disable 1998
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = errorFeature.Error;

                        //var errorExp = env.IsDevelopment()
                        //? exception.ToString()
                        //: "A instancia deve ser usado para auxiliar no envio das info para o suporte.";

                        //Init
                        var errorDetail = new ErrorDetail
                        {
                            Instance = $"urn:bevixy:error:{Guid.NewGuid()}"
                        };

                        if (exception is BadHttpRequestException badHttpRequestException)
                        {
                            errorDetail.Title = "Solicitação inválida!";
                            errorDetail.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                            errorDetail.Detail = badHttpRequestException.Message;
                            errorDetail.StackTrace = "";
                            errorDetail.InnerMessage = "";
                        }
                        else
                        {
                            errorDetail.Title = "Ocorreu um erro inesperado!";
                            errorDetail.Status = 500;
                            errorDetail.Detail = exception.Message.ToString();
                            errorDetail.StackTrace = exception.ToString();
                            errorDetail.InnerMessage = (exception.InnerException != null) ? exception.InnerException.Message : "";
                        }

                        // log the exception etc..

                        context.Response.StatusCode = errorDetail.Status.Value;
                        context.Response.WriteJson(errorDetail, "application/problem+json");

                    });
                });
#pragma warning restore 1998
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

public static class HttpExtensions
{
    private static readonly JsonSerializer Serializer = new JsonSerializer
    {
        NullValueHandling = NullValueHandling.Ignore
    };

    public static void WriteJson<T>(this HttpResponse response, T obj, string contentType = null)
    {
        response.ContentType = contentType ?? "application/json";
        using (var writer = new HttpResponseStreamWriter(response.Body, Encoding.UTF8))
        {
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.CloseOutput = false;
                jsonWriter.AutoCompleteOnClose = false;

                Serializer.Serialize(jsonWriter, obj);
            }
        }
    }
}
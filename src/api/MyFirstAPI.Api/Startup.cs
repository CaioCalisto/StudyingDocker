using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstAPI.Application.SQLServer.Queries;
using MyFirstAPI.Domain.Ports;
using MyFirstAPI.Infrastructure.NoSqlDatabase;
using MyFirstAPI.Infrastructure.NoSqlDatabase.Adapters;
using MyFirstAPI.Infrastructure.NoSqlDatabase.Repositories;
using MyFirstAPI.Infrastructure.SqlDatabase;
using MyFirstAPI.Infrastructure.SqlDatabase.Adapter;
using MyFirstAPI.Infrastructure.SqlDatabase.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;

namespace MyFirstAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddCustomDbContext(Configuration);
            services.AddMediatR(AppDomain.CurrentDomain.Load("MyFirstAPI.Application"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("MyFirstAPI.Infrastructure"));
            services.AddTransient<IProductRepository, ProductSqlRepositoryAdapter>();
            services.AddTransient<IBrandRepository, BrandMongoRepositoryAdapter>();
            services.AddTransient<IProductSqlRepository, ProductSqlRepository>();
            services.AddTransient<IBrandMongoRepository, BrandMongoRepository>();
            services.AddTransient<IMyMongoContext, MyMongoContext>();
            services.AddTransient<IProductQueries>(s => new ProductQueries(Configuration["ConnectionString"]));
        }
        
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<MySqlContext>(options =>
                   {
                       options.UseSqlServer(configuration["ConnectionString"],
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
                   },
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );

            return services;
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstAPI.Domain.Ports;
using MyFirstAPI.Infrastructure.SqlDatabase;
using MyFirstAPI.Infrastructure.SqlDatabase.Adapter;
using MyFirstAPI.Infrastructure.SqlDatabase.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace MyFirstAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddDbContext<ProductSqlContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"]);
            });
            services.AddMediatR(AppDomain.CurrentDomain.Load("MyFirstAPI.Application"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("MyFirstAPI.Infrastructure"));
            services.AddTransient<IProductRepository, ProductSqlRepositoryAdapter>();
            services.AddTransient<IProductSqlRepository, ProductSqlRepository>();
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

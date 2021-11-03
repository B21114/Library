using Library.DL.Domain;
using Library.DL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;

namespace Library.Web
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
            // ��������� �������� AuthorContex � �������� ������� � ����������.
            services.AddDbContext<IAuthorDbContext, AuthorDbContext>(options => options.UseInMemoryDatabase("MyDataBase"));

            // ��������� �������� BookContex � �������� ������� � ����������.
            services.AddDbContext<IBookDbContext, BookDbContext>(options => options.UseInMemoryDatabase("MyDataBase"));

            // ��������� �������� PublisherContext � �������� ������� � ����������.
            services.AddDbContext<IPublisherDbContext, PublisherDbContext>(options => options.UseInMemoryDatabase("MyDataBase"));

            // ��������� �����.
            var assemblies = new Assembly[]
            {
                typeof(Library.BL.Bootstrap.ServiceCollectionExtensions).Assembly,
            };

            // ������ ���������� ����������� ������� Mediator(���������).
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // ������ ����������� ������������ ���� ������ �� ������.
            services.AddAutoMapper(assemblies);

            // ������ ��������� ������ � ��������� � ��������� ���������� ������������.
            services.AddMediatR(assemblies);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library.Web v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

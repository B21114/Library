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
            services.AddControllers();

            // Получаем строку подключения из файла конфигурации.
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            //var options = optionsBuilder
             //   .UseSqlServer(connectionString)
             //   .Options;

            // Добавляем контекст DataBaeContex в качестве сервиса в приложение.
            services.AddDbContext<IDataBaseContext, DataBaseContext>(options => options.UseSqlServer(connectionString));

            // Сервис помогающий реализовать паттерн Mediator(Посредник).
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Получение типов.
            var assemblies = new Assembly[]
            {
                typeof(Library.BL.Bootstrap.ServiceCollectionExtensions).Assembly,
            };

            // Сервис позволяющий проецировать одну модель на другую.
            services.AddAutoMapper(assemblies);

            // Сервис сканирует сборки и добавляет в контейнер реализации обработчиков.
            services.AddMediatR(assemblies);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                  new OpenApiInfo
                  {
                      Title = "Library.Web",
                      Version = "v1",
                      Description = "API for the  Server"
                  });
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library.Web v1"));
            app.UseRouting();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

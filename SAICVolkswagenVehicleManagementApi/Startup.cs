using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ResultTest;
using ResultTest.Filters;
using SAICVolkswagenVehicleManagement_Helper;
using SAICVolkswagenVehicleManagement_Model;
using System;
using System.IO;
using System.Reflection;

namespace SAICVolkswagenVehicleManagementApi
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
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new OpenApiInfo { Title = "SAICVolkswagenVehicleManagement", Version = "v1" });
                //���س��򼯵�xml�����ĵ�
                var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                var xmlFile = System.AppDomain.CurrentDomain.FriendlyName + ".xml";
                var xmlPath = Path.Combine(baseDirectory, xmlFile);
                m.IncludeXmlComments(xmlPath, true);
            });
            services.AddControllers();
            services.AddDbContext<Base_DbContext>(s =>
            { 
                s.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); 
            });

            //����ע��
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidateModelAttribute>();
                options.Filters.Add<ApiResultFilterAttribute>();
                options.Filters.Add<CustomExceptionAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

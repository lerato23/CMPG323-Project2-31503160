using IoTDevicesProject.Business_logic;
using IoTDevicesProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace IoTDevicesProject
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
            services.AddDbContext<iotdevicesdatabaseContext>(a=>a.UseSqlServer("name=ConnectionStrings:dbconnection_string"));
            services.AddControllers();
            services.AddSwaggerGen(a => a.SwaggerDoc("v1", new OpenApiInfo { Title = "IoT Device Management API Lerato-Shabalala", Version = "v1", Contact=new OpenApiContact { 
                Name = "Lerato Shabalala"
            }
            }));
            services.AddScoped<CategoryFunctions, CategoryFunctions>();
            services.AddScoped<ZoneFunctions, ZoneFunctions>();
            services.AddScoped<DeviceFunctions, DeviceFunctions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(a=> a.SwaggerEndpoint("/swagger/v1/swagger.json","IoT Devices Management Application Programming Interface (API)"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

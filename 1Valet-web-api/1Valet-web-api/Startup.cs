using _1Valet_web_api.Models;
using _1Valet_web_api.Repositories;
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

namespace _1Valet_web_api
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

            //To add a CORS policy so that our angular application can access the endpoints (Web API app)
            services.AddCors((options) =>
            {
                options.AddPolicy("angularApp", (builder) =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithExposedHeaders("*");
                });
            });
            services.AddControllers();

            services.AddDbContext<DbContextClass>(options => options.UseSqlServer(Configuration.GetConnectionString("1ValetDbConnectString")));

            //Inject our dependences inside services which we can use in our controller
            services.AddScoped<IDeviceRepository, SQLDeviceRepository>();

            //Inject our dependences inside services which we can use in our controller
            services.AddScoped<ITypeRepository, SQLTypeRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "_1Valet_web_api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup).Assembly);
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "_1Valet_web_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            //To use the Cors ploicy we have created for the angularapp to be able to call these apis
            app.UseCors("angularApp");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

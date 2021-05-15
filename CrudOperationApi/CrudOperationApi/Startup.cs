using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CrudOperationApi.IServices;
using CrudOperationApi.Models;
using CrudOperationApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CrudOperationApi
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
            //add swagger services
            services.AddSwaggerGen();

            services.AddControllers();

            services.AddHttpClient();
            services.AddDbContext<AkijFoodDBContext>(options =>
                     options.UseSqlServer(Configuration["DbConnection"]));
            services.AddTransient<ISoftdrinksService, SoftdrinksService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //built-in global exception
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {

                            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.StatusCode = 500;//internalServerError
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                //await context.Response.WriteAsync(ex.Error.Message);
                                await context.Response.WriteAsync("Some unknown error occured!");
                            }
                        }
                    );
                }
            );

            //configure swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "api/Softdrinks";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

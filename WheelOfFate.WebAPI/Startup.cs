using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WheelOfFate.Data;
using WheelOfFate.Domain.Interfaces.Services;
using WheelOfFate.Services;

namespace WheelOfFate.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) // Injection of IConfiguration
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBauService, BauService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFromAll",
                    builder => builder
                    .WithMethods("GET", "POST")
                    .AllowAnyOrigin()
                    .AllowAnyHeader());
            }); ;

            services.AddDbContext<BauApiContext>(options => options.UseInMemoryDatabase());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowFromAll");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}

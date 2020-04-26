using GeoReader.Reader;
using GeoSearcher.Infrastructure;
using GeoSearcher.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeoSearcher
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
            services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });

            var reader = new GeoFileReader(Configuration["GeobasePath"]);
            services.AddSingleton(new GeobaseContext(reader));
            services.AddScoped<IGeobaseRepository, GeobaseRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware(env).Invoke
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc();
        }
    }
}
using asp_mvc_app.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp_mvc_app
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
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MobileContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mobilestoredb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(name: "MyArea", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "store_area", areaName: "store", template: "store/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

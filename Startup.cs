using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DouriaPerfume.Data;
using Microsoft.EntityFrameworkCore;
using DouriaPerfume.Data.Repositories;
using DouriaPerfume.Data.Interfaces;
using DouriaPerfume.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlClient;
using Douriaperfume.Data.Repositories;
using DouriaPerfume.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace DouriaPerfume
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Server configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //Authentication, Identity config
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPerfumeRepository, PerfumeRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, Microsoft.IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: " Perfumedetails",
                   template: "Perfume / Details /{ PerfumeId ?}",
              
                   defaults: new { Controller = " Perfume ", action = "Details" });
            routes.MapRoute(
                name: "categoryfilter",
                template: " Perfume /{ action}/{ category ?}",
                    defaults: new { Controller = "Perfume", action = "List" });

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{Id?}");
        });

            DbInitializer.Seed(app);
        }
}
}
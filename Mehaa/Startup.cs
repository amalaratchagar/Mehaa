using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.User;
using Infrastructure.Data;
using Infrastructure.Respositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Services;

namespace Mehaa
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
            services.AddDbContext<MehaaDb>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(MehaaDb).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
            services.AddTransient<IItemCategoryRepositoryAsync, ItemCategoryRepositoryAsync>();
            services.AddTransient<IItemStockRepositoryAsync, ItemStockRepositoryAsync>();
            services.AddTransient<IItemRepositoryAsync, ItemRepositoryAsync>();
            services.AddTransient<IPermissionRepositoryAsync, PermissionRepositoryAsync>();
            services.AddTransient<IUserPermissionRepositoryAsync, UserPermissionRepositoryAsync>();
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<ILookupRepositoryAsync, LookupRepositoryAsync>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddHttpContextAccessor();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IRazorRenderService, RazorRenderService>();

            //services.AddControllersWithViews();
            // services.AddProgressiveWebApp(); Fix me

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}

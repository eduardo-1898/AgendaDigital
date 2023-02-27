using Infrastructure.Model;
using IRepositories;
using IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.DomainModels;
using Repositories;
using Services;
using Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTSoft.Desarrollos
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
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
            services.AddDbContext<ASTDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SubwayConection")));
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            ConfigurarBaseDeDatos(services);
            services.AddMemoryCache();
            services.AddSession();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
            });

            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();

            services.AddMvc().AddRazorRuntimeCompilation();

            //Servicios
            services.AddScoped(typeof(IAST_AgendaDigitalService), typeof(AST_AgendaDigitalService));
            services.AddScoped(typeof(IVehiclesService), typeof(VehiclesService));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigurarBaseDeDatos(IServiceCollection services)
        {
            var connectionString = new ConnectionString(Configuration.GetConnectionString("ConnectionString"));
            services.AddSingleton(connectionString);
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Data;
using EmployeeManagment.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using EmployeeManagment.Common.Mapping;
using EmployeeManagment.Data.Contracts;
using EmployeeManagment.Data.Implementation;
using EmployeeManagment.BussinessEngine.Contracts;
using EmployeeManagment.BussinessEngine.Implementations;

namespace EmployeeManagment.UI
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
            services.AddRazorPages();
            services.AddDbContext<EmployeeManagmentContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));

            services.AddAutoMapper(typeof(Maps));

            //services.AddScoped<IEmployeeLeaveTypeRepository, EmployeeLeaveTypeRepository>();
            //services.AddScoped<IEmployeeLeaveRequestRepository, EmployeeLeaveRequestRepository>();
            //services.AddScoped<IEmployeeLeaveAllocationRepository, EmployeeLeaveAllocationRepository>();

            services.AddScoped<IEmloyeeLeaveTypesBussinessEngine, EmloyeeLeaveTypesBussinessEngine>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapRazorPages();
            });
        }
    }
}

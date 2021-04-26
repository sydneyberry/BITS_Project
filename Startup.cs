﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;


namespace BITS_Project
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

            services.AddDbContext<BitsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BitsContext")));


            /*services.AddDbContext<ReservationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ReservationContext")));

            services.AddDbContext<TournamentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TournamentContext")));

            services.AddDbContext<EquipmentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("EquipmentContext")));*/

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.ConfigureApplicationCookie(options => {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });
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
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

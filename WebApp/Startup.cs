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
using Microsoft.EntityFrameworkCore;

using LogicaAccesoDatos.EF;
using LogicaNegocio.Interfaces;
using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaAplicacion.UseCases.UCEntities.NationalTeams;

namespace WebApp
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
            services.AddDbContext<ObligatorioContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("production")));

            services.AddControllersWithViews();

            services.AddScoped<IRepositoryCountry, RepositoryCountry>();
            services.AddScoped<IRead<Country>, ReadAllCountry>();
            services.AddScoped<ICreate<Country>, CreateCountry>();

            services.AddScoped<IRepositoryNationalTeam, RepositoryNationalTeam>();
            services.AddScoped<ICreate<NationalTeam>, CreateNationalTeam>();
            services.AddScoped<IRead<NationalTeam>, ReadAllNationalTeam>();
            services.AddScoped<IUpdate<NationalTeam>, UpdateNationalTeam>();
            services.AddScoped<IDelete<NationalTeam>, DeleteNationalTeam>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}

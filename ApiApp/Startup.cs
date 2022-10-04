using LogicaAccesoDatos.EF;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaAplicacion.UseCases.UCEntities.NationalTeams;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp
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
            services.AddControllers();

            services.AddScoped<IRepositoryCountry, RepositoryCountry>();
            services.AddScoped<IRead<Country>, ReadAllCountry>();
            services.AddScoped<ICreate<Country>, CreateCountry>();
            services.AddScoped<IDelete<Country>, DeleteCountry>();

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

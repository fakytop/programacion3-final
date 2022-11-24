using LogicaAccesoDatos.EF;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaAplicacion.UseCases.UCDomain;
using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaAplicacion.UseCases.UCEntities.GroupsStage;
using LogicaAplicacion.UseCases.UCEntities.Matches;
using LogicaAplicacion.UseCases.UCEntities.MatchResults;
using LogicaAplicacion.UseCases.UCEntities.NationalTeams;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<ObligatorioContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("production")));
            
            services.AddScoped<IRepositoryCountry, RepositoryCountry>();
            services.AddScoped<IRead<Country>, ReadAllCountry>();
            services.AddScoped<ICreate<Country>, CreateCountry>();
            services.AddScoped<IDelete<Country>, DeleteCountry>();

            services.AddScoped<IRepositoryNationalTeam, RepositoryNationalTeam>();
            services.AddScoped<ICreate<NationalTeam>, CreateNationalTeam>();
            services.AddScoped<IRead<NationalTeam>, ReadAllNationalTeam>();
            services.AddScoped<IUpdate<NationalTeam>, UpdateNationalTeam>();
            services.AddScoped<IDelete<NationalTeam>, DeleteNationalTeam>();
            services.AddScoped<IReadFilterNationalTeams<NationalTeam>, ReadAllNationalTeam>();

            services.AddScoped<IRepositoryGroupStage, RepositoryGroupStage>();
            services.AddScoped<ICreate<GroupStage>, CreateGroupStage>();
            services.AddScoped<IRead<GroupStage>, ReadAllGroupStage>();
            services.AddScoped<IUpdate<GroupStage>, UpdateGroupStage>();
            services.AddScoped<IDelete<GroupStage>, DeleteGroupStage>();

            services.AddScoped<IAssign<GroupStage>, Assign>();

            services.AddScoped<IRepositoryMatch, RepositoryMatch>();
            services.AddScoped<ICreate<Match>, CreateMatch>();
            services.AddScoped<IRead<Match>, ReadMatch>();
            services.AddScoped<IReadFilterMatches<Match>, ReadMatch>();

            services.AddScoped<IRepositoryMatchResult, RepositoryMatchResult>();
            services.AddScoped<ICreate<MatchResult>, CreateMatchResult>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
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

            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            }
                );

            app.UseSwaggerUI(
                    options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                        options.RoutePrefix = string.Empty;
                    }
                );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

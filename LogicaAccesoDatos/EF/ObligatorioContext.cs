using LogicaAccesoDatos.EF.Config;
using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF
{
    public class ObligatorioContext: DbContext
    {
        public ObligatorioContext(DbContextOptions<ObligatorioContext> options): base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<NationalTeam> NationalTeams { get; set; }
        public DbSet<GroupStage> GroupsStage { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<MatchResult> MatchResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
   
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new NationalTeamConfig());
            modelBuilder.ApplyConfiguration(new GroupStageConfig());
            modelBuilder.ApplyConfiguration(new MatchConfig());
            modelBuilder.ApplyConfiguration(new MatchResultConfig());

        }
    }
}

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
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().
                ToTable("Countries")
                .OwnsOne(p => p.Name)
                .Property(p => p.Value)
                .HasColumnName("Name");

            modelBuilder.Entity<Country>().
                ToTable("ISOAlfa3")
                .OwnsOne(p => p.IsoAlfa3)
                .Property(p => p.Value)
                .HasColumnName("ISOAlfa3");

            modelBuilder.Entity<Country>().
                ToTable("Countries")
                .OwnsOne(p => p.GDP)
                .Property(p => p.Value)
                .HasColumnName("GDP")
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Country>().
                ToTable("Countries")
                .OwnsOne(p => p.Population)
                .Property(p => p.Value)
                .HasColumnName("Population");

            modelBuilder.Entity<Country>().
                ToTable("Countries")
                .OwnsOne(p => p.Region)
                .Property(p => p.Value)
                .HasColumnName("Region");

            modelBuilder.ApplyConfiguration(new NationalTeamConfig());
        }
    }
}

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

        public DbSet<Country> Paises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().
                ToTable("Paises")
                .OwnsOne(p => p.Nombre)
                .Property(n => n.Value)
                .HasColumnName("Nombre");

            modelBuilder.Entity<Country>().
                ToTable("ISOAlfa3")
                .OwnsOne(p => p.IsoAlfa3)
                .Property(i => i.Value)
                .HasColumnName("ISOAlfa3");

            modelBuilder.Entity<Country>().
                ToTable("Paises")
                .OwnsOne(p => p.PBI)
                .Property(i => i.Value)
                .HasColumnName("PBI")
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Country>().
                ToTable("Paises")
                .OwnsOne(p => p.Poblacion)
                .Property(p => p.Value)
                .HasColumnName("Poblacion");

            modelBuilder.Entity<Country>().
                ToTable("Paises")
                .OwnsOne(p => p.Region)
                .Property(r => r.Value)
                .HasColumnName("Region");
        }
    }
}

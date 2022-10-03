using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF.Config
{
    public class NationalTeamConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.OwnsOne(country => country.Name)
                .Property(p => p.Value)
                .HasColumnName("Name");

            builder.OwnsOne(country => country.IsoAlfa3)
                .Property(p => p.Value)
                .HasColumnName("IsoAlfa3");

            builder.OwnsOne(country => country.GDP)
                .Property(p => p.Value)
                .HasColumnName("GDP")
                .HasColumnType("decimal(18,4)");

            builder.OwnsOne(country => country.Population)
                .Property(p => p.Value)
                .HasColumnName("Population");

            builder.OwnsOne(country => country.Region)
                .Property(p => p.Value)
                .HasColumnName("Region");
        }
    }
}

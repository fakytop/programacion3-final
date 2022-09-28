using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF.Config
{
    public class NationalTeamConfig : IEntityTypeConfiguration<NationalTeam>
    {
        public void Configure(EntityTypeBuilder<NationalTeam> builder)
        {
            builder.OwnsOne(nt => nt.Name)
                .Property(n => n.Value)
                .HasColumnName("Name");
            builder.OwnsOne(nt => nt.Phone)
                .Property(p => p.Value)
                .HasColumnName("Phone");
            builder.OwnsOne(nt => nt.Email)
                .Property(e => e.Value);
            builder.OwnsOne(nt => nt.Bettors)
                .Property(b => b.Value)
                .HasColumnName("Bettors");
        }
    }
}

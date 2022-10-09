using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF.Config
{
    public class MatchConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(m => m.Home)
                .WithMany()
                .HasForeignKey(m => m.HomeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(m => m.Away)
                .WithMany()
                .HasForeignKey(m => m.AwayId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.OwnsOne(m => m.MatchDate)
                .Property(d => d.Value)
                .HasColumnName("Match_Date");
            builder.HasOne(m => m.MatchResult)
                .WithMany()
                .HasForeignKey(m => m.MatchResultId);
        }
    }
}

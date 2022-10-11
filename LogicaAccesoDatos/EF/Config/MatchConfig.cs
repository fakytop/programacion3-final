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
            //Statistics Home
            builder.OwnsOne(m => m.HomeStatistics)
                .Property(g => g.Goals)
                .HasColumnName("Goals_Home");
            builder.OwnsOne(m => m.HomeStatistics)
                .Property(yc => yc.YellowCards)
                .HasColumnName("YellowCards_Home");
            builder.OwnsOne(m => m.HomeStatistics)
                .Property(rc => rc.RedCards)
                .HasColumnName("RedCards_Home");
            builder.OwnsOne(m => m.HomeStatistics)
                .Property(drc => drc.DirectRedCards)
                .HasColumnName("Direct_RedCards_Home");
            
            //Statistics Away
            builder.OwnsOne(m => m.AwayStatistics)
                .Property(g => g.Goals)
                .HasColumnName("Goals_Away");
            builder.OwnsOne(m => m.AwayStatistics)
                .Property(yc => yc.YellowCards)
                .HasColumnName("YellowCards_Away");
            builder.OwnsOne(m => m.AwayStatistics)
                .Property(rc => rc.RedCards)
                .HasColumnName("RedCards_Away");
            builder.OwnsOne(m => m.AwayStatistics)
                .Property(drc => drc.DirectRedCards)
                .HasColumnName("Direct_RedCards_Away");



            //builder.HasOne(m => m.MatchResult)
            //    .WithMany()
            //    .HasForeignKey(m => m.MatchResultId);
        }
    }
}

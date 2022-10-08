using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF.Config
{
    public class MatchResultConfig : IEntityTypeConfiguration<MatchResult>
    {
        public void Configure(EntityTypeBuilder<MatchResult> builder)
        {
            builder.OwnsOne(mr => mr.GoalsH)
                .Property(gh => gh.Value)
                .HasColumnName("Goals_Home");
            builder.OwnsOne(mr => mr.GoalsA)
                .Property(ga => ga.Value)
                .HasColumnName("Goals_Away");
            builder.OwnsOne(mr => mr.YellowCardsH)
                .Property(ych => ych.Value)
                .HasColumnName("Yellow_Cards_Home");
            builder.OwnsOne(mr => mr.YellowCardsA)
                .Property(yca => yca.Value)
                .HasColumnName("Yellow_Cards_Away");
            builder.OwnsOne(mr => mr.RedCardsH)
                .Property(rch => rch.Value)
                .HasColumnName("Red_Cards_Home");
            builder.OwnsOne(mr => mr.RedCardsA)
                .Property(rca => rca.Value)
                .HasColumnName("Red_Cards_Away");
            builder.OwnsOne(mr => mr.DirectRedCardsH)
                .Property(rdch => rdch.Value)
                .HasColumnName("Red_Direct_Card_Home");
            builder.OwnsOne(mr => mr.DirectRedCardsA)
                .Property(rdca => rdca.Value)
                .HasColumnName("Red_Direct_Card_Away");
        }
    }
}

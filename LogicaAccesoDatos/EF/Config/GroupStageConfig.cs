using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF.Config
{
    public class GroupStageConfig : IEntityTypeConfiguration<GroupStage>
    {
        public void Configure(EntityTypeBuilder<GroupStage> builder)
        {
            builder.OwnsOne(gs => gs.Group)
                .Property(g => g.Value)
                .HasColumnName("Group");
        }
    }
}

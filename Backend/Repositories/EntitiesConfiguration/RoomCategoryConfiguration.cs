using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class RoomCategoryConfiguration : IEntityTypeConfiguration<RoomCategory>
    {
        public void Configure(EntityTypeBuilder<RoomCategory> builder)
        {
            builder.ToTable("RoomCategory");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}

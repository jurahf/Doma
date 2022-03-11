using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class HotelOptionConfiguration : IEntityTypeConfiguration<HotelOption>
    {
        public void Configure(EntityTypeBuilder<HotelOption> builder)
        {
            builder.ToTable("HotelOption");
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

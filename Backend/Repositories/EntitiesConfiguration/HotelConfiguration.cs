using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotel");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Address)
                .HasMaxLength(1000);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Hotels)
                .HasForeignKey(x => x.CityId);

            builder.Property(x => x.Latitude)
                .HasColumnType("decimal(18,10)")
                .IsRequired();

            builder.Property(x => x.Longitude)
                .HasColumnType("decimal(18,10)")
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Stars)
                .IsRequired();
        }
    }
}

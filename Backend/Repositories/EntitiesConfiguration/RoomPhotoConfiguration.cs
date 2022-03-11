using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class RoomPhotoConfiguration : IEntityTypeConfiguration<RoomPhoto>
    {
        public void Configure(EntityTypeBuilder<RoomPhoto> builder)
        {
            builder.ToTable("RoomPhoto");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Title)
                .HasMaxLength(255);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Photos)
                .HasForeignKey(x => x.RoomId);
        }
    }
}

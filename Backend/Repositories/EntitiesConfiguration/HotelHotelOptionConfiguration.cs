using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class HotelHotelOptionConfiguration : IEntityTypeConfiguration<HotelHotelOption>
    {
        public void Configure(EntityTypeBuilder<HotelHotelOption> builder)
        {
            builder.ToTable("HotelHotelOption");
            builder.HasKey(e => new { e.HotelOptionId, e.HotelId });

            builder.HasOne(x => x.Hotel)
                .WithMany(x => x.HotelOptions)
                .HasForeignKey(x => x.HotelId);

            builder.HasOne(x => x.HotelOption)
                .WithMany(x => x.HotelHotelOptions)
                .HasForeignKey(x => x.HotelOptionId);
        }
    }
}

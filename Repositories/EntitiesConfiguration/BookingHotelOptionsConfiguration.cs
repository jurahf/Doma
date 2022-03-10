using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class BookingHotelOptionsConfiguration : IEntityTypeConfiguration<BookingHotelOption>
    {
        public void Configure(EntityTypeBuilder<BookingHotelOption> builder)
        {
            builder.ToTable("BookingHotelOption");
            builder.HasKey(e => new { e.BookingId, e.HotelOptionId });

            builder.HasOne(x => x.Booking)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.BookingId);

            builder.HasOne(x => x.HotelOption)
                .WithMany(x => x.BookingHotelOptions)
                .HasForeignKey(x => x.HotelOptionId);
        }
    }
}

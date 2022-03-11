using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
	internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
			builder.ToTable("Booking");
			builder.HasKey(e => e.Id);
			builder.Property(x => x.Id).HasColumnName(@"Id")
				.IsRequired()
				.HasColumnType("int")
				.UseIdentityColumn();

			builder.Property(x => x.StartDate).IsRequired();

			builder.Property(x => x.EndDate).IsRequired();

			builder.Property(x => x.ComingTime).IsRequired();

			builder.Property(x => x.Status).IsRequired();

			builder.HasOne(x => x.Client)
				.WithMany(x => x.Bookings)
				.HasForeignKey(x => x.UserId);

			builder.HasOne(x => x.Room)
				.WithMany(x => x.Bookings)
				.HasForeignKey(x => x.RoomId);

			builder.HasOne(x => x.Feedback)
				.WithOne(x => x.Booking)
				.HasForeignKey<Feedback>(x => x.BookingId);
		}
	}
}

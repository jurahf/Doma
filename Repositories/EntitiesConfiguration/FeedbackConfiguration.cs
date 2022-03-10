using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Text)
                .HasMaxLength(2000);

            builder.Property(x => x.Estimate);

            builder.Property(x => x.DateTime).IsRequired();

            //builder.HasOne(x => x.Booking)
            //    .WithOne(x => x.Feedback)
            //    .HasForeignKey<Booking>(x => x.FeedbackId);

            builder.HasOne(x => x.Hotel)
                .WithMany(x => x.Feedbacks)
                .HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

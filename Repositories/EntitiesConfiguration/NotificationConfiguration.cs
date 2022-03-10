using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(255);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.DateTime)
                .IsRequired();

            builder.HasOne(x => x.Reciver)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.UserId);
        }
    }
}

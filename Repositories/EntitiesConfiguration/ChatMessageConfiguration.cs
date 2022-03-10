using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ToTable("ChatMessage");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Text).HasMaxLength(2000);

            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.DateTime).IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.OutcomingMessages)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Reciver)
                .WithMany(x => x.IncomingMessages)
                .HasForeignKey(x => x.ReciverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class RoomCommodityConfiguration : IEntityTypeConfiguration<RoomCommodity>
    {
        public void Configure(EntityTypeBuilder<RoomCommodity> builder)
        {
            builder.HasKey(x => new { x.CommodityId, x.RoomId });

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Commodities)
                .HasForeignKey(x => x.RoomId);

            builder.HasOne(x => x.Commodity)
                .WithMany(x => x.RoomCommodities)
                .HasForeignKey(x => x.CommodityId);
        }
    }
}

using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Configuration
{
    public class DetailOrderConfiguration : IEntityTypeConfiguration<DetailOrder>
    {
        public void Configure(EntityTypeBuilder<DetailOrder> builder)
        {
            builder.ToTable("DetailOrder");
            builder.HasKey(x => x.DetailOrderId);
            builder.HasOne(x => x.SubProduct).WithMany(x => x.DetailOrders).HasForeignKey(x => x.SubProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Order).WithMany(x => x.DetailOrders).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

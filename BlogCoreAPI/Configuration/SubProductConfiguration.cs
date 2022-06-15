using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Configuration
{
    public class SubProductConfiguration : IEntityTypeConfiguration<SubProduct>
    {
        public void Configure(EntityTypeBuilder<SubProduct> builder)
        {
            builder.ToTable("SubProduct");
            builder.HasKey(x => x.SubProductId);
            builder.HasOne(x => x.Status).WithMany(x => x.SubProducts).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Product).WithMany(x => x.SubProducts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

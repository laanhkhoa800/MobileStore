using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ProductId);
            builder.HasOne(x => x.Style).WithMany(x => x.Products).HasForeignKey(x => x.StyleId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Description).HasMaxLength(20000);
            builder.Property(x => x.ImageMain).HasMaxLength(10000);
            builder.Property(x => x.ImageMain).HasMaxLength(10000);
            builder.Property(x => x.Image3).HasMaxLength(10000);
            builder.Property(x => x.Image3).HasMaxLength(10000);
            builder.Property(x => x.Image5).HasMaxLength(10000);
        }
    }
}

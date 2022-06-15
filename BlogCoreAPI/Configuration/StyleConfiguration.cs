using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Configuration
{
    public class StyleConfiguration : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            builder.ToTable("Style");
            builder.HasKey(x => x.StyleId);
        }
    }
}

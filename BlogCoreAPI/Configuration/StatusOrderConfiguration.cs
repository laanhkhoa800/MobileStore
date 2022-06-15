using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogCoreAPI.Configuration
{
    public class StatusOrderConfiguration : IEntityTypeConfiguration<StatusOrder>
    {
        public void Configure(EntityTypeBuilder<StatusOrder> builder)
        {
            builder.ToTable("StatusOrder");
            builder.HasKey(x => x.StatusOrderId);
        }
    }
}

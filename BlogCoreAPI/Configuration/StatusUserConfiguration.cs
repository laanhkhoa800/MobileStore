using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogCoreAPI.Configuration
{
    public class StatusUserConfiguration : IEntityTypeConfiguration<StatusUser>
    {
        public void Configure(EntityTypeBuilder<StatusUser> builder)
        {
            builder.ToTable("StatusUser");
            builder.HasKey(x => x.StatusUserId);
        }
    }
}

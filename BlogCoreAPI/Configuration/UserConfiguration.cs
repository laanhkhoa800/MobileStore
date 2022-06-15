using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserId);
            builder.HasOne(x => x.StatusUser).WithMany(x => x.Users).HasForeignKey(x => x.StatusUserId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Roles).HasMaxLength(20);


        }
    }
}

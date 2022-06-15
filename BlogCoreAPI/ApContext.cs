using BlogCoreAPI.Configuration;
using BlogCoreAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace BlogCoreAPI
{
    public class ApContext : DbContext
    {
        public ApContext(DbContextOptions<ApContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Style> styles { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<SubProduct> subProducts { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<DetailOrder> detailOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SubProductConfiguration());
            modelBuilder.ApplyConfiguration(new DetailOrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new StyleConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            /*           modelBuilder.Entity<Status>().HasKey(s => s.StatusId);
                       modelBuilder.Entity<Style>().HasKey(s => s.StyleId);*/
            /*modelBuilder.Entity<Order>().HasKey(s => s.OrderId);*/
            //modelBuilder.Entity<DetailOrder>().HasKey(s => s.DetailOrderId);
            /*modelBuilder.Entity<User>()
            .HasKey(ca => new { ca.UserId, ca.StatusId });
            modelBuilder.Entity<Product>()
            .HasKey(ca => new { ca.ProductId, ca.StyleId });
            modelBuilder.Entity<SubProduct>()
            .HasKey(ca => new { ca.SubProductId, ca.ProductId, ca.StatusId });
            modelBuilder.Entity<Order>()    
            .HasKey(ca => new { ca.OrderId, ca.StatusId,ca.UserId });
            modelBuilder.Entity<DetailOrder>()
            .HasKey(ca => new { ca.DetailOrderId, ca.SubProductId, ca.OrderId });

            *//*modelBuilder.Entity<Product>()
            .HasOne(c => c.SubProducts)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);*//*
            modelBuilder.Entity<Product>()
            .HasOne(c => c.Style)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
            .HasOne(c => c.User)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
            .HasOne(c => c.Status)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);*/
            /*  modelBuilder.Entity<Order>()
              .HasOne(c => c.DetailOrders)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);*/

            /*modelBuilder.Entity<Status>()
            .HasOne(c => c.Users)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);*/
            /*modelBuilder.Entity<Status>()
            .HasOne(c => c.SubProducts)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);*/


            /*modelBuilder.Entity<SubProduct>()
            .HasOne(c => c.Product)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SubProduct>()
            .HasOne(c => c.Status)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<DetailOrder>()
            .HasOne(c => c.Order)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DetailOrder>()
            .HasOne(c => c.SubProduct)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);*/


        }
    }
}

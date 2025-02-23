using Microsoft.EntityFrameworkCore;
using Mongo.Services.CouponAPI.Models;

namespace Mongo.Services.CouponAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                CouponId = 1,
                CouponCode = "OFF5",
                DiscountAmount = 5,
                MinAmount = 10
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon() 
            { 
                CouponId = 2, 
                CouponCode = "OFF10", 
                DiscountAmount = 10, 
                MinAmount = 20
            });
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobilesShop.Data.Models;

namespace MobilesShop.Data
{
    public class MobilesShopDbContext : IdentityDbContext
    {
        public MobilesShopDbContext(DbContextOptions<MobilesShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; init; }

        public DbSet<CameraType> CameraTypes { get; init; }

        public DbSet<Chipset> Chipsets { get; init; }

        public DbSet<Display> Displays { get; set; }

        public DbSet<MobilePhone> MobilePhones { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<MobilePhone>()
                .HasOne(b => b.Brand)
                .WithMany(b => b.MobilePhones)
                .HasForeignKey(b => b.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<MobilePhone>()
                .HasOne(c => c.CameraType)
                .WithMany(c => c.MobilePhones)
                .HasForeignKey(c => c.CameraTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<MobilePhone>()
                .HasOne(ch => ch.Chipset)
                .WithMany(ch => ch.MobilePhones)
                .HasForeignKey(ch => ch.ChipsetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<MobilePhone>()
                .HasOne(d => d.Display)
                .WithMany(d => d.MobilePhones)
                .HasForeignKey(d => d.DisplayId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

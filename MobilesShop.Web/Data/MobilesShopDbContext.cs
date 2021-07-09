using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobilesShop.Web.Data.Models;

namespace MobilesShop.Web.Data
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
        public DbSet<DisplaySize> DisplaySizes { get; init; }
        public DbSet<DisplayType> DisplayTypes { get; init; }
        public DbSet<MobilePhone> MobilePhones { get; init; }
    }
}

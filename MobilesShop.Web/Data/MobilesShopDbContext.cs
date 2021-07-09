using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MobilesShop.Web.Data
{
    public class MobilesShopDbContext : IdentityDbContext
    {
        public MobilesShopDbContext(DbContextOptions<MobilesShopDbContext> options)
            : base(options)
        {
        }
    }
}

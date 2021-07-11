using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using System.Linq;

namespace MobilesShop.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<MobilesShopDbContext>();

            data.Database.Migrate();

            SeedBrands(data);
            SeedCameraTypes(data);
            SeedChipsets(data);
            SeedDisplaySizes(data);
            SeedDisplayTypes(data);

            return app;
        }

        private static void SeedBrands(MobilesShopDbContext data)
        {
            if (data.Brands.Any())
            {
                return;
            }

            data.Brands.AddRange(new[]
            {
                new Brand { Name = "Samsung" },
                new Brand { Name = "Apple" },
                new Brand { Name = "Huawei" },
                new Brand { Name = "Sony" },
                new Brand { Name = "Nokia" },
                new Brand { Name = "Google" },
                new Brand { Name = "Motorola" },
                new Brand { Name = "Xiaomi" },
                new Brand { Name = "Lenovo" },
                new Brand { Name = "Oppo" },
            });

            data.SaveChanges();
        }

        private static void SeedCameraTypes(MobilesShopDbContext data)
        {
            if (data.CameraTypes.Any())
            {
                return;
            }

            data.CameraTypes.AddRange(new[]
            {
                new CameraType { Name = "Single" },
                new CameraType { Name = "Double" },
                new CameraType { Name = "Tripple" },
                new CameraType { Name = "Quad" },
            });

            data.SaveChanges();
        }

        private static void SeedChipsets(MobilesShopDbContext data)
        {
            if (data.Chipsets.Any())
            {
                return;
            }
               
            data.Chipsets.AddRange(new[] 
            {
                new Chipset { Name = "A14 Bionic", Cores = 6, Clock = 2990 },
                new Chipset { Name = "Snapdragon 888", Cores = 8, Clock = 2840 },
                new Chipset { Name = "Exynos 2100", Cores = 8, Clock = 2900 },
                new Chipset { Name = "Kirin 9000", Cores = 8, Clock = 3130 },
                new Chipset { Name = "Exynos 1080", Cores = 8, Clock = 2800 },
                new Chipset { Name = "Dimensity 1100", Cores = 8, Clock = 2600 },
                new Chipset { Name = "Snapdragon 855", Cores = 8, Clock = 2960  },
                new Chipset { Name = "Snapdragon 801", Cores = 4, Clock = 2500},
                new Chipset { Name = "Exynos 7570", Cores = 4, Clock = 1400 },
                new Chipset { Name = "MediaTek MT6739", Cores = 4, Clock = 1500 },
            });

            data.SaveChanges();
        }

        private static void SeedDisplaySizes(MobilesShopDbContext data)
        {
            if (data.DisplaySizes.Any())
            {
                return;
            }

            data.DisplaySizes.AddRange(new[] 
            {
                new DisplaySize { Name = "4.0\"" },
                new DisplaySize { Name = "4.7\"" },
                new DisplaySize { Name = "5.0\"" },
                new DisplaySize { Name = "5.1\"" },
                new DisplaySize { Name = "5.2\"" },
                new DisplaySize { Name = "5.5\"" },
                new DisplaySize { Name = "5.7\"" },
                new DisplaySize { Name = "5.8\"" },
                new DisplaySize { Name = "6.0\"" },
                new DisplaySize { Name = "6.2\"" },
            });

            data.SaveChanges();
        }

        private static void SeedDisplayTypes(MobilesShopDbContext data)
        {
            if (data.DisplayTypes.Any())
            {
                return;
            }

            data.DisplayTypes.AddRange(new[] 
            {
                new DisplayType { Name = "IPS-LCD" },
                new DisplayType { Name = "IPS" },
                new DisplayType { Name = "TFT" },
                new DisplayType { Name = "AMOLED" },
                new DisplayType { Name = "Super AMOLED" },
                new DisplayType { Name = "OLED" },
                new DisplayType { Name = "LCD" },
            });

            data.SaveChanges();
        }
    }
}
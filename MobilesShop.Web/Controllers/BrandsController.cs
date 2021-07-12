using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using MobilesShop.Web.Models.Brands;
using System.Linq;

namespace MobilesShop.Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly MobilesShopDbContext data;

        public BrandsController(MobilesShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(BrandAddFormModel brand)
        {
            if (this.data.Brands.Any(b => b.Name == brand.Name))
            {
                this.ModelState.AddModelError(nameof(brand.Name), "Brand already exists!");
            }
            
            if (!this.ModelState.IsValid)
            {
                return View(brand);
            }

            var brandData = new Brand { Name = brand.Name };

            this.data.Brands.Add(brandData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using MobilesShop.Web.Models.DisplaySizes;
using System.Linq;

namespace MobilesShop.Web.Controllers
{
    public class DisplaySizesController : Controller
    {
        private readonly MobilesShopDbContext data;

        public DisplaySizesController(MobilesShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(DisplaySizeAddFormModel displaySize)
        {
            if (this.data.DisplaySizes.Any(d => d.Name == displaySize.Name))
            {
                this.ModelState.AddModelError(nameof(displaySize.Name), "Size already exists!");
            }
            
            if (!this.ModelState.IsValid)
            {
                return View(displaySize);
            }

            var displaySizeData = new DisplaySize { Name = displaySize.Name };

            this.data.DisplaySizes.Add(displaySizeData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}

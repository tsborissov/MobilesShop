using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using MobilesShop.Web.Models.Chipsets;
using System.Linq;

namespace MobilesShop.Web.Controllers
{
    public class ChipsetsController : Controller
    {
        private readonly MobilesShopDbContext data;

        public ChipsetsController(MobilesShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(ChipsetAddFormModel chipset)
        {
            if (this.data.Chipsets.Any(c => 
                c.Name == chipset.Name 
                && c.Cores == chipset.Cores
                && c.Clock == chipset.Clock))
            {
                this.ModelState.AddModelError(nameof(chipset.Name), "Chipset already exists!");
            }
            
            if (!this.ModelState.IsValid)
            {
                return View(chipset);
            }

            var chipsetData = new Chipset 
            {
                Name = chipset.Name,
                Cores = chipset.Cores,
                Clock = chipset.Clock
            };

            this.data.Chipsets.Add(chipsetData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}

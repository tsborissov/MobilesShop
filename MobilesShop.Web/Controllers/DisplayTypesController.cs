using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using MobilesShop.Web.Models.DisplayTypes;
using System.Linq;

namespace MobilesShop.Web.Controllers
{
    public class DisplayTypesController : Controller
    {
        private readonly MobilesShopDbContext data;

        public DisplayTypesController(MobilesShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(DisplayTypeAddFormModel displayType)
        {
            if (this.data.DisplayTypes.Any(d => d.Name == displayType.Name))
            {
                this.ModelState.AddModelError(nameof(displayType.Name),"Display Type already exists!");
            }
            
            if (!this.ModelState.IsValid)
            {
                return View(displayType);
            }

            var displayTypeData = new DisplayType { Name = displayType.Name };

            this.data.DisplayTypes.Add(displayTypeData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}

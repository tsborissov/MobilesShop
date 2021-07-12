using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using MobilesShop.Web.Models.CameraTypes;
using System.Linq;

namespace MobilesShop.Web.Controllers
{
    public class CameraTypesController : Controller
    {
        private readonly MobilesShopDbContext data;

        public CameraTypesController(MobilesShopDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(CameraTypeAddFormModel cameraType)
        {
            if (this.data.CameraTypes.Any(c => c.Name == cameraType.Name))
            {
                this.ModelState.AddModelError(nameof(cameraType.Name), "This Camera Type already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return View(cameraType);
            }

            var cameraTypeData = new CameraType { Name = cameraType.Name };

            this.data.CameraTypes.Add(cameraTypeData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}

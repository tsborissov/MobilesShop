using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
using MobilesShop.Data.Models;
using MobilesShop.Web.Models.MobilePhones;
using System.Collections.Generic;
using System.Linq;

namespace MobilesShop.Web.Controllers
{
    public class MobilePhonesController : Controller
    {
        private readonly MobilesShopDbContext data;

        public MobilePhonesController(MobilesShopDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Add() => View(new MobilePhoneAddFormModel
        {
            Brands = this.GetMobilePhonesBrands(),
            CameraTypes = this.GetCameraType(),
            Chipsets = this.GetChipset(),
            DisplayTypes = this.GetDisplayType(),
            DisplaySizes = this.GetDisplaySize()
        });

        [Authorize]
        [HttpPost]
        public IActionResult Add(MobilePhoneAddFormModel mobile)
        {
            if (!this.data.Brands.Any(b => b.Id == mobile.BrandId))
            {
                this.ModelState.AddModelError(nameof(mobile.BrandId), "Brand does not exist!");
            }

            if (!this.data.CameraTypes.Any(c => c.Id == mobile.CameraTypeId))
            {
                this.ModelState.AddModelError(nameof(mobile.CameraTypeId), "Camera Type does not exist!");
            }

            if (!this.data.Chipsets.Any(c => c.Id == mobile.ChipsetId))
            {
                this.ModelState.AddModelError(nameof(mobile.ChipsetId), "Chipset does not exist!");
            }

            if (!this.data.DisplayTypes.Any(d => d.Id == mobile.DisplayTypeId))
            {
                this.ModelState.AddModelError(nameof(mobile.DisplayTypeId), "Display Type does not exist!");
            }

            if (!this.data.DisplaySizes.Any(d => d.Id == mobile.DisplaySizeId))
            {
                this.ModelState.AddModelError(nameof(mobile.DisplaySizeId), "Display Size does not exist!");
            }

            if (!ModelState.IsValid)
            {
                mobile.Brands = this.GetMobilePhonesBrands();
                mobile.CameraTypes = this.GetCameraType();
                mobile.Chipsets = this.GetChipset();
                mobile.DisplayTypes = this.GetDisplayType();
                mobile.DisplaySizes = this.GetDisplaySize();

                return View(mobile);
            }

            var mobilePhone = new MobilePhone
            {
                BrandId = mobile.BrandId,
                Model = mobile.Model,
                Year = mobile.Year,
                ChipsetId = mobile.ChipsetId,
                DisplayTypeId = mobile.DisplayTypeId,
                DisplaySizeId = mobile.DisplaySizeId,
                Memory = mobile.Memory,
                Storage = mobile.Storage,
                CameraTypeId = mobile.CameraTypeId,
                Battery = mobile.Battery,
                Connectivity = mobile.Connectivity,
                IsDualSim = mobile.IsDualSim,
                Weight = mobile.Weight,
                ImageUrl = mobile.ImageUrl,
                Details = mobile.Details,
                Price = mobile.Price
            };

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<BrandViewModel> GetMobilePhonesBrands()
            => this.data
                .Brands
                .OrderBy(b => b.Name)
                .Select(b => new BrandViewModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

        private IEnumerable<CameraTypeViewModel> GetCameraType()
            => this.data
                .CameraTypes
                .OrderBy(c => c.Name)
                .Select(c => new CameraTypeViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        private IEnumerable<ChipsetViewModel> GetChipset()
            => this.data
                .Chipsets
                .OrderBy(c => c.Name)
                .Select(c => new ChipsetViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        private IEnumerable<DisplayTypeViewModel> GetDisplayType()
            => this.data
                .DisplayTypes
                .OrderBy(d => d.Name)
                .Select(d => new DisplayTypeViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToList();

        private IEnumerable<DisplaySizeViewModel> GetDisplaySize()
            => this.data
                .DisplaySizes
                .OrderBy(d => d.Name)
                .Select(d => new DisplaySizeViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToList();
    }
}

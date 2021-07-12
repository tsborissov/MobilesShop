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
        public IActionResult Add(MobilePhoneAddFormModel mobilePhone)
        {
            if (!this.data.Brands.Any(b => b.Id == mobilePhone.BrandId))
            {
                this.ModelState.AddModelError(nameof(mobilePhone.BrandId), "Brand does not exist!");
            }

            if (!this.data.CameraTypes.Any(c => c.Id == mobilePhone.CameraTypeId))
            {
                this.ModelState.AddModelError(nameof(mobilePhone.CameraTypeId), "Camera Type does not exist!");
            }

            if (!this.data.Chipsets.Any(c => c.Id == mobilePhone.ChipsetId))
            {
                this.ModelState.AddModelError(nameof(mobilePhone.ChipsetId), "Chipset does not exist!");
            }

            if (!this.data.DisplayTypes.Any(d => d.Id == mobilePhone.DisplayTypeId))
            {
                this.ModelState.AddModelError(nameof(mobilePhone.DisplayTypeId), "Display Type does not exist!");
            }

            if (!this.data.DisplaySizes.Any(d => d.Id == mobilePhone.DisplaySizeId))
            {
                this.ModelState.AddModelError(nameof(mobilePhone.DisplaySizeId), "Display Size does not exist!");
            }

            if (!ModelState.IsValid)
            {
                mobilePhone.Brands = this.GetMobilePhonesBrands();
                mobilePhone.CameraTypes = this.GetCameraType();
                mobilePhone.Chipsets = this.GetChipset();
                mobilePhone.DisplayTypes = this.GetDisplayType();
                mobilePhone.DisplaySizes = this.GetDisplaySize();

                return View(mobilePhone);
            }

            var mobilePhoneData = new MobilePhone
            {
                BrandId = mobilePhone.BrandId,
                Model = mobilePhone.Model,
                Year = mobilePhone.Year,
                ChipsetId = mobilePhone.ChipsetId,
                DisplayTypeId = mobilePhone.DisplayTypeId,
                DisplaySizeId = mobilePhone.DisplaySizeId,
                Memory = mobilePhone.Memory,
                Storage = mobilePhone.Storage,
                CameraTypeId = mobilePhone.CameraTypeId,
                Battery = mobilePhone.Battery,
                Connectivity = mobilePhone.Connectivity,
                IsDualSim = mobilePhone.IsDualSim,
                Weight = mobilePhone.Weight,
                ImageUrl = mobilePhone.ImageUrl,
                Details = mobilePhone.Details,
                Price = mobilePhone.Price
            };

            this.data.MobilePhones.Add(mobilePhoneData);

            this.data.SaveChanges();

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

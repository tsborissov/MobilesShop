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
            Displays = this.GetDisplay(),
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

            if (!ModelState.IsValid)
            {
                mobilePhone.Brands = this.GetMobilePhonesBrands();
                mobilePhone.CameraTypes = this.GetCameraType();
                mobilePhone.Chipsets = this.GetChipset();
                mobilePhone.Displays = this.GetDisplay();

                return View(mobilePhone);
            }

            var mobilePhoneData = new MobilePhone
            {
                BrandId = mobilePhone.BrandId,
                Model = mobilePhone.Model,
                Year = mobilePhone.Year,
                ChipsetId = mobilePhone.ChipsetId,
                DisplayId = mobilePhone.DisplayId,
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

        private IEnumerable<BrandDropdownViewModel> GetMobilePhonesBrands()
            => this.data
                .Brands
                .OrderBy(b => b.Name)
                .Select(b => new BrandDropdownViewModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

        private IEnumerable<CameraTypeDropdownViewModel> GetCameraType()
            => this.data
                .CameraTypes
                .OrderBy(c => c.Name)
                .Select(c => new CameraTypeDropdownViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        private IEnumerable<ChipsetDropdownViewModel> GetChipset()
            => this.data
                .Chipsets
                .OrderBy(c => c.Name)
                .Select(c => new ChipsetDropdownViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        private IEnumerable<DisplayDropdownViewModel> GetDisplay()
            => this.data
                .Displays
                .OrderBy(d => d.Name)
                .Select(d => new DisplayDropdownViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToList();
    }
}

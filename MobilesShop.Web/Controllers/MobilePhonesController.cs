using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilesShop.Data;
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

            return View();
        }

        private IEnumerable<MobilePhoneBrandViewModel> GetMobilePhonesBrands()
            => this.data
                .Brands
                .OrderBy(b => b.Name)
                .Select(b => new MobilePhoneBrandViewModel
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

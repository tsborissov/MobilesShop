using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Web.Models.MobilePhones
{
    public class MobilePhoneAddFormModel
    {
        [Display(Name = "Brand")]
        public int BrandId { get; init; }

        [BindNever]
        public IEnumerable<BrandDropdownViewModel> Brands { get; set; }

        [Required]
        [StringLength(
            MobilePhoneModelMaxLength, 
            MinimumLength = MobilePhoneModelMinLength, 
            ErrorMessage = "{2} to {1} characters required.")]
        public string Model { get; init; }

        [Range(MobilePhoneMinYearValue, MobilePhoneMaxYearValue)]
        public int Year { get; init; }

        [Display(Name = "Chipset")]
        public int ChipsetId { get; init; }

        [BindNever]
        public IEnumerable<ChipsetDropdownViewModel> Chipsets { get; set; }

        [Display(Name = "Display")]
        public int DisplayId { get; init; }

        [BindNever]
        public IEnumerable<DisplayDropdownViewModel> Displays { get; set; }

        [Display(Name = "Camera Type")]
        public int CameraTypeId { get; init; }

        [BindNever]
        public IEnumerable<CameraTypeDropdownViewModel> CameraTypes { get; set; }

        [Range(MobilePhoneMemoryMinValue, MobilePhoneMemoryMaxValue)]
        public int Memory { get; init; }

        [Range(MobilePhoneStorageMinValue, MobilePhoneStorageMaxValue)]
        public int Storage { get; init; }

        [Range(MobilePhoneBatteryMinValue, MobilePhoneBatteryMaxValue)]
        public int Battery { get; init; }

        [Required]
        [StringLength(MobilePhoneConnectivityMaxLength, MinimumLength = MobilePhoneConnectivityMinLength)]
        public string Connectivity { get; init; }

        [Display(Name = "Dual SIM")]
        public bool IsDualSim { get; init; }

        [Range(MobilePhoneWeightMinValue, MobilePhoneWeightMaxValue)]
        public int Weight { get; init; }

        [Url]
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(MobilePhoneDetailsMaxLength, MinimumLength = MobilePhoneDetailsMinLength)]
        public string Details { get; init; }

        [Range(MobilePhonePriceMinValue, MobilePhonePriceMaxValue)]
        public decimal Price { get; init; }
    }
}

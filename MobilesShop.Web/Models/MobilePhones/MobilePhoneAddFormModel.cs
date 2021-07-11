using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Web.Models.MobilePhones
{
    public class MobilePhoneAddFormModel
    {
        [Display(Name = "Brand")]
        public int BrandId { get; init; }

        public IEnumerable<MobilePhoneBrandViewModel> Brands { get; set; }

        [Required]
        [StringLength(MobilePhoneModelMaxLength, MinimumLength = MobilePhoneModelMinLength)]
        public string Model { get; init; }

        [Range(MobilePhoneMinYearValue, MobilePhoneMaxYearValue)]
        public int Year { get; init; }

        [Display(Name = "Chipset")]
        public int ChipsetId { get; init; }

        public IEnumerable<ChipsetViewModel> Chipsets { get; set; }

        [Display(Name = "Display Type")]
        public int DisplayTypeId { get; init; }

        public IEnumerable<DisplayTypeViewModel> DisplayTypes { get; set; }

        [Display(Name = "Display Size")]
        public int DisplaySizeId { get; init; }

        public IEnumerable<DisplaySizeViewModel> DisplaySizes { get; set; }

        [Display(Name = "Camera Type")]
        public int CameraTypeId { get; init; }

        public IEnumerable<CameraTypeViewModel> CameraTypes { get; set; }

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
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(MobilePhoneDetailsMaxLength, MinimumLength = MobilePhoneDetailsMinLength)]
        public string Details { get; init; }

        [Range(MobilePhonePriceMinValue, MobilePhonePriceMaxValue)]
        public decimal Price { get; init; }
    }
}

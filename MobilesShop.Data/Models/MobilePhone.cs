using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Data.Models
{
    public class MobilePhone
    {
        public int Id { get; init; }

        public int BrandId { get; set; }

        public Brand Brand { get; init; }

        [Required]
        [MaxLength(MobilePhoneModelMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        public int ChipsetId { get; set; }

        public Chipset Chipset { get; init; }

        public int DisplayTypeId { get; set; }

        public DisplayType DisplayType { get; init; }

        public int DisplaySizeId { get; set; }

        public DisplaySize DisplaySize { get; init; }

        public int Memory { get; set; }

        public int Storage { get; set; }

        public int CameraTypeId { get; set; }

        public CameraType CameraType { get; init; }

        public int Battery { get; set; }

        public string Connectivity { get; set; }

        public bool IsDualSim { get; set; }

        public int Weight { get; set; }

        [Required]
        [MaxLength(MobilePhoneImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MobilePhoneDetailsMaxLength)]
        public string Details { get; set; }

        public decimal Price { get; set; }
    }
}

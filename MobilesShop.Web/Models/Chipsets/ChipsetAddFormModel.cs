using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Web.Models.Chipsets
{
    public class ChipsetAddFormModel
    {
        [Required]
        [StringLength(ChipsetNameMaxLength, MinimumLength = ChipsetNameMinLength)]
        public string Name { get; init; }

        [Range(ChipsetCoresMinValue, ChipsetCoresMaxValue)]
        public int Cores { get; init; }

        [Range(ChipsetClockMinValue, ChipsetClockMaxValue)]
        public int Clock { get; init; }
    }
}


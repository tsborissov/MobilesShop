using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Web.Models.DisplaySizes
{
    public class DisplaySizeAddFormModel
    {
        [Required]
        [StringLength(DisplaySizeNameMaxLength, MinimumLength = DisplaySizeNameMinLength)]
        public string Name { get; set; }
    }
}

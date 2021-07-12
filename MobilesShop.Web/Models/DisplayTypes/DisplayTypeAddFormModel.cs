using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Web.Models.DisplayTypes
{
    public class DisplayTypeAddFormModel
    {
        [Required]
        [StringLength(DisplayTypeNameMaxLength, MinimumLength = DisplayTypeNameMinLength)]
        public string Name { get; set; }
    }
}

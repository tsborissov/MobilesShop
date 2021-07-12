using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Web.Models.CameraTypes
{
    public class CameraTypeAddFormModel
    {
        [Required]
        [StringLength(CameraTypeNameMaxLength, MinimumLength = CameraTypeNameMinLength)]
        public string Name { get; init; }
    }
}

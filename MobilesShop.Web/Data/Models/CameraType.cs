using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Web.Data.DataConstants;

namespace MobilesShop.Web.Data.Models
{
    public class CameraType
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CameraTypeNameMaxLength)]
        public string Name { get; set; }

        public ICollection<MobilePhone> MobilePhones { get; init; } = new HashSet<MobilePhone>();
    }
}

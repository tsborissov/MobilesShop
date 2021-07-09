using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MobilesShop.Web.Data.DataConstants;

namespace MobilesShop.Web.Data.Models
{
    public class Brand
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(BrandNameMaxLength)]
        public string Name { get; set; }

        public ICollection<MobilePhone> Mobiles { get; init; } = new HashSet<MobilePhone>();
    }
}
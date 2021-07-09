using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Web.Data.DataConstants;

namespace MobilesShop.Web.Data.Models
{
    public class DisplayType
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DisplayTypeNameMaxLength)]
        public string Name { get; set; }

        public ICollection<MobilePhone> MobilePhones { get; init; } = new HashSet<MobilePhone>();
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Data.Models
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

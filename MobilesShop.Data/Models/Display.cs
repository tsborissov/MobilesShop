using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Data.Models
{
    public class Display
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DisplayNameMaxLength)]
        public string Name { get; set; }

        public double Size { get; set; }

        [Required]
        [MaxLength(DisplayResolutionMaxLength)]
        public string Resolution { get; set; }

        [Required]
        [MaxLength(DisplayProtectionMaxLength)]
        public string Protection { get; set; }

        public ICollection<MobilePhone> MobilePhones { get; init; } = new HashSet<MobilePhone>();
    }
}

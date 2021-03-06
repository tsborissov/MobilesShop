using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MobilesShop.Data.DataConstants;

namespace MobilesShop.Data.Models
{
    public class Chipset
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ChipsetNameMaxLength)]
        public string Name { get; set; }

        public int Cores { get; set; }

        public int Clock { get; set; }

        public ICollection<MobilePhone> MobilePhones { get; init; } = new HashSet<MobilePhone>();
    }
}

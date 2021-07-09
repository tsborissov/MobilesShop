using System.Collections.Generic;

namespace MobilesShop.Data.Models
{
    public class DisplaySize
    {
        public int Id { get; init; }

        public double Size { get; set; }

        public ICollection<MobilePhone> MobilePhones { get; init; } = new HashSet<MobilePhone>();
    }
}

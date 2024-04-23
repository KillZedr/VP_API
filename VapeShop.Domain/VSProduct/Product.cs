using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class Product : Entity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string PicturePath { get; set; }

        public virtual ICollection<PriceChange> PriceChanges { get; set; } = new List<PriceChange>();

        public virtual Category? Category { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
    }
}

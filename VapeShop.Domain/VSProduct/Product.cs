using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int? ManufacturerId { get; set; }

        public int? CategoryId { get; set; }

        public virtual ICollection<PriceChange> PriceChanges { get; set; } = new List<PriceChange>();

        public virtual Category? Category { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
    }
}

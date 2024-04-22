using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class Manufacturer
    {
        public required int ManufacturerId { get; set; }

        public required string ManufacturerName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

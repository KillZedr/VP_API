using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class Category
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

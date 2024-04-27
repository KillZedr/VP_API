using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;

namespace VapeShop.Domain.VSProduct
{
    public class Category : Entity<int>
    {

        public string Name { get; set; } = null! ;
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}

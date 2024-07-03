using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop.Domain.ECommerce
{
    public class PurchaseItem : Entity<int>
    {
  
        
        public int ProductCount { get; set; }

        public decimal ProductPrice { get; set; }

        public required Product Product { get; set; } = null!;

        public required Purchase Purchase { get; set; } = null!;
    }
}

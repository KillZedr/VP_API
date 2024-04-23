using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class PriceChange : Entity<int> 
    {

        public DateTime DatePriceChange { get; set; }

        public decimal NewPrice { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}

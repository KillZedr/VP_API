
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;
using VapeShop.Domain.VSProduct;
using static System.Formats.Asn1.AsnWriter;

namespace VapeShop.Domain.ECommerce
{
    public class Order : Entity<int>
    {

        

        public required DateOnly DeliveryDate { get; set; }
        public decimal ProductCount { get; set; }
        public required Product Product { get; set; } = null!;
        public required OrderStatus Status { get; set; }

        /*public virtual required ICollection<Product> Products { get; set;}
        */

        
    }
}

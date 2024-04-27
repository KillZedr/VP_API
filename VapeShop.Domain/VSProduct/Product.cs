using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.ECommerce;

namespace VapeShop.Domain.VSProduct
{
    public class Product : Entity<int>
    {
        public required int CategoryId { get; set; }
        public required int ManufacturerId { get; set; }


        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string PicturePath { get; set; }

        public virtual required PriceChange? PriceChanges { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }

        /* public virtual required ICollection<Category> Categories { get; set; }
         public virtual required ICollection<Manufacturer> Manufacturers { get; set; }*/


        /*public virtual required ICollection<Order>? Order { get; set; }*/
        /*public virtual required ICollection<PurchaseItem>? PurchaseItems { get; set; }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;

namespace VapeShop.Domain.ECommerce
{
    public class Basket : Entity<int>
    {
        public required int? UserId { get; set; }
        public virtual required User? User { get; set; }
        public virtual required IEnumerable<ProductInBasket> ProductInBasket { get; set; } = new List<ProductInBasket>();   
        /*public virtual required Purchase Purchase { get; set; }*/
        /*public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }*/
        /*public required string Source { get; set; }
        public required string MetaData { get; set; }*/
    }
}

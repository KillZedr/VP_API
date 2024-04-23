using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.ECommerce
{
    public class Payment : Entity<int>
    {
        public virtual ICollection<Purchase> PurchaseProduct { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }
        public required string Source { get; set; }
        public required string MetaData { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.ECommerce
{
    public class HistoryOfOrders
    {
        public int HistoryOfOrdersId { get; set; }

        public string HistoryOfOrdersName { get; set; } = null!;

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}

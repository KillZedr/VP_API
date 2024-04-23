using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.ECommerce
{
    public class HistoryOfOrders : Entity<int>
    {
       

        public  DateTime HistoryOfOrdersDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

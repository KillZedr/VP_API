using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.ECommerce
{
    public class Payment
    {
        public required Delivery Delivery { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }
        public required string Source { get; set; }
        public required string MetaData { get; set; }
    }
}

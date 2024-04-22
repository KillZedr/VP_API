
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;
using static System.Formats.Asn1.AsnWriter;

namespace VapeShop.Domain.ECommerce
{
    public class Delivery
    {
        public required int ProductId { get; set; }

        public required int? StoreId { get; set; }

        public required DateOnly DeliveryDate { get; set; }

        public required decimal ProductCount { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual HistoryOfOrders? Store { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.ECommerce
{
    public enum DeliveryStatus
    {
        Placed = 1,
        Paid = 2,
        Confirmed = 3,
        InProgress = 4,
        Ready = 5,
        Complete = 6,
        Aborted = 7,
        Refunded = 8,
    }
}

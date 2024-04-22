using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;


namespace VapeShop.Domain.ECommerce
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public int UsersId { get; set; }

        public int HistoryOfOrdersId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

        public virtual HistoryOfOrders HistoryOfOrders { get; set; } = null!;

        public virtual User Users { get; set; } = null!;
    }
}

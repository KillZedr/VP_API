using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;
using VapeShop.Domain.VSProduct;


namespace VapeShop.Domain.ECommerce
{
    public class Purchase : IEntityWithOwnId
    {
        public DateTime PurchaseDate { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        public virtual User Users { get; set; } = null!;
    }
}

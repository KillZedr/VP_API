using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.VSProduct
{
    public class PriceChange
    {
        public int ProductId { get; set; }

        public DateTime DatePriceChange { get; set; }

        public decimal NewPrice { get; set; }

        public virtual ICollection<PriceChange> PriceChanges { get; set; } = new List<PriceChange>();
        public virtual Product Product { get; set; } = null!;
    }
}

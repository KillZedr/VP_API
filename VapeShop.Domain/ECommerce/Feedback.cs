using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop.Domain.ECommerce
{
    public class Feedback : Entity<int>
    {
        public required Order Order { get; set; }
        public required Product Product { get; set; }
        public required int Rating { get; set; }
        public required string Message { get; set; }
        public required string PicturePath { get; set; }
        public required string ManagerComment { get; set; }
    }
}

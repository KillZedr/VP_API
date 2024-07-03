using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.ECommerce;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations.ECommerce
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            /*builder.HasOne(pur => pur)*/
            builder.HasOne(u => u.Users).WithMany(pur => pur.Purchases);
            
        }
    }
}

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
    public class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseItem> builder)
        {
            builder.HasOne(p => p.Product).WithMany(pri => pri.PurchaseItems);
            builder.HasOne(p => p.Purchase).WithMany(pi => pi.PurchaseItems);
        }
    }
}

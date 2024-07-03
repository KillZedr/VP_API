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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(pay => pay.Purchase).WithOne(pur => pur.Payment).HasForeignKey<Payment>(pay => pay.PurchaseId);
        }
    }
}

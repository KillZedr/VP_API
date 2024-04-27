using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations.VSProduct
{
    public class PriceChangeConfigurations : IEntityTypeConfiguration<PriceChange>
    {
        public void Configure(EntityTypeBuilder<PriceChange> builder)
        {
            
            builder.HasOne<Product>().WithOne(pc => pc.PriceChanges)
                .HasForeignKey<Product>(pPC => pPC.Id);
        }
    }
}

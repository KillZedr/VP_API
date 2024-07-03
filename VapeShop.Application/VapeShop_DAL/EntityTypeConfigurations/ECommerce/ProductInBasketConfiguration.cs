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
    public class ProductInBasketConfiguration : IEntityTypeConfiguration<ProductInBasket>
    {
        public void Configure(EntityTypeBuilder<ProductInBasket> builder)
        {
            builder.HasOne(pib => pib.Product).WithMany(prod => prod.Baskets);
            builder.HasOne(pib => pib.Basket).WithMany(b => b.ProductInBasket);
        }
    }
}

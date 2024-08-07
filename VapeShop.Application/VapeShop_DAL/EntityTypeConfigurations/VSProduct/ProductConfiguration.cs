﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations.VSProduct
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            /*builder.HasKey(prod => new { prod.CategoryId, prod.ManufacturerId });*/
            builder.HasOne(c => c.Category)
                .WithMany(c => c.Products);
            builder.HasOne(m => m.Manufacturer)
                .WithMany(m => m.Products);
          /*  builder.HasMany((prc => prc.PriceChanges)
                .WithMany(prc => prc.ProductItem).HasForeignKey(prc => prc.PriceChangeId);*/
            /*builder.HasOne<PriceChange>().WithOne(pc => pc.ProductItem);*/
        }
    }
}

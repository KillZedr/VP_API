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
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasOne<Product>()
               .WithOne(product => product.Manufacturer);
        }
    }
}

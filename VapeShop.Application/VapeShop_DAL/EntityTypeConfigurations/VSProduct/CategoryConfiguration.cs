using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;
using VapeShop.Domain.VSProduct;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations.VSProduct
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne<Product>()
               .WithOne(product => product.Category).HasForeignKey<Product>(product => product.Id);
        }
    }
}

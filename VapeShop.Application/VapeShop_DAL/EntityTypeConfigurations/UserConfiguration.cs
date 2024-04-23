using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;

namespace VapeShop.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user =>  user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.Email).IsRequired().HasMaxLength(100);
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(25);


        }
    }
}

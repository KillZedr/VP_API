using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations.Identity
{
    public class UserSettingsDBConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.HasOne<User>()
                .WithOne(user => user.UserSettings).HasForeignKey<User>(user => user.Id);
        }
    }
}

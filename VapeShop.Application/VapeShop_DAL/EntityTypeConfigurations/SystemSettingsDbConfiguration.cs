using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.SystemSettings;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations
{
    public class SystemSettingsDbConfiguration : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            /*builder.HasKey(ss => ss.SettingId);*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.SystemSettings
{
    public class SystemSetting : Entity<SystemSettingEnum>
    {
        /*public required SystemSettingEnum SettingId { get; set; }*/
        public required string Value { get; set; }
    }
}

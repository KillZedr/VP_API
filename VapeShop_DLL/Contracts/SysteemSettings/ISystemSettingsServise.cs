using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.SystemSettings;

namespace VapeShop_BLL.Contracts.SysteemSettings
{
    public interface ISystemSettingsServise : IService
    {
        public Task<string?> ReadSetting(SystemSettingEnum settingId);

        public Task WriteSetting(SystemSetting settingToWrite);
    }
}

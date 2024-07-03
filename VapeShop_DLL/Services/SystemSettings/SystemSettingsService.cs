using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.SystemSettings;
using VapeShop_BLL.Contracts;
using VapeShop_BLL.Contracts.SysteemSettings;

namespace VapeShop_BLL.Services.SystemSettings
{
    public class SystemSettingsService : ISystemSettingsServise
    {
        private readonly IUnitOfWork _unitOfWork;
        public SystemSettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string?> ReadSetting(SystemSettingEnum settingId)
        {
            var settingEntity = await _unitOfWork.GetRepository<SystemSetting>()
            .AsReadOnlyQueryable()
            .FirstOrDefaultAsync(s => s.Id == settingId);
            return settingEntity?.Value;
        }

        public async Task WriteSetting(SystemSetting settingToWrite)
        {
            var repo = _unitOfWork.GetRepository<SystemSetting>();

            await repo.InsertOrUpdate(
                setting => setting.Id == settingToWrite.Id,
                settingToWrite
            );

            await _unitOfWork.SaveShangesAsync();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VapeShop.Domain.SystemSettings;
using VapeShop_BLL.Contracts.SysteemSettings;
using ILogger = Serilog.ILogger;

namespace VapeShop_API.Controllers.SystemSettings
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingsController : ControllerBase
    {
        


        private readonly ISystemSettingsServise _systemSettingsServise;
        private readonly ILogger _logger;
        public SystemSettingsController(ISystemSettingsServise systemSettingsServise)
        {
            _systemSettingsServise = systemSettingsServise;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(SystemSettingEnum id)
        {
            try
            {   
                var settingValue = await _systemSettingsServise.ReadSetting(id);
                return  Content(settingValue ?? string.Empty);
            }
            catch (Exception ex)
            {
                var msg = "Faild to write System Setting";
                _logger.Error(ex, msg);

                return this.StatusCode((int)HttpStatusCode.InternalServerError, msg);
            }
            }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] SystemSetting setting)
        {
            try
            {
                await _systemSettingsServise.WriteSetting(setting);
                return Ok();
            }
            catch (Exception ex)
            {
                var msg = "Failed to write System Setting";
                _logger.Error(ex, msg);

                return StatusCode((int)HttpStatusCode.InternalServerError, msg);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.Identity;

namespace VapeShop_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserTestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserTestController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        [HttpGet(Name = "TestGet")]
        [ProducesResponseType<User>(200, contentType: "application/json")]
        public async Task<IActionResult> Get()
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var userSettingsRepo = _unitOfWork.GetRepository<UserSettings>();
            var settings = new UserSettings { Address = "as", DarkThemeEnabled = true, Phone = "+375291236419"};
            userSettingsRepo.Create(settings);
            var user = new User
            {
                Email = "user@example.com",
                FirstName = "Test",
                LastName = "Test",
                Role = UserRole.Administrator,
                PasswordHash = "",
                PasswordSalt = "",
                UserSettings = settings

            };

            userRepo.Create(user);

            await _unitOfWork.SaveShangesAsync();

            return Ok(user);
        }
    }
}


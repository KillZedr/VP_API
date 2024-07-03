using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.ECommerce;
using VapeShop.Domain.Identity;
using VapeShop.Domain.Identity.Helpers;
using VapeShop_API.DTO.Identity;

namespace VapeShop_API.Controllers.Identity
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
            var settings = new UserSettings { Address = "as", DarkThemeEnabled = true, Phone = "+375291236419" };
            var basket = new Basket() { UserId = null, User = null, ProductInBasket = new List<ProductInBasket>() };
            userSettingsRepo.Create(settings);
            var user = new User
            {

                Email = "user@example.com",
                FirstName = "Test",
                LastName = "Test",
                Role = UserRole.Administrator,
                PasswordHash = "",
                PasswordSalt = "",
                UserSettings = settings,
                Basket = basket,


            };

            userRepo.Create(user);

            await _unitOfWork.SaveShangesAsync();

            return Ok(user);
        }
        [HttpGet("Test2Mod")]

        [ProducesResponseType<User>(200, contentType: "application/json")]
        public async Task<IActionResult> FindTestUserById(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.AsQueryable()
                .Include(u => u.UserSettings)
                .FirstOrDefaultAsync(u => u.Id == id);

            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegisterDTO user)
        {
            var userNew = await _unitOfWork.GetRepository<User>().AsQueryable().FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userNew == null)
            {
                var settings = new UserSettings { Address = "", DarkThemeEnabled = true, Phone = "" };
                var basket = new Basket() { UserId = null, User = null, ProductInBasket = new List<ProductInBasket>() };
                user.Password = Md5HashPassword.HashPassvord(user.Password);
                var newUser = new User
                {

                    Basket = basket,
                    UserSettings = settings,
                    Email = user.Email,
                    PasswordHash = user.Password,
                    PasswordSalt = "",
                    FirstName = user.UserFName,
                    LastName = user.UserLName,
                    Role = user.Role
                };

                var repoUser = _unitOfWork.GetRepository<User>();
                repoUser.Create(newUser);
                await _unitOfWork.SaveShangesAsync();
                return Ok(userNew);
            }
            else
            {
                throw new Exception($"User with this {user.Email} already exists");
            }
        }
    }
}


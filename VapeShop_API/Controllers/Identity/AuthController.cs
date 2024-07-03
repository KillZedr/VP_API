using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop_API.DTO.Identity;
using VapeShop_BLL.Contracts.Identity;
using VapeShop.Domain;
using VapeShop.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace VapeShop_API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        public async Task<IActionResult> AuthLogin([FromBody] UserLoginDTO user)
        {

            var findUser = await _unitOfWork.GetRepository<User>().AsReadOnlyQueryable().FirstOrDefaultAsync(u => u.Email == user.Email);
            var userLogin = await _userService.AutorisationMessod(user.Email, user.Password);

            if (userLogin == null)
            {
                return Forbid();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", findUser.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties { };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return Ok();
        }
    }
}

using VapeShop.Domain.Identity;

namespace VapeShop_API.DTO.Identity
{
    public class UserRegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public UserRole Role { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.ECommerce;
using VapeShop.Domain.Identity;
using VapeShop.Domain.Identity.Helpers;
using VapeShop.Domain.VSProduct;
using VapeShop_BLL.Contracts;
using VapeShop_BLL.Contracts.Identity;

namespace VapeShop_BLL.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AutorisationMessod(string email, string password)
        {
            var findUser = await _unitOfWork.GetRepository<User>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(u => u.Email == email);
            if (findUser == null)
            {
                throw new Exception($"User with this {email} not faund");
            }
            else
            {
                var userHashPassword = Md5HashPassword.HashPassvord(password);
                if (password == userHashPassword) 
                {
                    return findUser;
                }


            }
            return null;

        }
    }
}

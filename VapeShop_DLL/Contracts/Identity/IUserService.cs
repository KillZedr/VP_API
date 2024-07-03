using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.Identity;
using VapeShop.Domain.VSProduct;

namespace VapeShop_BLL.Contracts.Identity
{
    public interface IUserService : IService
    {
        Task<User> AutorisationMessod(string email, string password);
    }
}

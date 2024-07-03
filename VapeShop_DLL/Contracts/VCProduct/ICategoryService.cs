using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop_BLL.Contracts.VCProduct
{
    public interface ICategoryService : IService
    {
        Task<List<Product>> GetAllProductsInThisCategory(string categoryName);
        Task<List<Product>> GetProductInThisCategory(string categoryName, string productName);
    }
}

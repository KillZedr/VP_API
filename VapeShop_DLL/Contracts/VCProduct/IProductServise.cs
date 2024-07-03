using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop_BLL.Contracts.VCProduct
{
    public interface IProductServise : IService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        /*Task<Manufacturer> GetManufacturerProductByName(string name);
        Task<Category> GetCategoryProductByName(string name);*/

    }
}

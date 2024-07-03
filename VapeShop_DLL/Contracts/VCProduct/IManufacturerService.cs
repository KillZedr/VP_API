using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop_BLL.Contracts.VCProduct
{
    public interface IManufacturerService : IService
    {
        Task<List<Product>> GetAllProductInThisManufacturer(string manufacturerName);
        Task<List<Product>> GetProductByNameInThisManufacturer(string manufacturerName, string productName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.VSProduct;

namespace VapeShop_BLL.Contracts.VCProduct
{
    public interface IPriceChangeService : IService
    {
        Task<List<Product>> GetAllProductsFromAmountToAmount(decimal amountFrom, decimal amountTo);
        /*Task<List<Product>> SortAllProductsMinMax();
        Task<List<Product>> SortAllProductsMaxMin();*/
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.VSProduct;
using VapeShop_BLL.Contracts.VCProduct;

namespace VapeShop_BLL.Services.VCProduct
{
    public class PriceChangeService : IPriceChangeService
    {

        private readonly IUnitOfWork _unitOfWork;
        public PriceChangeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetAllProductsFromAmountToAmount(decimal amountFrom, decimal amountTo)
        {
            var repoProduct = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .ToListAsync();
            var productFromAmountToAmount = new List<Product>();

            if (repoProduct != null)
            {
                var isFlag = false;
                foreach (var product in repoProduct)
                {
                    isFlag.Equals(product.PriceChanges
                        .OrderByDescending(prc => prc.NewPrice > amountFrom && prc.NewPrice < amountTo));
                    if (isFlag == true)
                    {
                        productFromAmountToAmount.Add(product);
                    }
                    else { }
                }
                return productFromAmountToAmount;
            }
            else
            {
                throw new Exception(" There are no products in this range with this price");
            }
        }

       /* public async Task<List<Product>> SortAllProductsMaxMin()
        {
            var repoProduct = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .ToListAsync();
            if (repoProduct != null)
            {
                repoProduct.Sort
            }

            var productSortMinMax = new List<Product>();
        }

        public async Task<List<Product>> SortAllProductsMinMax()
        {
            var repoProduct = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .ToListAsync();
            var productSortMaxMin = new List<Product>();
        }*/
    }
}

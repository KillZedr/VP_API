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
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetAllProductsInThisCategory(string categoryName)
        {
            var repoCategory = await _unitOfWork.GetRepository<Category>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (repoCategory != null)
            {
                return repoCategory.Products.ToList();
            }
            else
            {
                return new List<Product>();
            }
            
        }

        public async Task<List<Product>> GetProductInThisCategory(string categoryName, string productName)
        {
            var repoCategory = await _unitOfWork.GetRepository<Category>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(c => c.Name == categoryName);

                
            if (repoCategory != null)
            {
                var products = repoCategory.Products.ToList();
                var productFind = new List<Product>();
                productFind.Add(item: products.FirstOrDefault(p => p.Name == productName)) ;
                if (productFind != null)
                {
                    return productFind;
                }
                else
                {
                    throw new Exception($"{productName}  :there is no product in this {categoryName} category");
                }
                
            }
            else
            {
                throw new Exception($"no such category: {categoryName}");
            };

        }
    }
}

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
    public class ProductService : IProductServise
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var product = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .ToListAsync();

            return product;

        }
        public async Task<Product> GetProductById(int id)
        {
            var productFind = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(p => p.Id == id);

            return productFind;
        }

        public async Task<Product> GetProductByName(string name)
        {
            var productFind = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(p => p.Name == name);
            return productFind;
        }
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;
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
    public class ManufacturerService : IManufacturerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManufacturerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetAllProductInThisManufacturer(string manufacturerName)
        {
            var repoManufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == manufacturerName);
            if (repoManufacturer != null)
            {
                var productInManufacturer = repoManufacturer.Products.ToList();

                return productInManufacturer;
            }
            else
            {
                throw new Exception($"no such manufacturer: {manufacturerName}");
            }

        }

        public async Task<List<Product>> GetProductByNameInThisManufacturer(string manufacturerName, string productName)
        {
            var repoManufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == manufacturerName);
            if (repoManufacturer != null)
            {
                var products = repoManufacturer.Products.ToList();
                var findProduct = new List<Product>();
                findProduct.Add(item: products.FirstOrDefault(p => p.Name == productName));
                if (findProduct != null)
                {
                    return findProduct;
                }
                else
                {
                    throw new Exception($"{manufacturerName} this manufacturer does not have this/such products: {productName}");
                }
            }
            else
            {
                throw new Exception($"{manufacturerName}: no such manufacturer");
            };

        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.VSProduct;
using VapeShop_API.DTO.VSProduct;
using VapeShop_BLL.Contracts.VCProduct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop_API.Controllers.VSProduct
{
    /*[ApiVersion("1.0")]
    [ApiVersion("2.0")]*//*
    [ApiVersionNeutral]
    [Produces("application/json")]*/
    [Route("api/[controller]")]
    [ApiController]
    public class PriceChangeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPriceChangeService _priceChangeService;
        public PriceChangeController(IUnitOfWork unitOfWork, IPriceChangeService priceChangeService)
        {
            _unitOfWork = unitOfWork;
            _priceChangeService = priceChangeService;
        }

        // GET: api/<PriceChangeController>
        
        [HttpGet]
        public async Task<IActionResult> GetAllPrice()
        {
            var priceChange = await _unitOfWork.GetRepository<PriceChange>()
                .AsReadOnlyQueryable()
                .ToListAsync();
            var products = await _unitOfWork.GetRepository<Product>()
                .AsReadOnlyQueryable()
                .ToListAsync();

            var productsAndPrices = new List<ProductIdNameAndPriceIdPriceDTO>();

            foreach (var product in products)
            {
                var productAndPrice = new ProductIdNameAndPriceIdPriceDTO()
                {
                    ProductName = product.Name,
                    priceChange = (PriceChange)product.PriceChanges
                };
                productsAndPrices.Add(productAndPrice);
            }
            return Ok(priceChange);
        }

        /* [HttpPost]*/
        /*public async Task<IActionResult> CreatePrice(PriceChangeDTO priceChangeDto)
        {
            var repoPriceChange = _unitOfWork.GetRepository<PriceChange>();
            var priceChange = new PriceChange()
            {
                DatePriceChange = priceChangeDto.DateTime,
                NewPrice = priceChangeDto.Price,
                
            };
            repoPriceChange.Create(priceChange);
            await _unitOfWork.SaveShangesAsync();
            return Ok(priceChange);

        }*/

        // GET api/<PriceChangeController>/5
        
        [HttpGet("GetProductFromPriceToPrice")]
        public async Task<IActionResult> GetProductFromPriceToPrice(decimal from, decimal to)
        {
            var productFromPriceToPrice = await _priceChangeService.GetAllProductsFromAmountToAmount(from, to);
            return Ok(productFromPriceToPrice);
        }

        
        [HttpPut("UpdatePriceAtTheProduct")]
        public async Task<IActionResult> UpdatePriceAtTheProduct(int idProduct, [FromBody] decimal newPrice)
        {
            var productFind = await _unitOfWork.GetRepository<Product>()
                .AsQueryable()
                .FirstOrDefaultAsync(p => p.Id == idProduct);
            if (productFind != null)
            {
                var price = productFind.PriceChanges.FirstOrDefault(p => p.NewPrice == p.NewPrice);
                price.NewPrice = newPrice;

                var repoPriceChange = _unitOfWork.GetRepository<PriceChange>();
                repoPriceChange.Update(price);
                await _unitOfWork.SaveShangesAsync();
                return Ok(repoPriceChange);
            }
            else
            {
                return NotFound(500);

            }
        }
    }
}

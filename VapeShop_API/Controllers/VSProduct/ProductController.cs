using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.ECommerce;
using VapeShop.Domain.VSProduct;
using VapeShop_API.DTO.VSProduct;
using VapeShop_BLL.Contracts.VCProduct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop_API.Controllers.VSProduct
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductServise _productServise;
        public ProductController(IUnitOfWork unitOfWork, IProductServise productServise)
        {
            _unitOfWork = unitOfWork;
            _productServise = productServise;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _productServise.GetAllProduct();
            return Ok(product);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{string}")]
        public async Task<IActionResult> GetProductOrProductsByName(string Name)
        {
            var productFind = await _productServise.GetProductByName(Name);
            return Ok(productFind);
        }


        /*[HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO createProduct)
        {
            var productAll = await _unitOfWork.GetRepository<Product>()
                .AsQueryable()
                .ToListAsync();

            var manufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == createProduct.ManufacturerName);

            var category = await _unitOfWork.GetRepository<Category>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(c => c.Name == createProduct.CategoryName);

*/

           /* var price = _unitOfWork.GetRepository<PriceChange>();
            var newPrice = new PriceChange
            {
                DatePriceChange = DateTime.Now,
                NewPrice = createProduct.Price,
            };
            price.Create(newPrice);
*/
            /*var basket = new List<ProductInBasket>();
            if (productAll != null || productAll.FirstOrDefault(p => p.Name == createProduct.Name) == null)
            {
                var prod = new Product
                {
                    Name = createProduct.Name,
                    Description = createProduct.Description,
                    PicturePath = createProduct.PicturePath,
                    Category = category,
                    Baskets = basket,
                    Feedbacks = new List<Feedback> { },
                    PriceChanges = new PriceChange
                    {
                        NewPrice = createProduct.Price,
                        DatePriceChange = DateTime.UtcNow,
                    },
                    PurchaseItems = new List<PurchaseItem> { },
                    Manufacturer = manufacturer
                };
                var prodRepo = _unitOfWork.GetRepository<Product>();
                prodRepo.Create(prod);
                await _unitOfWork.SaveShangesAsync();
                return Ok(prod);
            }
            return BadRequest();
        }*/

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

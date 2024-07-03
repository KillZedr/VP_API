using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain.VSProduct;
using VapeShop_BLL.Contracts.VCProduct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop_API.Controllers.VSProduct
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;
        public CategoryController(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAllCategorys()
        {
            var category = await _unitOfWork.GetRepository<Category>().AsReadOnlyQueryable().ToListAsync();
            return Ok(category);
        }

        // GET api/<CategoryController>/5
        [HttpGet("TestCatedoryProduct")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var findCategory = await _unitOfWork.GetRepository<Category>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(c => c.Name == name);

            if (findCategory != null)
            { 
                return Ok(findCategory);
            }
            else 
            { 
                return BadRequest(500); 
            }

        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] string name)
        {
            var category = await _unitOfWork.GetRepository<Category>()
                .AsQueryable()
                .FirstOrDefaultAsync(c => c.Name == name);
            if (category == null) 
            {
                var categoryNew = new Category { Name = name };
                var repoCategory = _unitOfWork.GetRepository<Category>();
                repoCategory.Create(categoryNew);
                await _unitOfWork.SaveShangesAsync();
                return Ok(categoryNew);
            }
            else { return BadRequest(500); }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{string}")]
        public async Task<IActionResult> UpdateCategory([FromBody] string nameCategory, string nameNewUpdateCategory)
        {
            var updateCategory = await _unitOfWork.GetRepository<Category>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(c => c.Name == nameCategory);
            if (updateCategory == null) { return BadRequest(500); }
            else
            {
                updateCategory.Name = nameCategory;
                var repoCategory = _unitOfWork.GetRepository<Category>();
                repoCategory.Update(updateCategory);
                await _unitOfWork.SaveShangesAsync();
                return Ok(updateCategory);
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{string}")]
        public async Task<IActionResult> DeleteCategory([FromBody] string nameCategory) 
        {
            var deleteCategory = await _unitOfWork.GetRepository<Category>()
                .AsQueryable()
                .FirstOrDefaultAsync(c => c.Name == nameCategory);
            if (deleteCategory == null)
            {
                throw new Exception($"Not Faund Category: {nameCategory}");
            }
            else
            {
                var repoCategory = _unitOfWork.GetRepository<Category>();
                repoCategory.Delete(deleteCategory);
                await _unitOfWork.SaveShangesAsync();
                return Ok(deleteCategory);
            }
        }
        [HttpGet("{string}")]
        public async Task<IActionResult> GetAllProductsFromCategory(string nameCategory)
        {
            var categoryProducts = await _categoryService.GetAllProductsInThisCategory(nameCategory);
            return Ok(categoryProducts);
        }
    }
}

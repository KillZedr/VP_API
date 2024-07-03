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
    public class ManufacturerController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IUnitOfWork unitOfWork, IManufacturerService manufacturerService)
        {
            _unitOfWork = unitOfWork;
            _manufacturerService = manufacturerService;
        }


        // GET: api/<ManufacturerController>
        [HttpGet]
        public async Task<IActionResult> GetAllManufacturer()
        {
            var manufacturers = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .ToListAsync();
            return Ok(manufacturers);
        }

        // GET api/<ManufacturerController>/5
        [HttpGet("GetManufacturerByName")]
        public async Task<IActionResult> GetManufacturerByName(string name)
        {
            var findManufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == name);
            if (findManufacturer != null)
            {
                return Ok(findManufacturer);
            }
            else
            {
                throw new Exception($"Not found Manufacturer: {name}");
                return BadRequest(500);
            }
        }

        // POST api/<ManufacturerController>
        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromBody] string name)
        {
            var newManufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == name);
            if (newManufacturer == null) 
            {

                newManufacturer = new Manufacturer { ManufacturerName = name };
                var repoManufacturer = _unitOfWork.GetRepository<Manufacturer>();
                repoManufacturer.Create(newManufacturer);
                await _unitOfWork.SaveShangesAsync();
                return Ok(newManufacturer);

            }
            else
            {
                throw new Exception("A manufacturer with the same name already exists");
                return BadRequest(500);
            }
        }

        // PUT api/<ManufacturerController>/5
        [HttpPut("UpdateManufacturer")]
        public async Task<IActionResult> UpdateManufacturer(string name, [FromBody] string nameNew)
        {
            var updateManufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == name);
            if (updateManufacturer != null)
            {
                updateManufacturer.ManufacturerName = nameNew;
                var repoManufacturer = _unitOfWork.GetRepository<Manufacturer>();
                repoManufacturer.Update(updateManufacturer);
                await _unitOfWork.SaveShangesAsync();
                return Ok(updateManufacturer);
            }
            else
            {
                throw new Exception($"Not Faund Manufacturer: {name}");
                return NotFound(500);
            }
        }

        // DELETE api/<ManufacturerController>/5
        [HttpDelete("DeleteManufacturer")]
        public async Task<IActionResult> DeleteManufacturer(string name)
        {
            var deleteManufacturer = await _unitOfWork.GetRepository<Manufacturer>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(m => m.ManufacturerName == name);
            if (deleteManufacturer != null)
            {
                var repoManufacturer = _unitOfWork.GetRepository<Manufacturer>();
                repoManufacturer.Delete(deleteManufacturer);
                await _unitOfWork.SaveShangesAsync();
                return Ok(deleteManufacturer);
            }
            else
            {
                throw new Exception($"Not Faund Manufacturer: {name}");
                return NotFound(500);
            }
        }
        [HttpGet("GetManufacturerProductsByNameManufacturer")]
        public async Task<IActionResult> GetManufacturerProductsByNameManufacturer([FromBody] string name)
        {
            var productManufacturer = await _manufacturerService.GetAllProductInThisManufacturer(name);
            return Ok(productManufacturer);
        }
    }
}

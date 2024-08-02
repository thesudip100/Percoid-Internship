using ApplicationLayer.Services.Service;
using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GharSewaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ServiceCategoryDTO categoryDTO)
        {
            var result = await _service.AddCategoryAsync(categoryDTO);
            return Ok(new { message = $"{result}" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}

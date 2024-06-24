using ApplicationLayer.Services;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> emp;

        public EmployeeController(IService<Employee> _emp)
        {
            emp = _emp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var data = await emp.GetAllDataAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleEmployee(int id)
        {
            var data = await emp.GetByIdDataAsync(id);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await emp.DeleteDataAsync(id);
            return Ok("deleted");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee e)
        {
            await emp.UpdateDataAsync(e);
            return Ok(e);
        }
    }
}

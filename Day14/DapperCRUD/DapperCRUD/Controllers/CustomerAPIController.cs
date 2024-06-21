using ApplicationLayer.Services;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private readonly IService<Customer> customer;

        public CustomerAPIController(IService<Customer> _customer)
        {
            customer = _customer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customers = await customer.GetAllDataAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCustomer(int id)
        {
            var data = await customer.GetByIdDataAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}

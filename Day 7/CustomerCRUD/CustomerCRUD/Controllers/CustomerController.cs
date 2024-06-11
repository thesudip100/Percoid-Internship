using CustomerCRUD.Data;
using CustomerCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CustomerCRUD.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context;

        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add()
        {
            return View("AddCustomer");
        }


        [HttpPost]
        public async Task<IActionResult> Add(CustomerAddViewModel customer)
        {
            var customers = new Customer()
            {
                Name = customer.name,
                Email = customer.email,
                Address = customer.address,
                PhoneNumber = customer.phoneNumber,
                DateofBirth = customer.dateofBirth
            };

            await context.Customers.AddAsync(customers);
            await context.SaveChangesAsync();
            return View("Add");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var customers = await context.Customers.ToListAsync();
            return View("CustomerListView", customers);
        }

        public async Task<IActionResult> Update(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            return View("UpdateCustomerView", customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDTO updatecustomer, int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.Name = updatecustomer.Name;
                customer.Email = updatecustomer.Email;
                customer.PhoneNumber = updatecustomer.PhoneNumber;
                customer.Address = updatecustomer.Address;
                customer.DateofBirth = updatecustomer.DateofBirth;

                await context.SaveChangesAsync();
                return RedirectToAction("CustomerList");
            }
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return RedirectToAction("CustomerList");
            }
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            return View("DetailsView",customer);
        }
    }
}
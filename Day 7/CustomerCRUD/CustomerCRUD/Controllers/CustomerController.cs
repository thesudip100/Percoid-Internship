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
            var newCustomer = new Customer()
            {
                Cust_Id = customer.id,
                Name = customer.name,
                Email = customer.email,
                Address = customer.address,
                PhoneNumber = customer.phoneNumber,
                DateofBirth = customer.dateofBirth,
            };

            var newGoods = new Goods()
            {
                GoodsID = customer.GoodsID,
                goodsName = customer.goodsName

            };

            var cusGoods = new CustomerGoods()
            {

                GoodsId = newGoods.GoodsID,
                Cus_id = newCustomer.Cust_Id,
                Gds = newGoods,
                Cust = newCustomer,
            };

            context.Customers.Add(newCustomer);
            context.Goods.Add(newGoods);
            context.CustomerGoods.Add(cusGoods);
            await context.SaveChangesAsync();
            return RedirectToAction("CustomerList");
        }


        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var query = await (from customer in context.Customers
                               join goods in context.CustomerGoods on customer.Cust_Id equals goods.Cus_id
                               select new FinalCustomerViewModel
                               {
                                   id = customer.Cust_Id,
                                   name = customer.Name,
                                   email = customer.Email,
                                   phoneNumber = customer.PhoneNumber,
                                   address = customer.Address,
                                   dateofBirth = customer.DateofBirth,
                                   GoodsID = goods.Gds.GoodsID,
                                   goodsName = goods.Gds.goodsName
                               }).ToListAsync();

            return View("CustomerListView", query);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var details = await context.CustomerGoods.Include(cg => cg.Cust).Include(cg => cg.Gds).FirstOrDefaultAsync(i => i.Cus_id == id);
            return View("UpdateCustomerView", details);
        }



        [HttpPost]
        public async Task<IActionResult> Update(CustomerGoods updatecustomer, int id)
        {
            var details = await context.CustomerGoods.Include(cg => cg.Cust).Include(cg => cg.Gds).FirstOrDefaultAsync(i => i.Cus_id == id);
   
            if (details != null )
            {
                details.Cust.Cust_Id = updatecustomer.Cust.Cust_Id;
                details.Cust.Name = updatecustomer.Cust.Name;
                details.Cust.Email = updatecustomer.Cust.Email;
                details.Cust.PhoneNumber = updatecustomer.Cust.PhoneNumber;
                details.Cust.Address = updatecustomer.Cust.Address;
                details.Cust.DateofBirth = updatecustomer.Cust.DateofBirth;
                details.Gds.GoodsID = updatecustomer.Gds.GoodsID;
                details.Gds.goodsName = updatecustomer.Gds.goodsName;

                await context.SaveChangesAsync();
                return RedirectToAction("CustomerList");
            }
            return RedirectToAction("CustomerList");
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customergood = await context.CustomerGoods.FirstOrDefaultAsync(i=>i.Cus_id==id);
            var customer= await context.Customers.FirstOrDefaultAsync(i => i.Cust_Id == id);
            if (customergood != null && customer !=null)
            {
                context.CustomerGoods.Remove(customergood);
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return RedirectToAction("CustomerList");
            }
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var customergood = await context.CustomerGoods.Include(cg => cg.Cust).Include(cg => cg.Gds).FirstOrDefaultAsync(i => i.Cus_id == id);

            return View("DetailsView", customergood);
        }
    }
}

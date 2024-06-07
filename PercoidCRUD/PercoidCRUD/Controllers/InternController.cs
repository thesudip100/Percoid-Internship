using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PercoidCRUD.Data;
using PercoidCRUD.Models;

namespace PercoidCRUD.Controllers
{
    public class InternController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public InternController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("AddIntern");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInterViewModel addIntern)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var intern = new Intern()
                    {
                        Name = addIntern.name,
                        Address = addIntern.address,
                        JoiningDate = addIntern.joiningDate,
                        Salary = addIntern.salary
                    };
                    await applicationDbContext.Intern.AddAsync(intern);
                    await applicationDbContext.SaveChangesAsync();
                    TempData["AlertMessage"] = "Intern added successfully";
                    TempData["AlertStatus"] = 200;
                }
                catch (Exception)
                {
                    TempData["AlertMessage"] = "Error adding intern";
                    TempData["AlertStatus"] = 500; // Internal Server Error
                }
            }
            else
            {
                TempData["AlertMessage"] = "Invalid data submitted";
                TempData["AlertStatus"] = 400; // Bad Request
            }
            return RedirectToAction("Add");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var interns = await applicationDbContext.Intern.ToListAsync();
            return View(interns);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var intern = await applicationDbContext.Intern.FirstOrDefaultAsync(x => x.Id == id);
            if (intern != null)
            {
                var viewModel = new UpdateInternModel()
                {
                    Id = intern.Id,
                    Name = intern.Name,
                    Address = intern.Address,
                    Salary = intern.Salary,
                    JoiningDate = intern.JoiningDate
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateInternModel model)
        {
            var intern = await applicationDbContext.Intern.FindAsync(model.Id);
            if (intern != null)
            {
                intern.Id = model.Id;
                intern.Name = model.Name;
                intern.Address = model.Address;
                intern.Salary = model.Salary;
                intern.JoiningDate = model.JoiningDate;

                await applicationDbContext.SaveChangesAsync();
                TempData["AlertMessage"] = "Intern updated successfully";
                TempData["AlertStatus"] = 200;
                return RedirectToAction("Index");
            };
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateInternModel model)
        {
            var intern = await applicationDbContext.Intern.FindAsync(model.Id);
            if(intern!=null)
            {
                applicationDbContext.Intern.Remove(intern);
                await applicationDbContext.SaveChangesAsync(); 
                TempData["AlertMessage"] = "Intern deleted successfully";
                return RedirectToAction("Index");
                
            }
            return RedirectToAction("Index");
        }



    }
}

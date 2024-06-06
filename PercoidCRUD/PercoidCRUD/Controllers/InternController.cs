using Microsoft.AspNetCore.Mvc;
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
            var intern = new Intern()
            {
                Name = addIntern.name,
                Address = addIntern.address,
                JoiningDate = addIntern.joiningDate,
                Salary = addIntern.salary
            };
            await applicationDbContext.Intern.AddAsync(intern);
            await applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

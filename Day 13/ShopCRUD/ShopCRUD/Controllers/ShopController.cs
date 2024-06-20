using BusinessLogicLayer_Services_.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ShopCRUD.Controllers
{
    public class ShopController : Controller
    {
        private readonly IService<Shop> service;

        public ShopController(IService<Shop> service)
        {
            this.service = service;
        }
         
        public IActionResult Index()
        {
            var list = service.GetAllData();
            return View(list);
        }

        public IActionResult AddShop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddShop(Shop shop)
        {
            service.AddData(shop);
            return RedirectToAction("Index");
        }

        public IActionResult EditShop(int id)
        {   var obj=service.GetDataByID(id);
            return View(obj);
        }


        [HttpPost]
        public IActionResult EditShop(Shop shop)
        {
            service.UpdateData(shop);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteShop(int id)
        {
            var shop= service.GetDataByID(id);
            service.DeleteData(shop);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsShop(int id)
        {
            var shop = service.GetDataByID(id);
            return View(shop);
        }
    }
}

using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;


namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
     

        public IActionResult Index()
        {
            List<Category> category = new List<Category>();
            category.Add(new Category() { Id = 1, Name = "Laptop", Description = "Silver, Price = 2000" });
            category.Add(new Category() { Id = 2, Name = "Iphone", Description = "Black, Price = 1000" });
            category.Add(new Category() { Id = 3, Name = "Samsung Galaxy", Description = "Blue, Price = 900" });
            category.Add(new Category() { Id = 4, Name = "Chair", Description = "Wooden, Price = 120" });
            category.Add(new Category() { Id = 5, Name = "Table", Description = "White, Price = 250" });

            ViewData["Title"] = "Category/Index";
            return View(category);
        }



        public IActionResult Detail()
        {
            ViewData["Title"] = "Category/Details";
            return View("explain");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}

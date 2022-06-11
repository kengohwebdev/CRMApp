using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;


namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryServiceAsync categoryServiceAsync;
        public CategoryController(ICategoryServiceAsync cser)
        {
            categoryServiceAsync = cser;
        }
        
        public async Task<IActionResult> Index()
        {
            var catCollection = await categoryServiceAsync.GetAllAsync();
            if (catCollection != null)
                return View(catCollection);

            List<CategoryModel> model = new List<CategoryModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.AddCategoryAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var shipModel = await categoryServiceAsync.GetCategoryForEditAsync(id);
            return View(shipModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.UpdateCategoryAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryServiceAsync.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
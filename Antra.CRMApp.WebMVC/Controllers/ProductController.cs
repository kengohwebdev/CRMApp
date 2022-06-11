using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
    
        private readonly IProductServiceAsync productServiceAsync;
        private readonly IVendorServiceAsync vendorServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public ProductController(IProductServiceAsync productservice, IVendorServiceAsync vendorservice, ICategoryServiceAsync categoryservice)
        {
            productServiceAsync = productservice;
            vendorServiceAsync = vendorservice;
            categoryServiceAsync = categoryservice;
        }


        public async Task<IActionResult> Index()
        {

            var productCollection = await productServiceAsync.GetAllAsync();
            if (productCollection != null)
                return View(productCollection);

            List<ProductResponseModel> model = new List<ProductResponseModel>();
            return View(model);
        }
        public IActionResult Detail()
        {
            ViewData["Title"] = "Product/Details";
            return View("explain");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collectionVen = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(collectionVen, "Id", "Name");
            var collectionCat = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(collectionCat, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await productServiceAsync.AddProductAsync(model);
                return RedirectToAction("Index");
            }
            var collectionVen = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(collectionVen, "Id", "Name");
            var collectionCat = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(collectionCat, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await productServiceAsync.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var proModel = await productServiceAsync.GetProductForEditAsync(id);
            var collectionVen = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(collectionVen, "Id", "Name");
            var collectionCat = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(collectionCat, "Id", "Name");
            return View(proModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collectionVen = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(collectionVen, "Id", "Name");
            var collectionCat = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(collectionCat, "Id", "Name");
            if (ModelState.IsValid)
            {
                await productServiceAsync.UpdateProductAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }
    }
}
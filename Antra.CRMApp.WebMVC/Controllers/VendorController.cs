using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorServiceAsync vendorServiceAsync;
        public VendorController(IVendorServiceAsync vser)
        {
            vendorServiceAsync = vser;
        }

        public async Task<IActionResult> Index()
        {
            var venCollection = await vendorServiceAsync.GetAllAsync();
            if (venCollection != null)
                return View(venCollection);

            List<VendorRequestModel> model = new List<VendorRequestModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VendorRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await vendorServiceAsync.AddVendorAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var venModel = await vendorServiceAsync.GetVendorForEditAsync(id);
            return View(venModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VendorRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await vendorServiceAsync.UpdateVendorAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await vendorServiceAsync.DeleteVendorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
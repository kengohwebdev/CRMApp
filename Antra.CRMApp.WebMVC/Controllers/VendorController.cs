using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorServiceAsync vendorServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public VendorController(IVendorServiceAsync vser, IRegionServiceAsync regionServiceAsync)
        {
            vendorServiceAsync = vser;
            this.regionServiceAsync = regionServiceAsync;
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
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
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
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var venModel = await vendorServiceAsync.GetVendorForEditAsync(id);

            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(venModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VendorRequestModel model)
        {
            ViewBag.IsEdit = false;

            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
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

        public async Task<IActionResult> Detail()
        {
            var Collection = await vendorServiceAsync.GetAllAsync();
            if (Collection != null)
                return View(Collection);

            List<VendorResponseModel> model = new List<VendorResponseModel>();
            return View(model);
        }
    }
}
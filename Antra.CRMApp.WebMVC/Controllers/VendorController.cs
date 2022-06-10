using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorServiceAsync vendorServiceAsync;
        public VendorController(IVendorServiceAsync ser)
        {
            vendorServiceAsync = ser;
        }

        public async Task<IActionResult> Index()
        {
            var shipCollection = await vendorServiceAsync.GetAllAsync();
            if (shipCollection != null)
                return View(shipCollection);

            List<VendorModel> model = new List<VendorModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VendorModel model)
        {
            if (ModelState.IsValid)
            {
                await vendorServiceAsync.AddVendorAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }




    }
}
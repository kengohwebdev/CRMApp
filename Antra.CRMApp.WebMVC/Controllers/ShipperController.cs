using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperServiceAsync shipperServiceAsync;
        public ShipperController(IShipperServiceAsync sser)
        {
            shipperServiceAsync = sser;
        }

        public async Task<IActionResult> Index()
        {
            var shipCollection = await shipperServiceAsync.GetAllAsync();
            if (shipCollection != null)
                return View(shipCollection);

            List<ShipperModel> model = new List<ShipperModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipperModel model)
        {
            if (ModelState.IsValid)
            {
                await shipperServiceAsync.AddShipperAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var shipModel = await shipperServiceAsync.GetShipperForEditAsync(id);
            return View(shipModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ShipperModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await shipperServiceAsync.UpdateShipperAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await shipperServiceAsync.DeleteShipperAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail()
        {
            var Collection = await shipperServiceAsync.GetAllAsync();
            if (Collection != null)
                return View(Collection);

            List<ShipperModel> model = new List<ShipperModel>();
            return View(model);
        }
    }
}
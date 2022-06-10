using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        public RegionController(IRegionServiceAsync ser)
        {
            regionServiceAsync = ser;
        }
        public async Task<IActionResult> Index()
        {
            var result = await regionServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegionModel model)
        {
            if (ModelState.IsValid)
            {
                await regionServiceAsync.AddRegionAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}

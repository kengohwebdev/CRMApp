using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.Infrastructure.Service
{

        public class RegionController : Controller
        {
            private readonly IRegionServiceAsync regionServiceAsync;
            public RegionController(IRegionServiceAsync rser)
            {
                regionServiceAsync = rser;
            }

            public async Task<IActionResult> Index()
            {
                var regCollection = await regionServiceAsync.GetAllAsync();
                if (regCollection != null)
                    return View(regCollection);

                List<RegionModel> model = new List<RegionModel>();
                return View(model);
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


            [HttpGet]
            public async Task<IActionResult> Edit(int id)
            {
                ViewBag.IsEdit = false;
                var venModel = await regionServiceAsync.GetRegionForEditAsync(id);
                return View(venModel);
            }
            [HttpPost]
            public async Task<IActionResult> Edit(RegionModel model)
            {
                ViewBag.IsEdit = false;
                if (ModelState.IsValid)
                {
                    await regionServiceAsync.UpdateRegionAsync(model);
                    ViewBag.IsEdit = true;
                }
                return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> Delete(int id)
            {
                await regionServiceAsync.DeleteRegionAsync(id);
                return RedirectToAction("Index");
            }
        }
    }
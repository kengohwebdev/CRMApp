using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Razor;


namespace Antra.CRMApp.WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public EmployeeController(IEmployeeServiceAsync empservice, IRegionServiceAsync reg)
        {
            employeeServiceAsync = empservice;
            regionServiceAsync = reg;
        }
        public async Task<IActionResult> Index()
        {
            var empCollection = await employeeServiceAsync.GetAllAsync();
            if (empCollection != null)
                return View(empCollection);

            List<EmployeeResponseModel> model = new List<EmployeeResponseModel>();
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
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
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
            var empModel = await employeeServiceAsync.GetEmployeeForEditAsync(id);
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.UpdateEmployeeAsync(model);
                ViewBag.IsEdit = true;
                
            }
            
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        { 
            await employeeServiceAsync.DeleteEmployeeAsync(id);
         return RedirectToAction("Index");
        }

        [NonAction]
        public void Demo()
        { 
        }


        public async Task<IActionResult> Detail()
        {
            var empCollection = await employeeServiceAsync.GetAllAsync();
            if (empCollection != null)
                return View(empCollection);

            List<EmployeeResponseModel> model = new List<EmployeeResponseModel>();
            return View(model);
        }
        
    }
}

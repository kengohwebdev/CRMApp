using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceAsync customerServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public CustomerController(ICustomerServiceAsync custservice, IRegionServiceAsync creg)
        {
            customerServiceAsync = custservice;
            regionServiceAsync = creg;
        }
        public async Task<IActionResult> Index()
        {
            var custCollection = await customerServiceAsync.GetAllAsync();
            if (custCollection != null)
                return View(custCollection);

            List<CustomerResponseModel> model = new List<CustomerResponseModel>();
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
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await customerServiceAsync.AddCustomerAsync(model);
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
            var custModel = await customerServiceAsync.GetCustomerForEditAsync(id);
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(custModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await customerServiceAsync.UpdateCustomerAsync(model);
                ViewBag.IsEdit = true;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await customerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }

      


    }
}

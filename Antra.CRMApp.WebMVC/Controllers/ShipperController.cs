﻿using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperServiceAsync shipperServiceAsync;
        public ShipperController(IShipperServiceAsync ser)
        {
            shipperServiceAsync = ser;
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




    }
}
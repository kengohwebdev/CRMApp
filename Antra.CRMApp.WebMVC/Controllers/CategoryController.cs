﻿using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;


namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryServiceAsync categoryServiceAsync;
        public CategoryController(ICategoryServiceAsync ser)
        {
            categoryServiceAsync = ser;
        }
        /* public IActionResult Index()
         {
             List<Category> category = new List<Category>();
             category.Add(new Category() { Id = 1, Name = "Laptop", Description = "Silver, Price = 2000" });
             category.Add(new Category() { Id = 2, Name = "Iphone", Description = "Black, Price = 1000" });
             category.Add(new Category() { Id = 3, Name = "Samsung Galaxy", Description = "Blue, Price = 900" });
             category.Add(new Category() { Id = 4, Name = "Chair", Description = "Wooden, Price = 120" });
             category.Add(new Category() { Id = 5, Name = "Table", Description = "White, Price = 250" });

             ViewData["Title"] = "Category/Index";
             return View(category);
         }*/
        public async Task<IActionResult> Index()
        {
            var result = await categoryServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.AddCategoryAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManager.Data;
using StockManager.Data.Entities;
using StockManager.IServices;
using StockManager.Models;

namespace StockManager.Controllers
{
    public class HomeController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;
        private IBrandService brandService;
        public HomeController(IProductService pService, ICategoryService categoryService, IBrandService brandService)
        {
            this.productService = pService;
            this.categoryService = categoryService;
            this.brandService = brandService;
        }
        public IActionResult Index()
        {
            return View(productService.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product product){
            if(ModelState.IsValid){
                this.productService.Create(product);
                return RedirectToAction("Add");
            }
            return View();
        }
        public IActionResult Add()
        {
            ViewData["brands"] = brandService.GetAll();
            ViewData["categories"] = categoryService.GetAll();
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

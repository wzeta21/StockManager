using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IHostingEnvironment hostingEvironmento;
        public HomeController(
            IProductService pService,
            ICategoryService categoryService,
            IBrandService brandService,
            IHostingEnvironment hostingEnvironment
        )
        {
            this.productService = pService;
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.hostingEvironmento = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View(productService.GetAll());
        }

        [HttpPost]
        [RequestSizeLimit(90_000_000)]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct()
        {
            bool res = false;
            var picturePostedFile = HttpContext.Request.Form.Files.GetFile("picture");
            string pictureUrl = this.SavePicture(picturePostedFile);

            var repo = HttpContext.Request.Form["product"];

            Product product = JsonConvert.DeserializeObject<Product>(repo);

            if (ModelState.IsValid && pictureUrl != null)
            {
                product.ImageUrl = pictureUrl;
                res = this.productService.Create(product);
                return RedirectToAction("Add");
            }
            return View(product);
        }
        public IActionResult Add()
        {
            ViewData["brands"] = brandService.GetAll();
            ViewData["categories"] = categoryService.GetAll();
            return View();
        }

        [HttpPost]
        
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                this.productService.Delete(id);
                return RedirectToAction("Index");
            }
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
        private string SavePicture(IFormFile picture)
        {
            bool res = false;

            if (picture == null)
                return null;

            string pictureName = new String(
                Path.GetFileNameWithoutExtension(picture.FileName)
                .Take(Path.GetFileNameWithoutExtension(picture.FileName).Length)
                .ToArray()
            );
            pictureName = pictureName + Path.GetExtension(picture.FileName);
            string picturePath = "/mitienda/products/ropa/" + pictureName;
            var filePath = hostingEvironmento.WebRootPath + picturePath;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                picture.CopyTo(stream);
                res = true;
            }
            return res ? picturePath : string.Empty;
        }
    }
}

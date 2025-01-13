using AnaBellaApp.Web.Models.Store;
using AnaBellaApp.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnaBellaApp.Web.Controllers.Store
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.CreateProduct(model);
                if (response != null) 
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            var model = await productService.FindProductById(id);
            if (model != null) 
                return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.UpdateProduct(model);
                if (response != null) 
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            var model = await productService.FindProductById(id);
            if (model != null) 
                return View(model);
            return NotFound();
        }

        [HttpPost]
        //[Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductViewModel model)
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            var response = await productService.DeleteProductById(model.Id);
            if (response) 
                return RedirectToAction(nameof(ProductIndex));
            return View(model);
        }
    }
}
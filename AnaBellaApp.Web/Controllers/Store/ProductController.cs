using AnaBellaApp.Web.Models.Store;
using AnaBellaApp.Web.Services.IServices;
using AnaBellaApp.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AnaBellaApp.Web.Controllers.Store
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await productService.FindAllProducts("");
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            var categories = await categoryService.FindAllCategories("");

            var listTemp = categories.ToList();
            var lstCategories = listTemp.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            if (categories != null)
            {
                ViewBag.Categories = lstCategories;
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categories = await categoryService.FindAllCategories("");

                var listTemp = categories.ToList();
                var lstCategories = listTemp.Select(x => new SelectListItem 
                        { 
                            Text = x.Name, 
                            Value = x.Id.ToString()
                        });

                if (categories != null)
                {
                    ViewBag.Categories = lstCategories;
                }

                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.CreateProduct(model, token);
                if (response != null) 
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await productService.FindProductById(id, token);
            if (model != null)
            {
                var categories = await categoryService.FindAllCategories("");

                var listTemp = categories.ToList();
                var lstCategories = listTemp.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                if (categories != null)
                {
                    ViewBag.Categories = lstCategories;
                }
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductUpdate(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.UpdateProduct(model, token);
                if (response != null) 
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await productService.FindProductById(id, token);
            if (model != null) 
                return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await productService.DeleteProductById(model.Id, token);
            if (response) 
                return RedirectToAction(nameof(ProductIndex));
            return View(model);
        }
    }
}
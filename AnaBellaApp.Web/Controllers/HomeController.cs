using AnaBellaApp.Web.Models;
using AnaBellaApp.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnaBellaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(
            ILogger<HomeController> logger,
            IProductService productService,
            ICategoryService categoryService)
        {
            this.logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.FindAllProducts("");
            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await productService.FindProductById(id, token);

            if (model != null)
            {
                var category = await categoryService.FindCategoryById(model.CategoryId, token);
                if (category != null)
                {
                    ViewBag.Category = category.Name;
                }
            }
            return View(model);
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

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}

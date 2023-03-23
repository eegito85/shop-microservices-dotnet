using EgitoShopping.Web.Models;
using EgitoShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EgitoShopping.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAll();
            return View(products);
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

        public async Task<IActionResult> Details(long id)
        {
            var model = await _productService.FindById(id);
            if (model != null) { return View(model); }

            return NotFound();
        }

    }
}
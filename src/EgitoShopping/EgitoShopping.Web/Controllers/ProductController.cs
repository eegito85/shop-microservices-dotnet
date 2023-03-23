using EgitoShopping.Web.Models;
using EgitoShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EgitoShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService)) ;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAll();

            return View(products);
        }

        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.Create(model);
                if(response != null) return RedirectToAction(nameof(ProductIndex));
            }
            
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var model = await _productService.FindById(id);
            if(model != null) { return View(model); }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.Update(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(long id)
        {
            var model = await _productService.FindById(id);
            if (model != null) { return View(model); }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var response = await _productService.DeleteById(model.Id);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }

    }
}

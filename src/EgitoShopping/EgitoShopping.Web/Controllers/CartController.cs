﻿using EgitoShopping.Web.Models;
using EgitoShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EgitoShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService,
            ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        
        public async Task<IActionResult> CartIndex()
        {
            return View(await FindUserCart());
        }

        public async Task<IActionResult> Remove(int id)
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.RemoveFromCart(id);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        private async Task<CartViewModel> FindUserCart()
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.FindCartByUserId(userId);

            if (response?.CartHeader != null)
            {
                foreach (var detail in response.CartDetails)
                {
                    response.CartHeader.PurchaseAmount += (detail.Product.Price * detail.Count);
                }
            }
            return response;
        }
    }
}


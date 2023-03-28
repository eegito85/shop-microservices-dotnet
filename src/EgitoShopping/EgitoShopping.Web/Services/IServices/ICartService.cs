﻿using EgitoShopping.Web.Models;

namespace EgitoShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId);
        Task<CartViewModel> AddItemToCart(CartViewModel cart);
        Task<CartViewModel> UpdateCart(CartViewModel cart);
        Task<bool> RemoveFromCart(long cartId);

        Task<bool> ApplyCoupon(CartViewModel cart, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);

        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader);
    }
}

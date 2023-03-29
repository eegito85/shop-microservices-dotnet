using EgitoShopping.Web.Models;
using EgitoShopping.Web.Services.IServices;
using EgitoShopping.Web.Utils;
using System.Net.Http.Headers;
using System.Reflection;

namespace EgitoShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId)
        {
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel model)
        {
            var url = $"{BasePath}/add-cart";
            var response = await _client.PostAsJson($"{BasePath}/add-cart", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel model)
        {
            var response = await _client.PutAsJson($"{BasePath}/update-cart", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> RemoveFromCart(long cartId)
        {
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart)
        {
            var response = await _client.PostAsJson($"{BasePath}/apply-coupon", cart);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartHeaderViewModel> Checkout(CartHeaderViewModel cartHeader)
        {
            var response = await _client.PostAsJson($"{BasePath}/checkout", cartHeader);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartHeaderViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var response = await _client.DeleteAsync($"{BasePath}/remove-coupon/{userId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}

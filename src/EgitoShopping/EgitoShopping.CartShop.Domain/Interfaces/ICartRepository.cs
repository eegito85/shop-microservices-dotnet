using EgitoShopping.CartShop.Domain.Entities;

namespace EgitoShopping.CartShop.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> FindCartByUserId(string userId);
        Task<Cart> SaveOrUpdateCart(Cart cart);
        Task<bool> RemoveFromCart(long cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);
    }
}

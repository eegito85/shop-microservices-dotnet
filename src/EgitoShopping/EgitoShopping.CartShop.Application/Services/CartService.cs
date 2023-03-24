using AutoMapper;
using EgitoShopping.CartShop.Application.DTOs;
using EgitoShopping.CartShop.Application.Services.Interfaces;
using EgitoShopping.CartShop.Domain.Entities;
using EgitoShopping.CartShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitoShopping.CartShop.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> ClearCart(string userId)
        {
            return await _repository.ClearCart(userId);
        }

        public async Task<CartDTO> FindCartByUserId(string userId)
        {
            Cart cart = await _repository.FindCartByUserId(userId);
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            return await _repository.RemoveFromCart(cartDetailsId);
        }

        public async Task<CartDTO> SaveOrUpdateCart(CartDTO cartDto)
        {
            Cart cart = _mapper.Map<Cart>(cartDto);
            cart = await _repository.SaveOrUpdateCart(cart);
            return _mapper.Map<CartDTO>(cart);
        }

        public Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

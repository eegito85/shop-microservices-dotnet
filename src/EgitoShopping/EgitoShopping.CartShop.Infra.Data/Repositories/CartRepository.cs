﻿using EgitoShopping.CartShop.Domain.Entities;
using EgitoShopping.CartShop.Domain.Interfaces;
using EgitoShopping.CartShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitoShopping.CartShop.Infra.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SqlContext _context;

        public CartRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> FindCartByUserId(string userId)
        {
            Cart cart = new() {
                CartHeader = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId),

            };
            cart.CartDetails = _context.CartDetails.
                Where(c => c.CartHeaderId == cart.CartHeader.Id).Include(c => c.Product);


            return cart;
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<Cart> SaveOrUpdateCart(Cart cart)
        {
            var product = await _context.Products.FirstOrDefaultAsync(
                p => p.Id == cart.CartDetails.FirstOrDefault().ProductId);
            
            if (product == null) 
            {
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null) 
            {
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;

                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    p.CartHeaderId == cartHeader.Id);

                if (cartDetail == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;

                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }

            }


            return cart;
        }
    }
}

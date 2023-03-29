using EgitoShopping.CartShop.Api.RabbitMQSender;
using EgitoShopping.CartShop.Application.DTOs;
using EgitoShopping.CartShop.Application.Services.Interfaces;
using EgitoShopping.CartShop.Domain.Entities;
using EgitoShopping.CartShop.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitoShopping.CartShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _service;
        private IRabbitMqMessageSender _rabbitMQMessageSender;

        public CartController(ICartService service, IRabbitMqMessageSender rabbitMQMessageSender)
        {
            _service = service ?? throw new
                ArgumentNullException(nameof(service));
            _rabbitMQMessageSender = rabbitMQMessageSender
                ?? throw new ArgumentNullException(nameof(rabbitMQMessageSender));
        }


        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartDTO>> FindById(string id)
        {
            var cart = await _service.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartDTO>> AddCart(CartDTO vo)
        {
            var cart = await _service.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO vo)
        {
            var cart = await _service.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartDTO>> RemoveCart(int id)
        {
            var status = await _service.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(CartDTO vo)
        {
            var status = await _service.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(string userId)
        {
            var status = await _service.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderDTO>> Checkout(CheckoutHeaderDTO vo)
        {
            if (vo?.UserId == null) return BadRequest();
            var cart = await _service.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();
            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            // RabbitMQ logic comes here!!!
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}

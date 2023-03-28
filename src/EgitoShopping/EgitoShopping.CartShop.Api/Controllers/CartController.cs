using EgitoShopping.CartShop.Application.DTOs;
using EgitoShopping.CartShop.Application.Services.Interfaces;
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

        public CartController(ICartService service)
        {
            _service = service ?? throw new
                ArgumentNullException(nameof(service));
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
    }
}

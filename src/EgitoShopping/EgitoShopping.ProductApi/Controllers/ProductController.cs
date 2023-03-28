using EgitoShopping.Product.Application.DTOs;
using EgitoShopping.Product.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitoShopping.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAllProducts() 
        {
            var products = await _service.FindAllAsync();
            if(products == null) { return NotFound("Produtos não encontrados"); }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetProductById(long id)
        {
            var product = await _service.FindByIdAsync(id);
            if (product == null || product.Id <= 0) { return NotFound("Produto não encontrado"); }

            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProdutoDTO>> CreateProduct([FromBody] ProdutoDTO product)
        {
            if (product == null) 
            { 
                return BadRequest("Não foi possível ciar o produto."); 
            }
            await _service.CreateAsync(product);

            return Ok(product);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProdutoDTO>> UpdateProduct([FromBody] ProdutoDTO product)
        {
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }
            try
            {
                await _service.UpdateAsync(product);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível atualizar o produto");
            }
            
            return Ok(product);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ProdutoDTO>> DeleteProduct(long id)
        {
            var product = await _service.FindByIdAsync(id);
            if (product == null) return NotFound();
            var result = await _service.DeleteByIdAsync(id);
            if (!result) return BadRequest("Não foi possível deletar o produto.");

            return Ok(result);
        }
    }
}

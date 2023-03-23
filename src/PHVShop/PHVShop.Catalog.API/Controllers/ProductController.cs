using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHVShop.Catalog.API.DTOs;
using PHVShop.Catalog.API.Services;

namespace PHVShop.Catalog.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<CategoryDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return BadRequest($"Não foi encontrado um produto com o Id: {id}");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (productDTO == null)
                return BadRequest();

            await _productService.CreateProduct(productDTO);

            return CreatedAtRoute("GetById", new { id = productDTO.Id}, productDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (productDTO == null)
                return BadRequest();

            if (id != productDTO.Id)
                return BadRequest("Id inválido");

            await _productService.UpdateProduct(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest("Id inválido");

            await _productService.DeleteProduct(id);

            return Ok($"Produto de Id: {id} deletada com sucesso.");
        }
    }
}

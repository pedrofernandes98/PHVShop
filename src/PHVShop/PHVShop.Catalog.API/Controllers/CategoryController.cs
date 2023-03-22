using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHVShop.Catalog.API.DTOs;
using PHVShop.Catalog.API.Services;

namespace PHVShop.Catalog.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategoriesProducts()
        {
            var categories = await _categoryService.GetAllCategoriesProducts();
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return BadRequest($"Não foi encontrada a categoria de Id: {id}");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (categoryDTO == null)
                return BadRequest();

            await _categoryService.CreateCategory(categoryDTO);

            return CreatedAtRoute("GetCategoryById", new {id = categoryDTO.CategoryId}, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (categoryDTO == null)
                return BadRequest();

            if(id != categoryDTO.CategoryId)
                return BadRequest("Id inválido");

            await _categoryService.UpdateCategory(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (id == 0)
                return BadRequest("Id inválido");

            await _categoryService.DeleteCategory(id);

            return Ok($"Categoria de Id: {id} deletada com sucesso.");
        }
    }
}

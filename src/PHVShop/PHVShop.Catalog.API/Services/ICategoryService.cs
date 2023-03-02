using PHVShop.Catalog.API.DTOs;

namespace PHVShop.Catalog.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();

        Task<IEnumerable<CategoryDTO>> GetAllCategoriesProducts();

        Task<CategoryDTO> GetCategoryById(int id);

        Task CreateCategory(CategoryDTO category);

        Task UpdateCategory(CategoryDTO category);

        Task DeleteCategory(int id);
    }
}

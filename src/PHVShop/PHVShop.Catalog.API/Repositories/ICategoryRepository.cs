using PHVShop.Catalog.API.Models;

namespace PHVShop.Catalog.API.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();

        public Task<IEnumerable<Category>> GetAllProductsAsync();

        public Task<Category> GetByIdAsync(int id);

        public Task CreateAsync(Category category);

        public Task UpdateAsync(Category category);

        public Task DeleteAsync(int id);
    }
}

using PHVShop.Catalog.API.Models;

namespace PHVShop.Catalog.API.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync();

        public Task<Product> GetByIdAsync(int id);

        public Task CreateAsync(Product product);

        public Task UpdateAsync(Product product);

        public Task DeleteAsync(int id);
    }
}

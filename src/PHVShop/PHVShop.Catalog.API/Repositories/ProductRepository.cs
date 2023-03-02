using Microsoft.EntityFrameworkCore;
using PHVShop.Catalog.API.Context;
using PHVShop.Catalog.API.Models;

namespace PHVShop.Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(c => c.Category)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Product product)
        {
            _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            
            if(product == null)
                throw new Exception($"Não foi encontrado um Produto com Id: {id}");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

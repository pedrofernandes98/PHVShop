using Microsoft.EntityFrameworkCore;
using PHVShop.Catalog.API.Context;
using PHVShop.Catalog.API.Models;

namespace PHVShop.Catalog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllProductsAsync()
        {
            return await _context.Categories
                            .Include(p => p.Products)
                            .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Where(x => x.CategoryId == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Category category)
        {
            _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);

            if (category == null)
                throw new Exception($"Não foi encontrado uma Categoria com Id: {id}");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

    }
}

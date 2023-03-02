using AutoMapper;
using PHVShop.Catalog.API.DTOs;
using PHVShop.Catalog.API.Models;
using PHVShop.Catalog.API.Repositories;

namespace PHVShop.Catalog.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);

        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task CreateCategory(CategoryDTO category)
        {
            if (category == null)
                throw new ArgumentNullException("A categoria não pode ser nula");

            var categoryEntity = _mapper.Map<Category>(category);

            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task UpdateCategory(CategoryDTO category)
        {
            if (category == null)
                throw new ArgumentNullException("A categoria não pode ser nula");

            var categoryEntity = _mapper.Map<Category>(category);

            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task DeleteCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(categoryEntity.Id);
        }
    }
}

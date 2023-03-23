using AutoMapper;
using PHVShop.Catalog.API.DTOs;
using PHVShop.Catalog.API.Models;
using PHVShop.Catalog.API.Repositories;

namespace PHVShop.Catalog.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var productsEntity = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task CreateProduct(ProductDTO product)
        {
            if (product == null)
                throw new ArgumentNullException("O producto não pode ser nulo");

            var productEntity = _mapper.Map<Product>(product);

            await _productRepository.CreateAsync(productEntity);
        }

        public async Task UpdateProduct(ProductDTO product)
        {
            if (product == null)
                throw new ArgumentNullException("O producto não pode ser nulo");

            var productEntity = _mapper.Map<Product>(product);

            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task DeleteProduct(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(productEntity.Id);
        }
    }
}

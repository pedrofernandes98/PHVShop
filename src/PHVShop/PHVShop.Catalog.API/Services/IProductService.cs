using PHVShop.Catalog.API.DTOs;

namespace PHVShop.Catalog.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task CreateProduct(ProductDTO productDto);
        Task UpdateProduct(ProductDTO productDto);
        Task DeleteProduct(int id);
    }
}

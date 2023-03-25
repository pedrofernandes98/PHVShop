using PHVShop.Web.Models;

namespace PHVShop.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();

        Task<ProductViewModel> GetProductById(int id);

        Task<ProductViewModel> CreateProduct(ProductViewModel product);

        Task<ProductViewModel> UpdateProduct(ProductViewModel product);

        Task<bool> DeleteProduct(int id);
    }
}

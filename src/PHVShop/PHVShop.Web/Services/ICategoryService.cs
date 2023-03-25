using PHVShop.Web.Models;

namespace PHVShop.Web.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        Task<CategoryViewModel> GetCategoryById(int id);
    }
}

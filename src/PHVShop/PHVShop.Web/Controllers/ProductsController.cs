using Microsoft.AspNetCore.Mvc;
using PHVShop.Web.Services;

namespace PHVShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();

            if (products == null)
                return View("Error");

            return View(products);
        }
    }
}

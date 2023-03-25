using PHVShop.Web.Models;
using System.Text.Json;

namespace PHVShop.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string URL_CATEGORY = "/api/category";
        private const string CLIENT_NAME = "CatalogApi";
        private readonly JsonSerializerOptions _options;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true};
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var _client = _clientFactory.CreateClient(CLIENT_NAME);

            using(var response = await _client.GetAsync(URL_CATEGORY))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseApi = await response.Content.ReadAsStreamAsync();

                    return JsonSerializer.Deserialize<IEnumerable<CategoryViewModel>>(responseApi, _options);
                }
            }

            return null;
        }

        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            var _client = _clientFactory.CreateClient(CLIENT_NAME);

            using (var response = await _client.GetAsync($"{URL_CATEGORY}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseApi = await response.Content.ReadAsStreamAsync();

                    return JsonSerializer.Deserialize<CategoryViewModel>(responseApi, _options);
                }
            }

            return null;
        }
    }
}

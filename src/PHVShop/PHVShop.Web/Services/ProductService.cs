using PHVShop.Web.Models;
using System.Text;
using System.Text.Json;

namespace PHVShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;
        private const string URL_PRODUCTS = "/api/product/";
        private const string CLIENT_NAME = "CatalogApi";

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var _client = _clientFactory.CreateClient("CatalogApi");

            using(var response = await _client.GetAsync(URL_PRODUCTS))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    return await 
                        JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
            }

            return null;

        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var _client = _clientFactory.CreateClient(CLIENT_NAME);

            using(var response = await _client.GetAsync($"{URL_PRODUCTS}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
            }

            return null;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
        {
            var _client = _clientFactory.CreateClient(CLIENT_NAME);

            StringContent content = new StringContent(JsonSerializer.Serialize(product), 
                Encoding.UTF8, "application/json");

            using (var response = await _client.PostAsync(URL_PRODUCTS, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseApi = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(responseApi, _options);
                }
            }

            return null;
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel product)
        {
            var _client = _clientFactory.CreateClient(CLIENT_NAME);

            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            using(var response = await _client.PutAsync($"{URL_PRODUCTS}/{product.Id}", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseApi = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(responseApi, _options);
                }
            }

            return null;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var _client = _clientFactory.CreateClient(CLIENT_NAME);

            using(var response = await _client.DeleteAsync($"{URL_PRODUCTS}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        

        
    }
}

using AnaBellaApp.Web.Models.Store;
using AnaBellaApp.Web.Services.IServices;
using AnaBellaApp.Web.Utils;
using System.Net.Http.Headers;

namespace AnaBellaApp.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindProductById(long id, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }
        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }
    }
}

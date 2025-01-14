using AnaBellaApp.Web.Models.Store;
using AnaBellaApp.Web.Services.IServices;
using AnaBellaApp.Web.Utils;
using System.Net.Http.Headers;

namespace AnaBellaApp.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient client;
        public const string BasePath = "api/v1/category";

        public CategoryService(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CategoryViewModel>> FindAllCategories(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync(BasePath);
            return await response.ReadContentAs<List<CategoryViewModel>>();
        }

        public async Task<CategoryViewModel> FindCategoryById(long id, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<CategoryViewModel>();
        }
    }
}

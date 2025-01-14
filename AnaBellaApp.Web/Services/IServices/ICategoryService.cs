using AnaBellaApp.Web.Models.Store;

namespace AnaBellaApp.Web.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> FindAllCategories(string token);
        Task<CategoryViewModel> FindCategoryById(long id, string token);
    }
}

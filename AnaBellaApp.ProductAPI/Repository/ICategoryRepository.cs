using AnaBellaApp.ProductAPI.Data.ValueObjects;

namespace AnaBellaApp.ProductAPI.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryVO>> FindAll();
        Task<CategoryVO> FindById(long id);
        Task<CategoryVO> Create(CategoryVO vo);
        Task<CategoryVO> Update(CategoryVO vo);
        Task<bool> Delete(long id);
    }
}

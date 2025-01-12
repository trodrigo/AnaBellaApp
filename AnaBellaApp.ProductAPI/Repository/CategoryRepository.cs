using AnaBellaApp.ProductAPI.Data.ValueObjects;
using AnaBellaApp.ProductAPI.Model;
using AnaBellaApp.ProductAPI.Model.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnaBellaApp.ProductAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MySQLContext context;
        private IMapper mapper;

        public CategoryRepository(MySQLContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryVO>> FindAll()
        {
            List<Category> categories = await context.Categories.ToListAsync();
            return mapper.Map<List<CategoryVO>>(categories);
        }

        public async Task<CategoryVO> FindById(long id)
        {
            Category category = await context.Categories
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<CategoryVO>(category);
        }

        public async Task<CategoryVO> Create(CategoryVO vo)
        {
            Category category = mapper.Map<Category>(vo);
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return mapper.Map<CategoryVO>(category);
        }

        public async Task<CategoryVO> Update(CategoryVO vo)
        {
            Category category = mapper.Map<Category>(vo);
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return mapper.Map<CategoryVO>(category);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Category category = await context.Categories
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if (category == null) 
                    return false;
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using AnaBellaApp.ProductAPI.Data.ValueObjects;
using AnaBellaApp.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnaBellaApp.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoryController(ICategoryRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVO>>> FindAll()
        {
            var products = await repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CategoryVO>> FindById(long id)
        {
            var product = await repository.FindById(id);
            if (product == null) return
                NotFound();
            return Ok(product);
        }
    }
}

using AnaBellaApp.ProductAPI.Data.ValueObjects;
using AnaBellaApp.ProductAPI.Repository;
using AnaBellaApp.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AnaBellaApp.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]        
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await repository.FindById(id);
            if (product == null) return 
                NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await repository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}

using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(int id) =>
            await productService.GetByIdAsync(id);

        [HttpGet]
        public async Task<List<ShortProductDto>> GetAllShortAsync() =>
            await productService.GetAllShortAsync();

        [HttpGet("bycategory/{categoryId}")]
        public async Task<List<ShortProductDto>> GetByCategoryShortAsync(int categoryId) =>
            await productService.GetByCategoryShortAsync(categoryId);

        [HttpPost("byids")]
        public async Task<List<ShortProductDto>> GetShortByIdsAsync([FromBody] List<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return new List<ShortProductDto>();
            }
            return await productService.GetShortByIdsAsync(ids);
        }
    }
}

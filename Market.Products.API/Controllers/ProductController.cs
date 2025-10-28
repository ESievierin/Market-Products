using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Market.Products.BLL.Models.Filters;
using Market.Products.Tools.Interfaces.Storage;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Market.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService, IMapper mapper, IImageManager imageManager) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(int id) =>
            await productService.GetByIdAsync(id);

        [HttpGet]
        public async Task<ShortProductDto[]> GetPaginatedShortAsync([FromQuery] FiltersPagination pagination) =>
            await productService.GetPaginatedShortAsync(pagination);

        [HttpPost("filter")]
        public async Task<ShortProductDto[]> GetFilteredProducts(ProductsFilterDto filter) =>
            await productService.GetFilteredShortAsync(filter);

        [HttpPost("byids")]
        public async Task<ShortProductDto[]> GetShortByIdsAsync([FromBody] int[] ids)
        {
            if (ids == null || !ids.Any())
            {
                return Array.Empty<ShortProductDto>();
            }
            return await productService.GetShortByIdsAsync(ids);
        }

        [HttpGet("details/{id}")]
        public async Task<ProductDetailsDto> GetProductDetailsByIdAsync(int id) =>
            await productService.GetProductDetailsByIdAsync(id);

        [HttpPost("create")]
        public async Task CreateAsync(CreateProductDto product) =>
            await productService.CreateAsync(product);

        [HttpPost("update")]
        public async Task UpdateAsync(ProductDto product) =>
            await productService.UpdateAsync(product);
    }
}

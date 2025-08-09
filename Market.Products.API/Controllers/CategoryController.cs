using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet("name/{id}")]
        public async Task<string> GetNameById(int id) =>
            await categoryService.GetNameByIdAsync(id);

        [HttpGet]
        public async Task<List<CategoryDto>> GetAllAsync() =>
            await categoryService.GetAllAsync();
    }
}

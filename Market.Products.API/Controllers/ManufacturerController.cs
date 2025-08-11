using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ManufacturerController(IManufacturerService manufacturerService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ManufacturerDto> GetByIdAsync(int id) =>
            await manufacturerService.GetByIdAsync(id);
    }
}

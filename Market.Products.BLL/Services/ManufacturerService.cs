using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using MediatR;

namespace Market.Products.BLL.Services
{
    public sealed class ManufacturerService(IMediator mediator) : IManufacturerService
    {
        public async Task<ManufacturerDto> GetByIdAsync(int id) =>
           await mediator.Send(new RequestHandlers.Manufacturer.GetManufacturerByIdQuery(id));
    }
}

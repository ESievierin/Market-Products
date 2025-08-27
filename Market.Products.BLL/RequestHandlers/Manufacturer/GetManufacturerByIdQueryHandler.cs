using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.BLL.Exceptions;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Manufacturer
{
    public record GetManufacturerByIdQuery(int Id) : IRequest<ManufacturerDto>;
    public sealed class GetManufacturerByIdQueryHandler(MarketProductsDbContext dbContext, IMapper mapper) : IRequestHandler<GetManufacturerByIdQuery, ManufacturerDto> 
    {
        public async Task<ManufacturerDto> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken) 
        {
            var manufacturer  = mapper.Map<ManufacturerDto>(await 
                dbContext.Manufacturers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
            );

            if (manufacturer == null)
            {
                throw new EntityNotFoundException<ManufacturerDbModel>(request.Id);
            }

            return manufacturer;
        }
    }
}

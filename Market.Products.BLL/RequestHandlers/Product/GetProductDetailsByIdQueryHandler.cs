using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.BLL.Exceptions;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetProductDetailsByIdQuery(int ProductId) : IRequest<ProductDetailsDto>;
    public sealed class GetProductDetailsByIdQueryHandler(MarketProductsDbContext dbContext, IMapper mapper) : IRequestHandler<GetProductDetailsByIdQuery, ProductDetailsDto>
    {
        public async Task<ProductDetailsDto> Handle(GetProductDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var productDetails = await dbContext.Products
                .AsNoTracking()
                .Where(p => p.Id == request.ProductId)
                .Select(p => new ProductDetailsDto 
                {
                    Description = p.Description,
                    Category = mapper.Map<CategoryDto>(p.Category),
                    Manufacturer = mapper.Map<ManufacturerDto>(p.Manufacturer)
                })
                .AsSplitQuery()
                .FirstOrDefaultAsync(cancellationToken);

            if (productDetails == null) 
            {
                throw new EntityNotFoundException<ProductDbModel>(request.ProductId);
            }

            return productDetails;
        }
    }
}

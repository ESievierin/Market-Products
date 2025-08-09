using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.BLL.Exceptions;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetProductByIdQuery(int id) : IRequest<ProductDto>;
    public sealed class GetProductByIdQueryHandler(MarketProductsDbContext dbContext, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) 
        { 
            var product = mapper.Map<ProductDto>(await
                dbContext.Products
                    .AsNoTracking()
                    .FirstAsync(p => p.Id == request.id, cancellationToken)
             );

            if (product == null) 
            {
                throw new EntityNotFoundException<ProductDbModel>(request.id);
            }

            return product;
        }
    }
}

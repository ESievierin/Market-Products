using Market.Products.BLL.DTO;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetAllShortProductsQuery() : IRequest<ShortProductDto[]>;
    public sealed class GetAllShortProductsQueryHandler(MarketProductsDbContext dbContext) : IRequestHandler<GetAllShortProductsQuery, ShortProductDto[]>
    {
        public async Task<ShortProductDto[]> Handle(GetAllShortProductsQuery request, CancellationToken cancellationToken) =>
           await dbContext.Products
               .AsNoTracking()
               .Select(p => new ShortProductDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
               })
               .ToArrayAsync(cancellationToken);
    }
}

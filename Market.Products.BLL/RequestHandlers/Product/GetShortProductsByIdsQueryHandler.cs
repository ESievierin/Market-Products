using Market.Products.BLL.DTO;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetShortProductsByIdsQuery(int[] ids) : IRequest<ShortProductDto[]>;
    public sealed class GetShortProductsByIdsQueryHandler(MarketProductsDbContext dbContext) : IRequestHandler<GetShortProductsByIdsQuery, ShortProductDto[]>
    {
        public async Task<ShortProductDto[]> Handle(GetShortProductsByIdsQuery request, CancellationToken cancellationToken) =>
            await dbContext.Products
                .AsNoTracking()
                .Where(p => request.ids.Contains(p.Id))
                .Select(p => new ShortProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToArrayAsync(cancellationToken);
    }
}

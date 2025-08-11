using Market.Products.BLL.DTO;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetShortProductsByCategoryQuery(int CategoryId) : IRequest<ShortProductDto[]>;
    public sealed class GetShortProductsByCategoryQueryHandler(MarketProductsDbContext dbContext) : IRequestHandler<GetShortProductsByCategoryQuery, ShortProductDto[]>
    {
        public async Task<ShortProductDto[]> Handle(GetShortProductsByCategoryQuery request, CancellationToken cancellationToken) =>
            await dbContext.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == request.CategoryId)
                .Select(p => new ShortProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToArrayAsync(cancellationToken);
    }
}

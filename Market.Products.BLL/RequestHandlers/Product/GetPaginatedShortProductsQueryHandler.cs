using Market.Products.BLL.DTO;
using Market.Products.BLL.Models.Filters;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetPaginatedShortProductsQuery(FiltersPagination Pagination) : IRequest<ShortProductDto[]>;
    public sealed class GetPaginatedShortProductsQueryHandler(MarketProductsDbContext dbContext) : IRequestHandler<GetPaginatedShortProductsQuery, ShortProductDto[]>
    {
        public async Task<ShortProductDto[]> Handle(GetPaginatedShortProductsQuery request, CancellationToken cancellationToken) =>
           await dbContext.Products
               .AsNoTracking()
               .Select(p => new ShortProductDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
               })
               .Skip(request.Pagination.PageSize * request.Pagination.PageNumber)
               .Take(request.Pagination.PageSize)
               .ToArrayAsync(cancellationToken);
    }
}

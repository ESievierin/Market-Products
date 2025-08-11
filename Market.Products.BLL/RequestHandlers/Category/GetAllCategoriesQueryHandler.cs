using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Category
{
    public record GetAllCategoriesQuery() : IRequest<CategoryDto[]>;
    public sealed class GetAllCategoriesQueryHandler(MarketProductsDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, CategoryDto[]>
    {
        public async Task<CategoryDto[]> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) =>
            mapper.Map<CategoryDto[]>(await 
                dbContext.Categories
                    .AsNoTracking()
                    .ToArrayAsync(cancellationToken)
            );
    }
}

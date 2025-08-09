using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Category
{
    public record GetAllCategoriesQuery() : IRequest<List<CategoryDto>>;
    public sealed class GetAllCategoriesQueryHandler(MarketProductsDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) =>
            mapper.Map<List<CategoryDto>>(await 
                dbContext.Categories
                    .AsNoTracking()
                    .ToListAsync(cancellationToken)
            );
    }
}

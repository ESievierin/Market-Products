using Market.Products.BLL.Exceptions;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Category
{
    public record GetCategoryNameByIdQuery(int id) : IRequest<string>;
    public sealed class GetCategoryNameByIdQueryHandler(MarketProductsDbContext dbContext) : IRequestHandler<GetCategoryNameByIdQuery, string>
    {
        public async Task<string> Handle(GetCategoryNameByIdQuery request, CancellationToken cancellationToken) 
        { 
            var categoryName = await dbContext.Categories
                .AsNoTracking()
                .Where(c => c.Id == request.id)
                .Select(c => c.Name)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (categoryName == null) 
            {
                throw new EntityNotFoundException<CategoryDbModel>(request.id);
            }
            
            return categoryName;
        }

    }
}

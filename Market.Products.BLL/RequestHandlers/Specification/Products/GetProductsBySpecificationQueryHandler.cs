using Market.Products.BLL.Models.Filters;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Specification.Products
{
    public record GetProductsBySpecificationQuery
    (ISpecification<ProductDbModel> FilterSpecification, FiltersPagination Pagination,
        IQueryable<ProductDbModel>? InitialQuery = null,
        OrderByProductPriceSpecification? OrderSpecification = null ) : IRequest<ProductDbModel[]>;
    public sealed class GetProductsBySpecificationQueryHandler(MarketProductsDbContext dbContext) : IRequestHandler<GetProductsBySpecificationQuery, ProductDbModel[]>
    {
        public Task<ProductDbModel[]> Handle(GetProductsBySpecificationQuery request, CancellationToken cancellationToken)
        {
            var initialQuery = request.InitialQuery ?? dbContext.Products.AsQueryable();

            if(request.OrderSpecification != null) 
            {
                initialQuery = initialQuery.OrderBy(request.OrderSpecification.SpecifiedBy);
            }

            return initialQuery
                .Where(request.FilterSpecification.SpecifiedBy)
                .Skip(request.Pagination.PageSize * request.Pagination.PageNumber)
                .Take(request.Pagination.PageSize)
                .AsSplitQuery()
                .ToArrayAsync(cancellationToken);
        }
    }
}

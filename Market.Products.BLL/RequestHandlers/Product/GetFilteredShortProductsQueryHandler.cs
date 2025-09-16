using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.BLL.Models.Filters;
using Market.Products.BLL.RequestHandlers.Specification.Products;
using Market.Products.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record GetFilteredShortProductsQuery(ProductsFilterDto Filter) : IRequest<ShortProductDto[]>;
    public sealed class GetFilteredShortProductsQueryHandler(MarketProductsDbContext dbContext, IMediator mediator, IMapper mapper) : IRequestHandler<GetFilteredShortProductsQuery, ShortProductDto[]>
    {
        public async Task<ShortProductDto[]> Handle(GetFilteredShortProductsQuery request, CancellationToken cancellationToken)
        {
            var InitialQuery = dbContext.Products.AsQueryable();

            var filter = ProductsByFilterSpecification.Build(request.Filter);

            var pagination = (FiltersPagination)request.Filter;

            OrderByProductPriceSpecification? orderSpecification = null;

            if (request.Filter.OrderByPrice != null) 
            {
                orderSpecification = new OrderByProductPriceSpecification(request.Filter.OrderByPrice.Value);
            }

            var products = await mediator.Send(new GetProductsBySpecificationQuery(
                filter,
                pagination,
                InitialQuery,
                orderSpecification
            ), cancellationToken);

            return mapper.Map<ShortProductDto[]>(products);
        }
    

    }
}

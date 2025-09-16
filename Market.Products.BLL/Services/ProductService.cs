using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Market.Products.BLL.Models.Filters;
using Market.Products.BLL.RequestHandlers.Product;
using MediatR;

namespace Market.Products.BLL.Services
{
    public sealed class ProductService(IMediator mediator) : IProductService
    {
        public async Task<ShortProductDto[]> GetPaginatedShortAsync(FiltersPagination pagination) =>
            await mediator.Send(new GetPaginatedShortProductsQuery(pagination));

        public async Task<ShortProductDto[]> GetFilteredShortAsync(ProductsFilterDto filter) =>
            await mediator.Send(new GetFilteredShortProductsQuery(filter));

        public async Task<ProductDto> GetByIdAsync(int id) =>
            await mediator.Send(new GetProductByIdQuery(id));

        public async Task<ProductDetailsDto> GetProductDetailsByIdAsync(int id) =>
            await mediator.Send(new GetProductDetailsByIdQuery(id));

        public async Task<ShortProductDto[]> GetShortByIdsAsync(int[] ids) =>
            await mediator.Send(new GetShortProductsByIdsQuery(ids));
    }
}

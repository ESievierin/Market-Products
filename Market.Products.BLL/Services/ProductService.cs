using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Market.Products.BLL.RequestHandlers.Product;
using MediatR;

namespace Market.Products.BLL.Services
{
    public sealed class ProductService(IMediator mediator) : IProductService
    {
        public async Task<List<ShortProductDto>> GetAllShortAsync() =>
            await mediator.Send(new GetAllShortProductsQuery());

        public async Task<List<ShortProductDto>> GetByCategoryShortAsync(int categoryId) =>
            await mediator.Send(new GetShortProductsByCategoryQuery(categoryId));

        public async Task<ProductDto> GetByIdAsync(int id) =>
            await mediator.Send(new GetProductByIdQuery(id));

        public async Task<List<ShortProductDto>> GetShortByIdsAsync(List<int> ids) =>
            await mediator.Send(new GetShortProductsByIdsQuery(ids));
    }
}

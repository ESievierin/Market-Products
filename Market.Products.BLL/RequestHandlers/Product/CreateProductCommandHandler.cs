using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record CreateProductCommand(ProductDto Product) : IRequest;
    public sealed class CreateProductCommandHandler(MarketProductsDbContext dbContext, IMapper mapper, TimeProvider timeProvider) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<ProductDbModel>(request.Product);
            product.CreatedAt = timeProvider.GetUtcNow();
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

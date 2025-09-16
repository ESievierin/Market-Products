using AutoMapper;
using Market.Products.BLL.DTO;
using Market.Products.DAL.DbModels;
using Market.Products.DAL.EF;
using MediatR;

namespace Market.Products.BLL.RequestHandlers.Product
{
    public record UpdateProductCommand(ProductDto Product) : IRequest;
    public sealed class UpdateProductCommandHandler(MarketProductsDbContext dbContext, IMapper mapper) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            dbContext.Products.Update(mapper.Map<ProductDbModel>(request.Product));
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

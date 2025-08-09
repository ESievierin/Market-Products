using Market.Products.BLL.DTO;
using Market.Products.BLL.Interfaces;
using Market.Products.BLL.RequestHandlers.Category;
using MediatR;

namespace Market.Products.BLL.Services
{
    public sealed class CategoryService(IMediator mediator) : ICategoryService
    {
        public async Task<List<CategoryDto>> GetAllAsync() =>
            await mediator.Send(new GetAllCategoriesQuery());

        public async Task<string> GetNameByIdAsync(int categoryId) =>
            await mediator.Send(new GetCategoryNameByIdQuery(categoryId));
    }
}

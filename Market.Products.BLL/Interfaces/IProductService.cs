using Market.Products.BLL.DTO;
using Market.Products.BLL.Models.Filters;

namespace Market.Products.BLL.Interfaces
{
    public interface IProductService
    {
        public Task<ShortProductDto[]> GetPaginatedShortAsync(FiltersPagination pagination);
        public Task<ShortProductDto[]> GetShortByIdsAsync(int[] ids);
        public Task<ShortProductDto[]> GetFilteredShortAsync(ProductsFilterDto filter);
        public Task<ProductDto> GetByIdAsync(int id);
        public Task<ProductDetailsDto> GetProductDetailsByIdAsync(int id);
    }
}

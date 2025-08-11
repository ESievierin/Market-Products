using Market.Products.BLL.DTO;

namespace Market.Products.BLL.Interfaces
{
    public interface IProductService
    {
        public Task<ShortProductDto[]> GetAllShortAsync();
        public Task<ShortProductDto[]> GetShortByIdsAsync(int[] ids);
        public Task<ShortProductDto[]> GetByCategoryShortAsync(int categoryId);
        public Task<ProductDto> GetByIdAsync(int id);

    }
}

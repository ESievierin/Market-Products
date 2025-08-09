using Market.Products.BLL.DTO;

namespace Market.Products.BLL.Interfaces
{
    public interface IProductService
    {
        public Task<List<ShortProductDto>> GetAllShortAsync();
        public Task<List<ShortProductDto>> GetShortByIdsAsync(List<int> ids);
        public Task<List<ShortProductDto>> GetByCategoryShortAsync(int categoryId);
        public Task<ProductDto> GetByIdAsync(int id);

    }
}

using Market.Products.BLL.DTO;

namespace Market.Products.BLL.Interfaces
{
    public interface IProductService
    {
        public Task<ShortProductDto[]> GetAllShortAsync();
        public Task<ShortProductDto[]> GetShortByIdsAsync(int[] ids);
        public Task<ShortProductDto[]> GetByCategoryShortAsync(int categoryId);
        public Task<ProductDto> GetByIdAsync(int id);
        public Task<ProductDetailsDto> GetProductDetailsByIdAsync(int id);
        public Task UpdateAsync(ProductDto product);
        public Task CreateAsync(ProductDto product);
    }
}

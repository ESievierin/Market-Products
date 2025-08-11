using Market.Products.BLL.DTO;

namespace Market.Products.BLL.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryDto[]> GetAllAsync();
        public Task<string> GetNameByIdAsync(int categoryId);
    }
}

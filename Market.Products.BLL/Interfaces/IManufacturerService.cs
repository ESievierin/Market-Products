using Market.Products.BLL.DTO;

namespace Market.Products.BLL.Interfaces
{
    public interface IManufacturerService
    {
        public Task<ManufacturerDto> GetByIdAsync(int id);
    }
}

namespace Market.Products.BLL.DTO
{
    public sealed class ProductDetailsDto
    {
        public string Description { get; set; } = null!;
        public ManufacturerDto Manufacturer { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
    }
}

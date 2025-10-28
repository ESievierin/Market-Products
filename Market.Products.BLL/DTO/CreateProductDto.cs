namespace Market.Products.BLL.DTO
{

    public sealed class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }

        public string? Base64ImageData { get; set; }
    }
}

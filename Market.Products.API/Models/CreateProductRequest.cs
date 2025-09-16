namespace Market.Products.API.Models
{
    public sealed class CreateProductRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
    }
}

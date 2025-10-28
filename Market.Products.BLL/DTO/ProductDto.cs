using Market.Products.BLL.Models.Filters;
using System.Text.Json.Serialization;

namespace Market.Products.BLL.DTO
{
    public sealed class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public Guid? ImageKey { get; set; }
    }

    public sealed class ProductsFilterDto : FiltersPagination
    {
        public int[]? Categories { get; set; }
        public int[]? Manufacturers { get; set; }
        public PriceRange? Price { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderByMode? OrderByPrice { get; set; }

    }
}

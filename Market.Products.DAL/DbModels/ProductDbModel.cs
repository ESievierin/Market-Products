using System.ComponentModel.DataAnnotations;

namespace Market.Products.DAL.DbModels
{
    public sealed class ProductDbModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public Guid? ImageKey { get; set; }

        public CategoryDbModel Category { get; set; } = null!;
        public ManufacturerDbModel Manufacturer { get; set; } = null!;
    }
}

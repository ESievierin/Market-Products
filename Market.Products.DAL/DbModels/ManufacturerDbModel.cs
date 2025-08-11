using System.ComponentModel.DataAnnotations;

namespace Market.Products.DAL.DbModels
{
    public sealed class ManufacturerDbModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        public ICollection<ProductDbModel>? Products { get; set; }
    }
}

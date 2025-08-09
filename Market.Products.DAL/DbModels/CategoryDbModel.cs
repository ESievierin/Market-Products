using System.ComponentModel.DataAnnotations;

namespace Market.Products.DAL.DbModels
{
    public sealed class CategoryDbModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<ProductDbModel>? Products { get; set; }
    }
}

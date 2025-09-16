using Market.Products.DAL.DbModels;
using System.Linq.Expressions;

namespace Market.Products.BLL.RequestHandlers.Specification.Products
{
    public sealed class ProductsByCategoriesSpecification : ISpecification<ProductDbModel>
    {
        public ProductsByCategoriesSpecification(int[] categories) 
        {
            SpecifiedBy = x => categories.Contains(x.CategoryId);
        }

        public Expression<Func<ProductDbModel, bool>> SpecifiedBy { get; }
        }
}

using Market.Products.DAL.DbModels;
using System.Linq.Expressions;

namespace Market.Products.BLL.RequestHandlers.Specification.Products
{
    public sealed class ProductsByManufacturersSpecification : ISpecification<ProductDbModel>
    {
        public ProductsByManufacturersSpecification(int[] manufacturers) 
        {
            SpecifiedBy = x => manufacturers.Contains(x.ManufacturerId);
        }

        public Expression<Func<ProductDbModel, bool>> SpecifiedBy { get; }
    }
}

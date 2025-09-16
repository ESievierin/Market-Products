using Market.Products.BLL.Extensions;
using Market.Products.BLL.Models.Filters;
using Market.Products.DAL.DbModels;
using System.Linq.Expressions;

namespace Market.Products.BLL.RequestHandlers.Specification.Products
{
    
    public sealed class ProductsByPriceSpecification : ISpecification<ProductDbModel>
    {
        public ProductsByPriceSpecification(PriceRange priceRange)
        {
            SpecifiedBy = x => true;

            if (priceRange is null)
            {
                return;
            }

            SpecifiedBy = SpecifiedBy.And(BuildPriceFilter(priceRange));
        }

        public Expression<Func<ProductDbModel, bool>> SpecifiedBy { get; }

        private static Expression<Func<ProductDbModel, bool>> BuildPriceFilter(PriceRange priceRange)
        {
            Expression<Func<ProductDbModel, bool>> result = x => true;

            if (priceRange?.Min != null)
            {
                result = result.And(x => x.Price >= priceRange.Min);
            }

            if (priceRange?.Max != null)
            {
                result = result.And(x => x.Price <= priceRange.Max);
            }

            return result;
        }
    }
}


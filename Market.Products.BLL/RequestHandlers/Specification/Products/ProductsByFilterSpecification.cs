using Market.Products.BLL.DTO;
using Market.Products.BLL.Extensions;
using Market.Products.DAL.DbModels;
using System.Linq.Expressions;

namespace Market.Products.BLL.RequestHandlers.Specification.Products
{
    public sealed class ProductsByFilterSpecification : ISpecification<ProductDbModel>
    {
        private ProductsByFilterSpecification(List<ISpecification<ProductDbModel>> filters) 
        {
            SpecifiedBy = x => true;
            foreach (var specification in filters) 
            {
                SpecifiedBy = SpecifiedBy.And(specification.SpecifiedBy);
            }
        }
        public Expression<Func<ProductDbModel, bool>> SpecifiedBy { get; }

        public static ISpecification<ProductDbModel> Build(ProductsFilterDto requestFilter) 
        {
            var specifications = new List<ISpecification<ProductDbModel>>();
            specifications
                .AddIfNotEmpty(requestFilter.Categories, ids => new ProductsByCategoriesSpecification(ids))
                .AddIfNotEmpty(requestFilter.Manufacturers, ids => new ProductsByManufacturersSpecification(ids));

            if (requestFilter.Price is not null)
            {
                specifications.Add(new ProductsByPriceSpecification(requestFilter.Price));
            }

            return new ProductsByFilterSpecification(specifications);
        }
    }
}

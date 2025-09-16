using Market.Products.BLL.DTO;
using Market.Products.BLL.Models.Filters;
using Market.Products.DAL.DbModels;
using System.Linq.Expressions;

namespace Market.Products.BLL.RequestHandlers.Specification.Products
{
    public sealed class OrderByProductPriceSpecification
    {
        public OrderByProductPriceSpecification(OrderByMode orderMode) 
        {
            SpecifiedBy = orderMode switch
            {
                OrderByMode.Asc => x => x.Price,
                OrderByMode.Desc => x => -x.Price,
            };
        }
            
        public Expression<Func<ProductDbModel, decimal>> SpecifiedBy { get; }
    }
}

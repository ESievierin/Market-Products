using System.Linq.Expressions;

namespace Market.Products.BLL.RequestHandlers.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecifiedBy { get; }
    }
}

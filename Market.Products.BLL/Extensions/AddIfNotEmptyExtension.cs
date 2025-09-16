using Market.Products.BLL.RequestHandlers.Specification;

namespace Market.Products.BLL.Extensions
{
    public static class AddIfNotEmptyExtension
    {
        public static List<ISpecification<T>> AddIfNotEmpty<T,TSpecification>(this List<ISpecification<T>> specifications, int[]? ids, Func<int[], TSpecification> createSpecification)
            where TSpecification : ISpecification<T>
        {
            if (ids?.Length > 0) 
                specifications.Add(createSpecification(ids));

            return specifications;
        }
    }
}

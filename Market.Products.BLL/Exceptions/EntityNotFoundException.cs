namespace Market.Products.BLL.Exceptions
{
    public sealed class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException() 
        {
        }
        public EntityNotFoundException(int entityId)
            : base($" Entity with requested id not found. Entity type : {typeof(T)} Requested id : {entityId}")
        {
        }
    }
}

namespace Market.Products.Tools.Interfaces.Storage
{
    public interface IImageManager
    {
        public Task<Guid> UploadImageToFileStorageAsync(string Base64ImageData);
        public string GetImageUrlByKey(Guid? key);
    }
}

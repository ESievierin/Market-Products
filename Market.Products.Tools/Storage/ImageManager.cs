using Market.Products.Tools.Interfaces.Storage;
using Microsoft.Extensions.Configuration;

namespace Market.Products.Tools.Storage
{
    public sealed class ImageManager(IFileStorageService fileStorageService, IConfiguration config) : IImageManager
    {
        private readonly string imageBaseKey = config["Images:BaseKey"];
        private readonly string contentType = config["Images:ContentType"];

        public string GetImageUrlByKey(Guid? key)
        {
            if(key is null)
            {
                return fileStorageService.GetPublicUrl(string.Format(imageBaseKey, "placeholder"));
            }
            return fileStorageService.GetPublicUrl(string.Format(imageBaseKey, key));
        }

        public async Task<Guid> UploadImageToFileStorageAsync(string Base64ImageData)
        {
            var bytes = Convert.FromBase64String(Base64ImageData);
            using var stream = new MemoryStream(bytes);
            var productImageKey = Guid.NewGuid();
            var fullImageKey = string.Format(imageBaseKey, productImageKey);
            await fileStorageService.UploadAsync(fullImageKey, stream, contentType);

            return productImageKey;
        }
    }
}

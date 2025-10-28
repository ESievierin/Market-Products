using Amazon.S3;
using Amazon.S3.Model;
using Market.Products.Tools.Interfaces.Storage;
using Microsoft.Extensions.Configuration;

namespace Market.Products.Tools.Storage
{
    public class S3FileStorageService(IAmazonS3 s3Client, IConfiguration config) : IFileStorageService
    {
        private readonly string bucketName = config["AWS:BucketName"];
        public async Task<string> UploadAsync(string key, Stream stream, string contentType, CancellationToken ct = default)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                InputStream = stream,
                ContentType = contentType,
            };

            await s3Client.PutObjectAsync(request, ct);
            return key;
        }

        public async Task DeleteAsync(string key, CancellationToken ct = default)
        {
            await s3Client.DeleteObjectAsync(bucketName, key, ct);
        }

        public string GetPublicUrl(string key)
        {
            return $"https://{bucketName}.s3.amazonaws.com/{key}";
        }
    }
}

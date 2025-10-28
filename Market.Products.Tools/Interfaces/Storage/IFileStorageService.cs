using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Products.Tools.Interfaces.Storage
{
    public interface IFileStorageService
    {
        Task<string> UploadAsync(string key, Stream stream, string contentType, CancellationToken ct = default);
        Task DeleteAsync(string key, CancellationToken ct = default);
        string GetPublicUrl(string key);
    }
}

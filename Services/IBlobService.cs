using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Services
{
    public interface IBlobService
    {
        string GetBlob(string name, string containerName);
        Task<IEnumerable<string>> AllBlobs(string containerName);
        Task<bool> UploadBlob(string name, IFormFile file, string containerName);
        Task<bool> DeleteBlob(string name, string containerName);
    }
}

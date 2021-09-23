using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;

        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }


        public async Task<IEnumerable<string>> AllBlobs(string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var files = new List<string>();
            var blobs = containerClient.GetBlobsAsync();

            await foreach(var item in blobs)
            {
                files.Add(item.Name);
            }

            return files;
        }

        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            return await blobClient.DeleteIfExistsAsync();
        }

        public string GetBlob(string name, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            var HttpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var res = await blobClient.UploadAsync(file.OpenReadStream(), HttpHeaders);

            if(res != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}

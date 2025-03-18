//using Microsoft.AspNetCore.Http;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;
//using System.Threading.Tasks;

//namespace RamSoft_Task_Tool.Model
//{
//     public interface IBlobStorageService
//    {
//        Task<string> UploadImageAsync(IFormFile file, string taskId);
//    }

//    public class BlobStorageService : IBlobStorageService
//    {
//        private readonly string _connectionString = "YourAzureBlobStorageConnectionString";
//        private readonly string _containerName = "taskimages";

//        public async Task<string> UploadImageAsync(IFormFile file, string taskId)
//        {
//            var blobClient = CloudStorageAccount
//                .Parse(_connectionString)
//                .CreateCloudBlobClient();

//            var container = blobClient.GetContainerReference(_containerName);
//            await container.CreateIfNotExistsAsync();

//            var blob = container.GetBlockBlobReference($"{taskId}/{file.FileName}");
//            blob.Properties.ContentType = file.ContentType;

//            using (var stream = file.OpenReadStream())
//            {
//                await blob.UploadFromStreamAsync(stream);
//            }

//            return blob.Uri.ToString(); // Return the URL of the uploaded image
//        }
//    }
//}

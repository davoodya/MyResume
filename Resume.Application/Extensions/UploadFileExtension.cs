using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Resume.Application.Extensions
{
    public static class UploadFileExtension
    {
        public static async Task AddImageAjaxToServer(this IFormFile file, string fileName, string originalPath)
        {
            if(!Directory.Exists(originalPath))
                Directory.CreateDirectory(originalPath);

            string OriginalPath = originalPath + fileName;

            using (var stream = new FileStream(OriginalPath,FileMode.Create))
            {
                if (!Directory.Exists(OriginalPath)) await file.CopyToAsync(stream);
            }
        }
    }
}

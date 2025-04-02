using Government.Contracts.Documents.cs;
using Government.Contracts.Fields;

namespace Government.ApplicationServices.Files
{
    public class FileService(IWebHostEnvironment env) : IFileService
    {
        private readonly IWebHostEnvironment env = env;

        public async Task<string> UploadFile(IFormFile file)
        {


            var docsFolder = Path.Combine(env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "upload");

            Directory.CreateDirectory(docsFolder);

            var fileCount = Directory.GetFiles(docsFolder).Length + 1;

            var fileName = $"{fileCount}_{file.FileName}";
            var filePath = Path.Combine(docsFolder, fileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"https://government-services.runasp.net/docs/{fileName}";

        }
    }
}

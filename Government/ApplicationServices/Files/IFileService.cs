namespace Government.ApplicationServices.Files
{
    public interface IFileService
    {

        Task<string> UploadFile(IFormFile file);
    }
}

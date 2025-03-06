namespace Government.Contracts.Request.Submiting
{
    public record SubmitRequestDto(

      [FromForm] string UserId,
       [FromForm] int ServiceId,
       [FromForm] IFormFile[] Files,  // 🔥 غيرنا List<IFormFile> إلى IFormFile[]
       [FromForm] List<ServiceDataDto> ServiceData

 );
}



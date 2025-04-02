namespace Government.Contracts.Request.Submiting
{
    public record SubmitRequestDto(

       [FromForm] int ServiceId,
       [FromForm] IFormFile[] Files,  
       [FromForm] List<ServiceDataDto> ServiceData

 );
}



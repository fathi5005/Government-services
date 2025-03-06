namespace Government.Contracts.Request.Submiting
{
    public record SubmitResponseDto
        (
          int requestId,
        string message = " تم اتمام طلبك بنجاح" 
      
        );
   
}

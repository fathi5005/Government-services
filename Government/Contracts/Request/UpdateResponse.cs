namespace Government.Contracts.Request
{
    public record UpdateResponse
     (
          int requestId,
         string message = " تم تعديل طلبك بنجاح"

     );
}

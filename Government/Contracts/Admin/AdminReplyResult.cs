namespace Government.Contracts.Admin
{
    public record AdminReplyResult(string Message = "Response added and request updated successfully.", int? RequestId =null);


}

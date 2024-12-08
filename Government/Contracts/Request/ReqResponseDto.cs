namespace Government.Contracts.Request
{
    public record ReqResponseDto
        (
        int RequestID,
        string ServiceName,
        DateTime RequestDate,
        string RequestStatus, 
        string ResponseStatus 
        );
    
}

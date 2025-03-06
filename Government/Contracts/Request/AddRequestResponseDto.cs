namespace Government.Contracts.Request
{
    public record AddRequestResponseDto
        (
        int RequestID,
        string ServiceName,
        DateTime RequestDate,
        string RequestStatus, 
        string ResponseStatus 
        );
    
}



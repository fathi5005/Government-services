namespace Government.Contracts.Request
{
    public record RequestsDetailstoUser
     (
     int RequestID,
     string ServiceName,
     DateTime RequestDate,
     string RequestStatus,
     string ResponseStatus,
     string ResponseText
     );
}

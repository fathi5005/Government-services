namespace Government.Contracts.Request
{
    public record RequestsDetailstoUser
     (
     int RequestId,
     int ServiceId,
     string ServiceName,
     DateTime RequestDate,
     string RequestStatus,
     string ResponseStatus,
     string ResponseText
     );
}

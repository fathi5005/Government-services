namespace Government.Contracts.Services
{
    public record AddServiceRequest
    (
        string ServiceName,
        string ServiceDescription,
        decimal Fee,
        string ProcessingTime,
        string ContactInfo
    );
}

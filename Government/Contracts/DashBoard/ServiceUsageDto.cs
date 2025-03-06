namespace Government.Contracts.DashBoard
{
    public record ServiceUsageDto
    (
        int ServiceId,
        string ServiceName,
        int RequestCount
    );

}

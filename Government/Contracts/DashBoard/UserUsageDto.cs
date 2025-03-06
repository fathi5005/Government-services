namespace Government.Contracts.DashBoard
{
    public record UserUsageDto
        (
        string UserId, 
        string FullName,
        int RequestCount
        );

   

}

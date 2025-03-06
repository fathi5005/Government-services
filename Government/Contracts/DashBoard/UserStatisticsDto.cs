namespace Government.Contracts.DashBoard
{
   

    public record UserStatisticsDto
        (
        int NewUsersThisMonth ,
        int ActiveUsers, 
        List<UserUsageDto> MostActiveUsers);

}

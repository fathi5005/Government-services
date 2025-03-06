namespace Government.Contracts.DashBoard
{
    public record RequestStatisticsDto(

         int NewRequestsThisMonth,
         int CompletedRequests,
         int RejectedRequests,
         int PendingRequests,
         List<UserUsageDto> TopRequestUsers
 );

}

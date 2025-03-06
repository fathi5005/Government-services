namespace Government.Contracts.DashBoard
{
    public record ServiceStatisticsDto
     (
         int TotalServices,
         List<ServiceUsageDto> MostRequestedServices,
         List<ServiceUsageDto> LeastRequestedServices
     
     );

}

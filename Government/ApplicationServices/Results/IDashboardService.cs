using Government.Contracts.Dashboard;
using Government.Contracts.DashBoard;

namespace Government.ApplicationServices.Results
{
    public interface IDashboardService
    {
      
        Task<Result<Overview>> GetOverviewAsync();
        Task<Result<RequestStatisticsDto>> GetRequestStatisticsAsync();
        Task<Result<ServiceStatisticsDto>> GetServiceStatisticsAsync();
    }
}

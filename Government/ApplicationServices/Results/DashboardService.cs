using Government.Contracts.Dashboard;
using Government.Contracts.DashBoard;
using Microsoft.EntityFrameworkCore;

namespace Government.ApplicationServices.Results
{
    public class DashboardService(AppDbContext context) : IDashboardService
    {
        private readonly AppDbContext _context = context;

        public async Task<Result<Overview>> GetOverviewAsync()
        {
            // num of users
            var TotalUsers = await _context.Requests
                                  .Select(x => x.UserId)
                                  .Distinct()
                                  .CountAsync();
           

            var TotalServices = await _context.Services
                                     .Where(s => s.IsAvailable)
                                     .CountAsync();

            var ApprovedRequests = await _context.Requests
                                     .Where(r => r.RequestStatus == "Approved")
                                     .CountAsync();

            var RejectedRequests = await _context.Requests
                                     .Where(r => r.RequestStatus == "Rejected")
                                     .CountAsync();

            var  TotalPayments = await _context.Payments
                                     .Where(p => p.PaymentStatus == "Paid")
                                     .SumAsync(p => p.Amount);

            var result = new Overview (TotalUsers, TotalServices , ApprovedRequests , RejectedRequests , TotalPayments);

            return Result.Success(result);

        }

        public async Task<Result<RequestStatisticsDto>> GetRequestStatisticsAsync()
        {
         
            var startOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

            
            int newRequests = await _context.Requests
                 .Where(r => r.RequestDate.Year == startOfMonth.Year && r.RequestDate.Month == startOfMonth.Month)
                 .CountAsync();



            int completedRequests = await _context.Requests
                .Where(r => r.RequestStatus == "Completed")
                .CountAsync();

          
            int rejectedRequests = await _context.Requests
                .Where(r => r.RequestStatus == "Rejected")
                .CountAsync();


            int pendingRequests = await _context.Requests
                .Where(r => r.RequestStatus == "Pending")
                .CountAsync();

            
              var topRequestUsers = await _context.Requests
                .GroupBy(r => r.UserId)
                .Select(g => new UserUsageDto(
                    g.Key, 
                    _context.Users.Where(u => u.Id == g.Key).Select(u =>$"{u.FirstName} {u.LastName}" ).FirstOrDefault()!,
                    g.Count() 

                ))
                .OrderByDescending(u => u.RequestCount) // ترتيب تنازلي 
                .Take(5)
                .ToListAsync();

          
            var data = new RequestStatisticsDto(newRequests, completedRequests, rejectedRequests, pendingRequests, topRequestUsers);

            return Result.Success(data);
        }

        public async Task<Result<ServiceStatisticsDto>> GetServiceStatisticsAsync()
        {
            var TotalServices = await _context.Services.CountAsync();

            var RequestedServices = await _context.Requests
                                        .GroupBy(r => r.ServiceId)
                                        .Select(x => new ServiceUsageDto(
                                            x.Key,
                                            _context.Services.Where(s => s.Id == x.Key).Select(n => n.ServiceName).FirstOrDefault()!,
                                            x.Count()
                                            ))
                                        .OrderByDescending(u => u.RequestCount)
                                        .AsNoTracking()
                                        .ToListAsync();
            var mostRequestedServices = RequestedServices.Take(5).ToList();
            var leastRequestedServices = RequestedServices.TakeLast(5).ToList();


            var data = new ServiceStatisticsDto(TotalServices, mostRequestedServices , leastRequestedServices);



            return Result.Success(data);






        }
    }
    }


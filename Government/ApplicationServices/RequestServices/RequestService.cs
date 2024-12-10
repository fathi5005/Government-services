using Government.Contracts.Request;
using Government.Entities;
using Government.Errors;
using Mapster;
using System.Security.Claims;

namespace Government.ApplicationServices.RequestServices
{
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result<ReqResponseDto>> AddRequestAsync(RequestDto requestDto, CancellationToken cancellationToken)
        {

            var IsServiceExist = await _context.Services
                                       .AsNoTracking()
                                       .SingleOrDefaultAsync(r=>r.ServiceID==requestDto.ServiceId ,cancellationToken);

            if (IsServiceExist is null)
            {
                return Result.Falire<ReqResponseDto>(ServiceError.ServiceNotFound);
            }
            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newrequest = new Request()
            {
                ServiceId = requestDto.ServiceId,
                UserId = UserId!,
                RequestDate = DateTime.UtcNow,
            };

            await _context.Requests.AddAsync(newrequest, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            var reqResponse = newrequest.Adapt<ReqResponseDto>();

            return Result.Success(reqResponse);


        }

        public async Task<Result<IEnumerable<RequestsDetailstoUser>>> GetUserRequestsDetails(CancellationToken cancellationToken)
        {
            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userRequests = _context.Requests
                                 .AsNoTracking()
                                 .Include(r => r.service)
                                 .Include(s => s.AdminResponse)
                                 .Where(x => x.UserId == UserId)
                                 .ToList();


            if (userRequests == null || !userRequests.Any())
            {
                IEnumerable<RequestsDetailstoUser> emptyList = new List<RequestsDetailstoUser>();

                return Result.Success(emptyList); // empty list 
            }

            var ReqResponse = userRequests.Adapt<IEnumerable<RequestsDetailstoUser>>();

            return Result.Success(ReqResponse);

        }
    }
}

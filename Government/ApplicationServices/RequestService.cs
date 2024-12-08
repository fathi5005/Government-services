using Government.Contracts.Request;
using Government.Entities;
using Mapster;
using System.Security.Claims;

namespace Government.Services
{
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestService(AppDbContext context, IHttpContextAccessor httpContextAccessor )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ReqResponseDto> AddAsync(RequestDto requestDto, CancellationToken cancellationToken)
        {

            if (requestDto == null || requestDto.ServiceId<0)
            {
                return null ; // update code result pattern
            }

            var IsServiceExist = await _context.Services.FindAsync(requestDto.ServiceId);

            if (IsServiceExist is null)
            {
                return null; // update code result pattern
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

            return reqResponse;


        }

        public async Task<IEnumerable<RequestsDetailstoUser>> GetUserRequestsDetails(CancellationToken cancellationToken)
        {
            var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userRequests =  _context.Requests
                                 .Include(r => r.service) 
                                 .Include(s=>s.AdminResponse)// Ensure Service is included
                                 .Where(x => x.UserId == UserId)
                                 .ToList();


            if (userRequests == null || !userRequests.Any())
            {
                return new List<RequestsDetailstoUser>();
            }

            var ReqResponse = userRequests.Adapt<IEnumerable<RequestsDetailstoUser>>();

            return ReqResponse;

        }
    }
}

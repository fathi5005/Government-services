using Government.Contracts.Admin;
using Government.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Government.ApplicationServices.AdminServices
{
    public class AdminResponseToRequest : IAdminResponseToRequest
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminResponseToRequest(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result<AdminReplyResult>> AddAdminResponseAsync(AdminReply adminReplyToREquest, CancellationToken cancellationToken = default)
        {

            var request = await _context.Requests        
                                .FirstOrDefaultAsync(r=> r.Id==adminReplyToREquest.RequestId ,cancellationToken);

            if (request is null)
                return Result.Falire<AdminReplyResult>(RequestErrors.RequestNotFound);



            var adminId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var adminResponse = new AdminResponse
            {
                RequestId = adminReplyToREquest.RequestId,
                userId = adminId!,
                ResponseText = adminReplyToREquest.ResponseText,
                ResponseDate = DateTime.UtcNow
            };
            _context.AdminsResponse.Add(adminResponse);

            if (adminReplyToREquest.Action == "Approve")
            {
                request.RequestStatus = "Completed";
                request.ResponseStatus = "Responded";

            }
          
            else if (adminReplyToREquest.Action == "Reject")
            {
                request.RequestStatus = "Rejected";
                request.ResponseStatus = "Responded";
            }

            await _context.SaveChangesAsync();

            var adminReplyResult = new AdminReplyResult(Message: "Response added and request updated successfully."
                                                      , RequestId: adminReplyToREquest.RequestId);


            return Result.Success(adminReplyResult);




        }
    }
}

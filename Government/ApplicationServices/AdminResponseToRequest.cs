using Government.Contracts.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Government.ApplicationServices
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
        public async Task<AdminReplyResult> GetAdminResponseAsync(AdminReply adminReplyToREquest, CancellationToken cancellationToken = default)
        {

           if(adminReplyToREquest.RequestId<=0)
            {
                return null;
            }

            var request = await _context.Requests.FindAsync(adminReplyToREquest.RequestId);
            if (request == null)
                return null; 

        
            var adminId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var AdminIdAsInt =  Convert.ToInt32(adminId);


         
            var adminResponse = new AdminResponse
            {
                RequestId = adminReplyToREquest.RequestId,
                AdminId = AdminIdAsInt,
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


            return adminReplyResult;




        }
    }
}

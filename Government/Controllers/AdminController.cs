using Government.ApplicationServices;
using Government.Contracts.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Government.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminResponseToRequest _adminResponseToRequest;

        public AdminController(IAdminResponseToRequest adminResponseToRequest)
        {
            _adminResponseToRequest = adminResponseToRequest;
        }

        [HttpPost]
        [Route("CreateResponseByAdmin")]
       // [Authorize(Policy = "AdminOnly")]
        [Authorize]

        public async Task<IActionResult> CreateResponseByAdmin (AdminReply adminReply , CancellationToken cancellationToken)
        {
            var adminResponse = await _adminResponseToRequest.GetAdminResponseAsync(adminReply, cancellationToken);

            if (adminResponse is null)
            {

                NotFound("Request not found.");
            }

            return Ok(adminResponse);

        }
    }
}

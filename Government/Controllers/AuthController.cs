using Government.Abstractions;
using Government.ApplicationServices.AdminServices;

using Government.Authentication;

namespace Government.Controllers

{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
      
        private readonly IAdminAuthService _adminauthService;

        public AuthController( IAdminAuthService AdminauthService)
        {
           
            _adminauthService = AdminauthService;
        }

        [HttpPost("AdminLogin")]

        public async Task<IActionResult> AdminLoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var authResult = await _adminauthService.GetAdminTokenAsync(loginRequest.Email, loginRequest.Password, cancellationToken);

            return (!authResult.IsSuccess) ? authResult.ToProblem(statuscode: StatusCodes.Status400BadRequest) : Ok(authResult.Value());


        }
    }
}

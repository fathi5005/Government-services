using Government.Abstractions;
using Government.ApplicationServices.AdminServices;
using Government.ApplicationServices.UserServices;
using Government.Authentication;

namespace Government.Controllers

{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly IUserAuthService _UserauthService;
        private readonly IAdminAuthService _adminauthService;

        public AuthController(IUserAuthService UserauthService , IAdminAuthService AdminauthService)
        {
            _UserauthService = UserauthService;
            _adminauthService = AdminauthService;
        }

        [HttpPost("UserLogin")]

        public async Task<IActionResult> UserLoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var authResult = await _UserauthService.GetUserTokenAsync(loginRequest.Email, loginRequest.Password, cancellationToken);

            return (!authResult.IsSuccess) ? BadRequest(authResult.Error) : Ok(authResult.Value());


        }


        [HttpPost("AdminLogin")]

        public async Task<IActionResult> AdminLoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var authResult = await _adminauthService.GetAdminTokenAsync(loginRequest.Email, loginRequest.Password, cancellationToken);

            return (!authResult.IsSuccess) ? BadRequest(authResult.Error) : Ok(authResult.Value());


        }
    }
}

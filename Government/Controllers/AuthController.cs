namespace Government.Controllers

{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]

        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(loginRequest.Email, loginRequest.Password, cancellationToken);

            return (authResult is null) ? BadRequest("Invalid Email/passWord") : Ok(authResult);


        }
    }
}

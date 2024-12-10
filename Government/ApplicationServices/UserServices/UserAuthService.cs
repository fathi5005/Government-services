using Government.Abstractions;
using Government.Authentication;
using Government.Errors;


namespace Government.ApplicationServices.UserServices

{
    public class UserAuthService : IUserAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserJwtProvider _jwtProvider;

        public UserAuthService(UserManager<ApplicationUser> userManager, IUserJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<LoginResponse>> GetUserTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {

            var user = await _userManager.FindByEmailAsync(Email);
            if (user is null)
                return Result.Falire<LoginResponse>(UserAdminErrors.IvalidCredential);

            var IsValidPassword = await _userManager.CheckPasswordAsync(user, Password);
            if (!IsValidPassword)
                return Result.Falire<LoginResponse>(UserAdminErrors.IvalidCredential);

            //Generate Token
            (string token, int expiresIn) = _jwtProvider.GenerateToken(user);

            var loginResponse = new LoginResponse(user.Id, user.Name, user.NationalId, user.PhoneNumber, user.Email!, token, expiresIn);

            return Result.Success(loginResponse);

        }
    }
}

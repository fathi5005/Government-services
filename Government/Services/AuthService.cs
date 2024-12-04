
using Government.Authentication;

namespace Government.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<ApplicationUser> Usermanager, IJwtProvider jwtProvider)
        {
            _usermanager = Usermanager;
            _jwtProvider = jwtProvider;
        }
        public async Task<LoginResponse> GetTokenAsync(string Email, string Password, CancellationToken cancellationToken = default!)
        {
            // 1- check Email

            var user = await _usermanager.FindByEmailAsync(Email);

            if (user is null)
            {
                return null;

            }
            // 2- check password
            var iSValidPassword = await _usermanager.CheckPasswordAsync(user, Password);
            if (!iSValidPassword)
            {
                return null;

            }

            // 3- generate Token

            (string token, int expirein) = _jwtProvider.GenerateToken(user);

            // 4- return LoginRespone
            return new LoginResponse(user.Id, user.Name, user.Email, token, expirein);
        }
    }
}

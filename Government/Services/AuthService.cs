using Government.Authentication;


namespace SurvayBasket.services

{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }
        public async Task<LoginResponse?> GetTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {

            var user = await _userManager.FindByEmailAsync(Email);
            if (user is null)
                return null;

            var IsValidPassword = await _userManager.CheckPasswordAsync(user, Password);
            if (!IsValidPassword)
                return null;

            // generate token

            (string token, int expiresIn) = _jwtProvider.GenerateToken(user);


            return new LoginResponse(user.Id, user.Name,user.NationalId,user.PhoneNumber, user.Email!,  token, expiresIn);

        }
    }
}
/*
 {
   "email": "mo@test.com",
  "password": "Pass@word123"
} 
 */
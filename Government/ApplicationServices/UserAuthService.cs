using Government.Authentication;


namespace SurvayBasket.services

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
        public async Task<LoginResponse?> GetUserTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
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
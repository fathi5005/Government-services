using Government.Authentication;
using Government.Errors;

namespace Government.ApplicationServices.AdminServices
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly AppDbContext _context;
        private readonly IAdminJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public AdminAuthService(AppDbContext context, IAdminJwtProvider jwtProvider,UserManager<AppUser> userManager)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }
        public async Task<Result<AdminLoginResponse>> GetAdminTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
                return Result.Falire<AdminLoginResponse>(UserAdminErrors.IvalidCredential);

            var IsValidPassword = await _userManager.CheckPasswordAsync(user, Password);

            if (!IsValidPassword)
                return Result.Falire<AdminLoginResponse>(UserAdminErrors.IvalidCredential);


            // generate token
            (string token, int expiresIn) = _jwtProvider.GenerateAdminToken(user!);

            var adminLoginResponse = new AdminLoginResponse(user.Id, user.FirstName, user.LastName, user.Email!, token, expiresIn);

            return Result.Success(adminLoginResponse);

        }
    }
}


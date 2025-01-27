using Government.Authentication;
using Government.Errors;

namespace Government.ApplicationServices.AdminServices
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly AppDbContext _context;
        private readonly IAdminJwtProvider _jwtProvider;
        private readonly UserManager<Admin> _userManager;

        public AdminAuthService(AppDbContext context, IAdminJwtProvider jwtProvider,UserManager<Admin> userManager)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }
        public async Task<Result<AdminLoginResponse>> GetAdminTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var _admin = await _userManager.FindByEmailAsync(Email);

            if (_admin==null)
                return Result.Falire<AdminLoginResponse>(UserAdminErrors.IvalidCredential);

            var IsValidPassword = await _userManager.CheckPasswordAsync(_admin, Password);

            if (!IsValidPassword)
                return Result.Falire<AdminLoginResponse>(UserAdminErrors.IvalidCredential);


            // generate token
            (string token, int expiresIn) = _jwtProvider.GenerateAdminToken(_admin!);

            var adminLoginResponse = new AdminLoginResponse(_admin.Id, _admin.FirstName,_admin.LastName, _admin.Email!, token, expiresIn);

            return Result.Success(adminLoginResponse);

        }
    }
}


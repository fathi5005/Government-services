using Government.Authentication;
using Government.Errors;

namespace Government.ApplicationServices.AdminServices
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly AppDbContext _context;
        private readonly IAdminJwtProvider _jwtProvider;

        public AdminAuthService(AppDbContext context, IAdminJwtProvider jwtProvider)
        {
            _context = context;
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<AdminLoginResponse>> GetAdminTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var _admin = await _context.Admins.AnyAsync(x => x.Email == Email && x.Password == Password);
            if (!_admin)
                return Result.Falire<AdminLoginResponse>(UserAdminErrors.IvalidCredential);

            var admin = _context.Admins.SingleOrDefault(x => x.Email == Email);
            // generate token
            (string token, int expiresIn) = _jwtProvider.GenerateAdminToken(admin!);

            var adminLoginResponse = new AdminLoginResponse(admin!.AdminID, admin.AdminName, admin.Email, token, expiresIn);
            return Result.Success(adminLoginResponse);

        }
    }
}


using Government.Authentication;

namespace Government.ApplicationServices
{
    public class AdminAuthService :IAdminAuthService
    {
        private readonly AppDbContext _context;
        private readonly IAdminJwtProvider _jwtProvider;

        public AdminAuthService(AppDbContext context, IAdminJwtProvider jwtProvider)
        {
            _context = context;
            _jwtProvider = jwtProvider;
        }
        public async Task<AdminLoginResponse?> GetAdminTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var _admin  = await _context.Admins.AnyAsync(x=>x.Email== Email && x.Password == Password);
            if (!_admin )
                return null;

            var admin = _context.Admins.SingleOrDefault(x => x.Email == Email);        
            // generate token
            (string token, int expiresIn) = _jwtProvider.GenerateAdminToken(admin!);


            return new AdminLoginResponse(admin!.AdminID, admin.AdminName, admin.Email, token, expiresIn);

        }
    }
}


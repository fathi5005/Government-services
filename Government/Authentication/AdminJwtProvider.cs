
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Government.Authentication
{
    public class AdminJwtProvider : IAdminJwtProvider
    {

        private readonly JwtOption _options;

        public AdminJwtProvider(IOptions<JwtOption> options)
        {
            _options = options.Value;
        }
        public (string token, int expireIn) GenerateAdminToken(Admin admin)
        {
            Claim[] claims = [
           new(JwtRegisteredClaimNames.Sub, admin.Id),
            new(JwtRegisteredClaimNames.Email, admin.Email!),
            new(JwtRegisteredClaimNames.GivenName, admin.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, admin.LastName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                      ];

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //
            var expiresMin = _options.ExpiryMinutes;

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresMin),
                signingCredentials: singingCredentials
            );

            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresMin * 60);
        }


    }
}

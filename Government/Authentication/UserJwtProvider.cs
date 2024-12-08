
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Government.Authentication
{
    public class UserJwtProvider : IUserJwtProvider
    {
        private readonly  JwtOption _options;

        public UserJwtProvider(IOptions<JwtOption> options )
        {
            _options = options.Value;
        }
        public (string token, int expireIn) GenerateToken(ApplicationUser user)
        {
            Claim[] claims = [
           new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.GivenName, user.Name),
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

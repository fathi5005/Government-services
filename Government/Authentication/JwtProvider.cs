﻿
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Government.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public (string token, int expireIn) GenerateToken(ApplicationUser user)
        {
            Claim[] claims = [
           new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.GivenName, user.Name),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
       ];

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("J7MfAb4WcAIMkkigVtIepIILOVJEjAcB"));

            var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //
            var expiresIn = 30;

            var token = new JwtSecurityToken(
                issuer: "_JwtoptionsIssuer",
                audience: "_JwtoptionsAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresIn),
                signingCredentials: singingCredentials
            );

            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresIn * 60);
        }
    }
}
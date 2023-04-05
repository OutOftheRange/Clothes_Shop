using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using ClothesShop.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace ClothesShop.Services.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = Claims(user);
            var signingCredentials = GetSigningCredentials();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private List<Claim> Claims(User user) { 
            return new List<Claim> { new Claim(ClaimTypes.Email, user.Email)};
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentialss, List<Claim> claims)
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");

            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtConfig["expiresIn"])),
            signingCredentials: signingCredentialss
            );

            return tokenOptions;
        }
    }
}

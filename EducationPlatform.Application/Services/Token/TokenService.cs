using EducationPlatform.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducationPlatform.Application.Services.Token
{
    public static class TokenService
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GenerateToken(UserOutput user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("8A12D4C3C10FEB09A772889EAE2F1EFCE260AE78");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName.ToString()),
            new Claim(ClaimTypes.Role, user.AccessLevel.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            // Adiciona o claim personalizado "UserSignature" se o usuário tiver uma assinatura definida
            if (user.UserSignature != null)
            {
                tokenDescriptor.Subject.AddClaim(new Claim("UserSignature", user.UserSignature.SignatureId.ToString()));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

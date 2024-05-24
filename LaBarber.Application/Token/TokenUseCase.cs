using LaBarber.Domain.Configuration;
using LaBarber.Domain.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LaBarber.Application.Token
{
    public class TokenUseCase : ITokenUseCase
    {
        private readonly Secrets _secrets;

        public TokenUseCase(IOptions<Secrets> secrets)
        {
            _secrets = secrets.Value;
        }

        public string EncryptPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes($"{_secrets.PreSalt}{password}{_secrets.PosSalt}");
            var hash = SHA512.HashData(bytes);
            return GetStringFromHash(hash);
        }

        public string GenerateToken(string name, string role, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _secrets.ClientSecret;
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            var result = new StringBuilder();
            foreach (var b in hash)
            {
                result.Append(b.ToString("X2"));
            }
            return result.ToString();
        }
    }
}

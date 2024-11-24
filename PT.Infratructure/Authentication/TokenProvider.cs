using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PT.Application.Abstraction;
using PT.Domain.Entities.User;
using PT.Infratructure.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PT.Infratructure.Authentication
{
    internal sealed class TokenProvider(IOptions<JwtSettings> jwtsettings) : ITokenProvider
    {
        private readonly JwtSettings _jwtsettings = jwtsettings.Value;
        public string Create(IEnumerable<Claim> claims)
        {
            throw new ApplicationException();
        }

        public (string Token, string RefreshToken) Create(Users user)
        {
            var secretKey = _jwtsettings.Key;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signiningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var subject = new ClaimsIdentity
                (
           [
                 new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")

                ]);


            var tokengenerator = new SecurityTokenDescriptor()
            {
                Issuer = _jwtsettings.Issuer,
                Audience = _jwtsettings.Audience,
                Expires = DateTime.Now.AddDays(_jwtsettings.TokenExpirationInMinutes),
                Subject = subject,
            };
            var refreshTokengenerator = GenerateRefreshToken();
            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokengenerator);
            string refreshToken = handler.CreateToken(refreshTokengenerator);
            return (token, refreshToken);
        }

        public string GenerateLinkToken()
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[410];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var key = Encoding.UTF8.GetBytes(_jwtsettings.Key);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken != null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;

        }
    }
}

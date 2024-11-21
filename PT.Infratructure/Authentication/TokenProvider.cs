using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PT.Application.Abstraction;
using PT.Domain.Entities.User;
using PT.Infratructure.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PT.Infratructure.Authentication
{
    public class TokenProvider(IOptions<JwtSettings> jwtsettings) : ITokenProvider
    {
        private readonly JwtSettings _jwtsettings = jwtsettings.Value;
        public string Create(IEnumerable<Claim> claims)
        {

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
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}

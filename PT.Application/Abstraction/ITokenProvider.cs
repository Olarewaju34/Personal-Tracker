using PT.Domain.Entities.User;
using System.Security.Claims;

namespace PT.Application.Abstraction;

public interface ITokenProvider
    {
        string GenerateRefreshToken();
        string Create(IEnumerable<Claim> claims);
        (string Token, string RefreshToken) Create(Users user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
        string GenerateLinkToken();
    }


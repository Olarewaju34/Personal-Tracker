using Google.Apis.Auth;

namespace PT.Application.Abstraction.ExternalApi
{
    public interface IGoogleAuthService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateAsync(string idToken);
    }
}

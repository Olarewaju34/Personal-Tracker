using Google.Apis.Auth;
using Google.Apis.Http;
using Microsoft.Extensions.Options;
using PT.Application.Abstraction;
using PT.Application.Abstraction.ExternalApi;
using PT.Application.Abstraction.ExternalApi.OptionsSettings;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace PT.Application.Features.Command.User.Auth.GoogleAuth
{
    public sealed class GoogleAuthCommandHandler(IUserRepository _userRepository, ITokenProvider _tokenProvider, IUnitOfWork _unitOfWork, IOptions<GoogleAuthConfig> googleAuthConfig, IHttpClientFactory _client) : ICommandHandler<GoogleAuthCommand, Result>
    {
        private readonly GoogleAuthConfig _googleAuthConfig = googleAuthConfig.Value;
        public async Task<Result<Result>> Handle(GoogleAuthCommand request, CancellationToken cancellationToken)
        {
            Payload payload = new();
            try
            {
                payload = await ValidateAsync(request.IdToken, new ValidationSettings
                {
                    Audience = [_googleAuthConfig.ClientId]
                });

            }
            catch (InvalidJwtException ex)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            GoogleUserModel profileData = new();
            var httpClient = _client.Create(_googleAuthConfig.ClientName);
        }
    }
}

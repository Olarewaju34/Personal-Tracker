using Google.Apis.Http;
using Microsoft.Extensions.Options;
using PT.Application.Abstraction;
using PT.Application.Abstraction.ExternalApi;
using PT.Application.Abstraction.ExternalApi.OptionsSettings;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User;
using System.Net.Http;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace PT.Application.Features.Command.User.Auth.GoogleAuth
{
    public sealed class GoogleAuthCommandHandler() : ICommandHandler<GoogleAuthCommand, Result>
    {
        private readonly GoogleAuthConfig _googleAuthConfig ;
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<GoogleAuthConfig> googleAuthConfig;
        private readonly IHttpClientFactory _client;

        public GoogleAuthCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider, IUnitOfWork unitOfWork, IOptions<GoogleAuthConfig> googleAuthConfig, IHttpClientFactory client)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
            _unitOfWork = _unitOfWork;
            _googleAuthConfig = googleAuthConfig.Value;
            _client = client;
        }
     
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
            using(HttpClient httpClient = new HttpClient()) {
        }
    }
}

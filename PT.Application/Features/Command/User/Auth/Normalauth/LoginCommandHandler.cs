using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.User.Auth.Normalauth
{
    public sealed class LoginCommandHandler(ITokenProvider _tokenProvider, IUserRepository _userRepository) : ICommandHandler<LoginCommad, Result>
    {
        public async Task<Result<Result>> Handle(LoginCommad request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.ExistsAsync(u => u.Email == request.Email);
            if (!userExist)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var user = await _userRepository.GetAsync(u => u.Email == request.Email);
            var passswordMatch = BCrypt.Net.BCrypt.Verify(request.Email, user.Email);
            if (!passswordMatch)
            {
                return Result.Failure(UserErrors.InvalidCredentials);
            }
            var (token, refreshToken) = _tokenProvider.Create(user);
            return Result.Success(token);
        }
    }
}

using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;

namespace PT.Application.Features.Command.User.Auth.GoogleAuth
{
    public record GoogleAuthCommand(string IdToken, string AccessToken) : ICommand<Result>;

}

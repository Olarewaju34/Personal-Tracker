using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User.Dto;

namespace PT.Application.Features.Command.User.CreateUser
{
    public record CreateUserCommand(CreateNewUserDto dto) : ICommand<Result>
    {
    }
}

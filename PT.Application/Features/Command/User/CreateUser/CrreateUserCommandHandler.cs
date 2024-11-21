using MediatR;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User;

namespace PT.Application.Features.Command.User.CreateUser
{
    internal sealed class CreateUserCommandHandler(IUserRepository _userRepository,IUnitOfWork _unitOfWork) : ICommandHandler<CreateUserCommand, Result>
    {
        public async Task<Result<Result>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.ExistsAsync(u => u.Email == request.dto.Email);
            if (userExist)
            {
                return Result.Failure(UserErrors.SameEmail);
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.dto.Password);
            if (passwordHash is  null)
            {
                return Result.Failure(UserErrors.InvalidCredentials);
            }
           
            var newUser = Users.CreateUser(request.dto.FirstName,request.dto.LastName,request.dto.PhoneNumber,request.dto.Email,passwordHash);
            try
            {
                await _userRepository.CreateAsync(newUser);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception)
            {

                return Result.Failure(UserErrors.FailedToCreate);
            }

        }
    }
}

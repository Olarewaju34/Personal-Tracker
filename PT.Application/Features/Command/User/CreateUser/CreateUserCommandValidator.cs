using FluentValidation;
using PT.Domain.Entities.User;
using PT.Domain.Entities.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.User.CreateUser
{
    public sealed class CreateUserCommandValidator : AbstractValidator<CreateNewUserDto>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(us => us.FirstName).MaximumLength(30).NotEmpty().WithMessage("Enter your FirstName");

            RuleFor(us => us.LastName).NotEmpty().MaximumLength(30).WithMessage("Enter your LastName");

            RuleFor(us => us.Email).NotEmpty().EmailAddress().WithMessage("Enter a valid email address");


           RuleFor(x => x.Password)
          .NotEmpty().WithMessage("Password is required.")
          .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
          .MaximumLength(128).WithMessage("Password must not exceed 128 characters.")
          .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
          .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
          .Matches("[0-9]").WithMessage("Password must contain at least one number.")
          .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character.")
          .Matches(@"^\S*$").WithMessage("Password must not contain spaces.");
        }
    }
}

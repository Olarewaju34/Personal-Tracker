using FluentValidation;
using PT.Domain.Entities.Transaction.Dtos;

namespace PT.Application.Features.Command.Transactions
{
    public sealed class CreateTransactionCommandValidator:AbstractValidator<CreateTransactionDto>
    {
        public CreateTransactionCommandValidator()
        {

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Transaction amount must be greater than zero.")
                .LessThanOrEqualTo(2_500_000).WithMessage("Transaction amount cannot exceed 2,500,000.");

            RuleFor(x => x.Date)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Transaction date cannot be in the future.")
                .GreaterThan(new DateTime(2000, 1, 1)).WithMessage("Transaction date cannot be before the year 2000.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Transaction description is required.")
                .MaximumLength(250).WithMessage("Transaction description cannot exceed 250 characters.")
                .Matches(@"^[a-zA-Z0-9\s.,'-]*$").WithMessage("Transaction description contains invalid characters.");
        }
    }
}

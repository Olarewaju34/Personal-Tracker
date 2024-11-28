using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.Budget
{
    public class CreateBudgetCommandValidator : AbstractValidator<CreateBudgetCommand>
    {
        public CreateBudgetCommandValidator()
        {
            RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Transaction amount must be greater than zero.")
            .LessThanOrEqualTo(2_500_000).WithMessage("Transaction amount cannot exceed 2,500,000.");
            RuleFor(b => b.UserId).NotEmpty();
            RuleFor(budget => budget.Description)
          .NotEmpty().WithMessage("Budget description is required.")
          .Length(3, 50).WithMessage("Budget name must be between 3 and 50 characters.");

            // Amount validation
            RuleFor(budget => budget.Amount)
                .GreaterThan(0).WithMessage("Budget amount must be greater than zero.");

            // Start Date validation
            RuleFor(budget => budget.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                 .LessThan(bg => bg.EndDate);
            // End Date validation
            RuleFor(budget => budget.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThanOrEqualTo(budget => budget.StartDate)
                .WithMessage("End date must be after or equal to the start date.");
        }
    }
}

using FluentValidation;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.Category.CreateCategory
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(cg=>cg.Name).NotEmpty().WithMessage(CategoryErrors.Null.Name);
            // Name validation
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .Length(3, 50).WithMessage("Category name must be between 3 and 50 characters.")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Category name can only contain letters, numbers, and spaces.");
            RuleFor(category => category.MoneyFlow).NotEmpty().WithMessage("enter what type of money flow it belongs to");
        }
    }
}

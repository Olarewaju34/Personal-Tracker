using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Application.Abstractions.Clock;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.Budget
{
    public class CreateBudgetCommandHandler(IUserContext userContext, IUserRepository userRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, IBudgetRepository budgetRepository) : ICommandHandler<CreateBudgetCommand, Result>
    {
        public async Task<Result<Result>> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            Users? user = await userRepository.GetUsersAsync(userContext.UserId);
            if (user == null)
            {
                Result.Failure(UserErrors.NotFound);
            }
            var category = await categoryRepository.GetAsync(request.CategoryId);
            if (category == null)
            {
                return Result.Failure(CategoryErrors.Null);
            }
            var duration = DateRange.Create(request.StartDate, request.EndDate);
            try
            {
                var budget = Budgets.CreateBudget(user.Id, category.Id, request.Amount, request.Description, duration, dateTimeProvider.UtcNow);
                await budgetRepository.CreateAsync(budget);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success(budget);
            }
            catch (Exception)
            {

                return Result.Failure(BudgetErrors.FailedToCreate);
            }

        }
    }
}

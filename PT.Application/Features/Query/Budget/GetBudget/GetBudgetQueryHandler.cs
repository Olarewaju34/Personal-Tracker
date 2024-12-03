using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Budget.Dtos;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Query.Budget.GetBudget
{
    public sealed class GetBudgetQueryHandler(IUserContext userContext, IUserRepository userRepository, IBudgetRepository budgetRepository) : IQueryHandler
        <GetBudgetQuery, Result>
    {
        public async Task<Result<Result>> Handle(GetBudgetQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUsersAsync(userContext.UserId);
            if (user == null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var budget = await budgetRepository.GetUsersBudget(request.Id);
            if (budget.UserId == user.Id)
            {
                return Result.Failure(BudgetErrors.InAccesible);
            }
            var userBudget = user.Budgets.Where(bg => bg.UserId == user.Id).Select(bg => new BudgetDto
            (
               UserId: user.Id,
               CategoryId: bg.CategoryId,
               Amount: bg.Amount,
               Description: bg.Description,
               duration: bg.Duration,
               createdAt: bg.Created
            )).ToList();
            if (!userBudget.Any())
            {
                return Result.Failure(BudgetErrors.NotFound);
            }

            return Result.Success(userBudget);
        }
    }
}

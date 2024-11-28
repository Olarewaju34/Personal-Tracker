using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;

namespace PT.Application.Features.Command.Budget
{
    public record CreateBudgetCommand(string UserId, string CategoryId, decimal Amount, string Description,DateOnly StartDate,DateOnly EndDate) :ICommand<Result>
    {
    }
}

using MediatR;
using PT.Application.Abstraction.Email;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.Budget.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.Budget.Event
{
    public class CreateNewBudgetEventHandler(IBudgetRepository budgetRepository, IUserRepository userRepository, IEmailService emailService) : INotificationHandler<BudgetCreatedEvent>
    {
        public async Task Handle(BudgetCreatedEvent notification, CancellationToken cancellationToken)
        {
            var budget = await budgetRepository.GetUsersBudget(notification.BudgetId);
            var user = await  userRepository.GetUsersAsync(budget.UserId);
        }
    }
}

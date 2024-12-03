using MediatR;
using Microsoft.Extensions.Logging;
using PT.Application.Abstraction.Email;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Budget.Event;

namespace PT.Application.Features.Command.Budget.Event
{
    public class CreateNewBudgetEventHandler(IBudgetRepository budgetRepository, IUserRepository userRepository, IEmailService emailService, ILogger<BudgetCreatedEvent> _logger) : INotificationHandler<BudgetCreatedEvent>
    {
        public async Task Handle(BudgetCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received event{typeof(BudgetCreatedEvent).Name}");
            var budget = await budgetRepository.GetUsersBudget(notification.BudgetId,cancellationToken);
            var user = await userRepository.GetAsync(budget.UserId,cancellationToken);
            var content = EmailTemplate.GetBudgetCreatedEmail(budget.Categories.Name,Convert.ToString(budget.Amount),budget.Duration.Start,budget.Duration.End);
            try
            {
                await emailService.SendEmailAsync([user.Email], "You just created a budget", content, false, cancellationToken);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex,$"failed to send email to {user.Email}");
            }
            _logger.LogInformation($"Processed event {typeof(CreateNewBudgetEventHandler)}");
        }
    }
}

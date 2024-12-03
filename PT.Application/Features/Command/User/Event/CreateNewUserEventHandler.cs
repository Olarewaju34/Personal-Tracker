using MediatR;
using Microsoft.Extensions.Logging;
using PT.Application.Abstraction.Email;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.User.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.User.Event
{
    public class CreateNewUserEventHandler : INotificationHandler<CreateNewUserEvent>

    {
        private readonly IUserRepository _userRepository; 
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateNewUserEvent> _logger;
        public CreateNewUserEventHandler(IUserRepository userRepository, ILogger<CreateNewUserEvent> logger, IEmailService emailService)
        {
            ;
            _userRepository = userRepository;
            _logger = logger;
            _emailService = emailService;
        }
        public async Task Handle(CreateNewUserEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received an event {typeof(CreateNewUserEvent).Name}");
            var user = await _userRepository.GetUsersAsync(notification.UserId);
            var content = EmailTemplate.GetWelcomeEmail(user.LastName);
            try
            {
                await _emailService.SendEmailAsync([user.Email], "🎉 Welcome to making good financial decision! Confirm Your Email to Get Started! 🚀", content,false, cancellationToken);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Failed to send email to {user.Email}");
            }
            _logger.LogInformation($"Processed an event {typeof(CreateNewUserEventHandler)}");    
        }
    }
}

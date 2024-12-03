using PT.Domain.Abstraction;

namespace PT.Domain.Entities.User.Event
{
    public record CreateNewUserEvent(string UserId) : IDomainEvent
    {
    }
}

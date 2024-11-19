using PT.Domain.Abstraction;

namespace PT.Domain.Entities.User.Event
{
    public record CreateNewStudentEvent(string StudentId) : IDomainEvent
    {
    }
}

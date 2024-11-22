using PT.Domain.Abstraction;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.User;
using PT.Domain.Shared;
using PT.Domain.ValueObject;
namespace PT.Domain.Entities.Transaction;

public class Transactions : BaseEntity
{
    public string UserId { get; private set; }
    public Users User { get; private set; }
    public decimal Amount { get; private set; }
    public string CategoryId { get; private set; }
    public Categories Category { get; private set; }
    public DateTime DateOnly { get; private set; }
    public string Description { get; private set; }
    public MoneyFlow MoneyFlow { get; private set; }

}


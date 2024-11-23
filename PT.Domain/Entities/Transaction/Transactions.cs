using PT.Domain.Abstraction;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.Transaction.Dtos;
using PT.Domain.Entities.User;
using PT.Domain.Shared;
namespace PT.Domain.Entities.Transaction;

public class Transactions : BaseEntity
{
    public Transactions()
    {
        
    }
    public string UserId { get; private set; }
    public Users User { get; private set; }
    public decimal Amount { get; private set; }
    public string CategoryId { get; private set; }
    public Categories Category { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public MoneyFlow MoneyFlow { get; private set; }
    public static Transactions CreateTransaction(CreateTransactionDto dto)
    {
        var transaction = new Transactions()
        {
           Amount = dto.Amount,
           CategoryId = dto.CategoryId,
           UserId = dto.UserId,
           Description = dto.Description,
           Date = dto.Date,
           MoneyFlow = dto.MoneyFlow
        };
        return transaction;
    }

}


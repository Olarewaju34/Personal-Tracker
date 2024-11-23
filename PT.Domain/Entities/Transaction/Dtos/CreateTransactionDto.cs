using PT.Domain.Shared;

namespace PT.Domain.Entities.Transaction.Dtos
{
    public record class CreateTransactionDto(string UserId, decimal Amount, string CategoryId,DateTime Date,string Description,MoneyFlow MoneyFlow);
 
}

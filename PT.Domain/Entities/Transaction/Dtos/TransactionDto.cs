namespace PT.Domain.Entities.Transaction.Dtos
{
    public record TransactionDto(string UserId,string UserName,decimal Amount, string CategoryId, DateTime Date, string Description);
 
}

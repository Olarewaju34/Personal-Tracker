using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction.Dtos;

namespace PT.Application.Features.Command.Transaction.CreateTransactions
{
    public record class CreateTransactionsCommand(string Token,CreateTransactionDto Dto) : ICommand<Result>;
 
}

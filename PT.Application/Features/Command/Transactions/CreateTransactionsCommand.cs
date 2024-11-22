using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PT.Application.Features.Command.Transactions
{
     public record class CreateTransactionsCommand(CreateTransactionDto Dto ) :ICommand<Result>
    {
    }
}

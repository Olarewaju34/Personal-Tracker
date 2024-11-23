using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Query.Transaction
{
    public record GetTransactionQuery(TransactionDto TransactionDto,string Id) :IQuery<Result>
    {
    }
}

using PT.Application.Abstraction.Messaging;
using PT.Application.Caching;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Query.Transaction.GetTransactions
{
    public record GetTransactionsQuery() : ICachedQuery<Result>
    {
        public string CacheKey => "transactions";

        public TimeSpan? Expiration => null;
    }
}

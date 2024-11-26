using PT.Application.Abstraction.Messaging;
using PT.Application.Caching;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Query.Transaction.GetTransaction
{
    public record GetTransactionQuery(string Id) : ICachedQuery<Result>
    {
        public string CacheKey => $"transaction-{Id}";

        public TimeSpan? Expiration => TimeSpan.FromDays(2);
    }
}

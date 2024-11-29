using PT.Application.Caching;
using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Query.Budget.GetBudget
{
    public record class GetBudgetQuery(string Id) : ICachedQuery<Result>
    {
        public string CacheKey => $"budget-{Id}";

        public TimeSpan? Expiration => TimeSpan.FromDays(2);
    }
}

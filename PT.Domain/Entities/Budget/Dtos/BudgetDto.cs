using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Budget.Dtos
{
    public record  BudgetDto(string UserId, string CategoryId, decimal Amount, string Description, DateRange duration, DateTime createdAt)
    {
    }
}

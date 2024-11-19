using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Budget.Dtos
{
    public record CreateBudgetDto(string UserId, string CategoryId, decimal Amount, string Description)
    {
    }
}

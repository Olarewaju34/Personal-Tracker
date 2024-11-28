using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Abstraction.Repositories
{
    public interface IBudgetRepository :IRepository<Budgets>
    {
    }
}

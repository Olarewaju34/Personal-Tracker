using Microsoft.EntityFrameworkCore;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.Budget;
using PT.Infratructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Repositories
{
    public class BudgetRepository : Repository<Budgets>, IBudgetRepository
    {
        public BudgetRepository(PTContext
            _context) : base(_context)
        {

        }
        public async Task<Budgets> GetUsersBudget(string Id, CancellationToken cancellationToken = default)
        {
            var budget = await _context.Budgets.Include(bg => bg.Users).FirstOrDefaultAsync(bg => bg.Id == Id,cancellationToken);
            return budget;
        }
    }
}

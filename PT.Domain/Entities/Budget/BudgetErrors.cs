using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Budget
{
    public static class BudgetErrors
    {
        public static Error InvalidAmount = new("Budget.Invalid", "Enter a valid ");
        public static Error FailedToCreate = new("Budget.FailedToCreate", "Failed To create budget");
    }
}
